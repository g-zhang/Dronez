public struct Coordinate
{
    public double x;
    public double y;
    public double z;
};

public struct SensorData
{
    public Coordinate currentGPS;
    public Coordinate accelermatorData;
    public Coordinate gyroData;
    public Coordinate magData;
    public int batteryLevel;
};

public enum FlightMode { gpsNav, roadLineDetection, returnHome, landNow};