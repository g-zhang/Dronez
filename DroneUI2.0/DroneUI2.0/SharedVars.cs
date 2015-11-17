using System;
using System.Drawing;
using System.Collections.Generic;

public class SharedVars
{
    public static Image videoFeedImage;
    public static Image objectDetectionImage;
    public static Queue<Coordinate> gpsQueue;
    public static SensorData sensorData;
    public static FlightMode flightMode;
    public static char[] sendBuffer;
    public static char[] receiveBuffer;

    public SharedVars()
    {
    }
}
