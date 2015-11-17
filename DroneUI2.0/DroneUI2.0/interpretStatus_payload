public struct StatusPayload{ 
	public FlightMode flight_mode; 
	public SensorData sensor; 

}

public struct SensorData{ 
	public Coordinate gpsPos;
    public Coordinate accel_data;
    public Coordinate gyro_data;
    public Coordinate mag_data;
    public int batteryLev;
}

public Payload pay; 


public void buildCommand_payload(char*data, int size){ 


			lock(SharedVars.flightMode)
			{
				SharedVars.flightMode = pay.flight_mode; 
			}
			
			lock(SharedVars.sensorData.currentGPS){ 

				SharedVars.sensorData.currentGPS = pay.sensor.gpsPos; 
			}

			lock(SharedVars.sensorData.accelermatorData){ 

				SharedVars.sensorData.accelermatorData = pay.sensor.accel_data; 
			}

			lock(SharedVars.sensorData.gyroData){ 

				SharedVars.sensorData.gyroData = pay.sensor.gyro_data; 
			}

			lock(SharedVars.sensorData.magData){ 

				SharedVars.sensorData.magData = pay.sensor.mag_data; 
			}

			lock(SharedVars.sensorData.batteryLevel){ 

				SharedVars.sensorData.batteryLevel = pay.sensor.batteryLev; 
			}
		

			//send_data(&pay, sizeof(pay), 'c'); 
		

} 