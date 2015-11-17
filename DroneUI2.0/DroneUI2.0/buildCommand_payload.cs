
public struct Payload{ 
	public FlightMode flight_mode; 
	public Coordinate gpsPos; 
	public double batteryLev; 
	public Coordinate gyro_data; 
	public Coordinate accel_data; 
	public Coordinate mag_data; 
	public double ultra_data; 

}

public Payload pay; 


public void buildCommand_payload(void){ 


			lock(SharedVars.flightMode)
			{
				pay.flight_mode = SharedVars.flightMode; 
			}
			
			lock(SharedVars.currentGPS){ 

				pay.gpsPos = Shared.currentGPS; 
			}
		

			//send_data(&pay, sizeof(pay), 'c'); 
			


} 








//build payload - taking data from the shared vars and putting it into a payload, then sending it 
//interpreting - taking payload that was sent from max and putting it into the shared variables 