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

public enum FlightMode { gpsNav, roadLineDetection, returnHome, landNow, manual};

public struct StatusPayload
{
    public FlightMode flightMode;
    public int batteryLevel;
    public Coordinate gyroData;
    public Coordinate accData;
    public Coordinate magData;
    public Coordinate currentGPS;
};