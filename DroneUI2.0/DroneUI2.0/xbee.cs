using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using DroneUI2;

public class Picture { 
    public SerialPort _serialPort;
    Allwork serial = new Allwork();
    public Picture(){
        serial.send_recieve("COM5");
    }
}


public class Xbee
{
    Allwork serial = new Allwork();
    //Info pack = new Info();
    public Xbee() {
        serial.send_recieve("COM8");
    }
    public void send<T>(T input, char code) where T : struct
    {
        serial.send<T>(input, code);
    }
}
class Allwork
{
    public SerialPort _serialPort;
    public int state = 0;
    public int size;
    public char type;
    //public Pic_in pic =  new Pic_in();
    byte[] buffer = new byte[5];
    byte[] data = new byte[5000];
    int i_data = 0;
    public Parser parse = new Parser();
    SortedDictionary<int, byte[]> sent_mes = new SortedDictionary<int, byte[]>();
    int which_mess = 0;
    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        if (_serialPort.IsOpen == true)
        {

            Console.WriteLine("recieved");
            try
            {
                Stopwatch watch = new Stopwatch();
                while(_serialPort.Read(buffer, 0, 1) > 0){
                    bool restart = true;
                    int temp = buffer[0];
                    if (i_data == 4380) {
                        Console.WriteLine("Parse that bitch");
                    }
                    if (buffer[0] == 169 && state == 4){
                        state++;
                        restart = false;
                        watch.Start();
                    }
                    else if (state == 5) {
                        if (buffer[0] == 22)
                        {
                            state++;
                            restart = false;
                        }
                        else state = 4;
                    }
                    else if (state == 6) {
                        if (buffer[0] == 243){
                            restart = false;
                            state++;
                            if (i_data == size || type == 'p'){
                                Console.WriteLine("Parsing");
                                watch.Stop();
                                long time = watch.ElapsedMilliseconds;
                                int value = parse.input(data, size, type);
                                if (value > -2) {
                                    if (value == -1) {
                                        resend_all();
                                    }
                                    else if(sent_mes.ContainsKey(value))
                                        sent_mes.Remove(value);
                                }
                            }
                            else{
                                Console.WriteLine("Data Wrong size :(");
                            }
                            type = '0';
                            state = 0;
                            i_data = 0;
                        }
                        else
                            state = 4;
                    }
                    if (state >= 4)
                    {
                        if (i_data < size)
                        {
                            data[i_data] = (byte)buffer[0];
                            int temp2 = data[i_data];
                            i_data++;
                            Console.WriteLine("test");
                        }
                        else if(restart)
                        {
                            i_data = 0;
                            state = 0;
                        }
                    }
                    else if (state == 3)
                    {
                        type = (char)buffer[0];
                        if (_serialPort.Read(buffer, 0, 2) > 0)
                        {
                            size = buffer[0];
                            size = size << 8;
                            size += buffer[1] & 255;
                        }
                        else
                        {
                            Console.WriteLine("lost message {0}", state);
                            state = (char)0;
                            state = 0;
                        }
                        state++;
                    }
                    else if (buffer[0] == 133 && state < 3)
                    {
                        state++;
                    }
                }
            }
            catch (TimeoutException)
            {
                Console.WriteLine("catch");
            }
        }
    }
    public void send_recieve(string com) {
        _serialPort = new SerialPort(com, 9600);
        _serialPort.WriteTimeout = 500;
        try
        {
            _serialPort.Open();
        }
        catch {
            Console.WriteLine("could not open Xbee");
        }
        _serialPort.DataReceived += serialPort1_DataReceived;
        _serialPort.ReadTimeout = 500;

    }
    public void send<T>(T input, char code) where T : struct
    {
        int len = Marshal.SizeOf(input);
        byte[] obj = new byte[len];
        IntPtr ptr = Marshal.AllocHGlobal(len);
        Marshal.StructureToPtr(input, ptr, true);
        Marshal.Copy(ptr, obj, 0, len);
        Marshal.FreeHGlobal(ptr);
        //obj is input in byte array
        byte[] front = { 133, 133, 133, 0, 0, 0, 0};
        byte[] back = { 169, 22, 243 };
        int size = Marshal.SizeOf(typeof(T));
        front[3] = (byte)code;
        front[4] = (byte)(which_mess & 255);
        front[5] = (byte)(size >> 8);
        front[6] = (byte)(size & 255);
        //concate front obj and back
        byte[] send = new byte[front.Length + obj.Length + back.Length];
        System.Buffer.BlockCopy(front, 0, send, 0, front.Length);
        System.Buffer.BlockCopy(obj, 0, send, front.Length, obj.Length);
        System.Buffer.BlockCopy(back, 0, send, obj.Length +
            front.Length, back.Length);
         _serialPort.Write(send, 0, send.Length);
         sent_mes.Add(which_mess, send);
         which_mess = (which_mess + 1) % 255;
    }
    void resend_all() {
        SortedDictionary<int, byte[]> sent = sent_mes;
        foreach (var item in sent.Values)
        {
            _serialPort.Write(item, 0, item.Length);
        }
    }
}

class Parser {
    public int input(byte[] data, int size, char type){
        Form form1 = Application.OpenForms["Form1"];
        
        if (type == 'i') {
            int_parse(data, size);
        }
        else if (type == 'g') {
            gps_parse(data, size);
        }
        else if (type == 'r') {
            return ByteArrayToStructure<int>(data, size);      
        }
        else if (type == 'p')
        {
            Console.WriteLine("woo");
            byte[] pic = new byte[size];
            System.Buffer.BlockCopy(data, 0, pic, 0, size);
            try
            {
                //Image image = Image.FromStream(new MemoryStream(pic), false, false);
                //form1.updateVideoFeedImage(image);
                //picturebox1.image = image;
                
                using (Image image = Image.FromStream(new MemoryStream(pic), false, false))
                {
                    image.Save("output.jpg", ImageFormat.Jpeg);  // Or Png
                }
            }
            catch
            {
                Console.WriteLine("error picture corrupted!");
            }
        }
        return -2;
    }
    void int_parse(byte[] data, int size)
    {
       Test temp = ByteArrayToStructure<Test>(data, size);
        
    }
    void gps_parse(byte[] data, int size)
    {
        gps_info temp = ByteArrayToStructure<gps_info>(data, size);

    }
    public static T ByteArrayToStructure<T>(byte[] buffer, int size) where T : struct
    {
        int length = Marshal.SizeOf(typeof(T));
        IntPtr i = Marshal.AllocHGlobal(length);
        Marshal.Copy(buffer, 0, i, length);
        T result = (T)Marshal.PtrToStructure(i, typeof(T));
        Marshal.FreeHGlobal(i);
        return result;
    }
}

class Reverse_parse{
    public static byte[] StructureToByteArray<T>(T structure) where T : struct
    {
        int len = Marshal.SizeOf(structure);
        byte[] result = new byte[len];
        IntPtr ptr = Marshal.AllocHGlobal(len);
        Marshal.StructureToPtr(structure, ptr, true);
        Marshal.Copy(ptr, result, 0, len);
        Marshal.FreeHGlobal(ptr);
        return result;
    }
}
struct gps_info
{
    public double latitude;
    public double longitude;
    public double speed;
    public double altitude;
    public double course;
};

struct Test
{
    public int test;
}

