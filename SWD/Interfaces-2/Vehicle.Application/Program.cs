using Vehicles;

class Program
{
    static void Main()
    {
        MotorBike myGasBike = new MotorBike(new GasEngine(100));
        MotorBike myDieselBike = new MotorBike(new DieselEngine());
    }
}