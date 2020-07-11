namespace KCoon.Resistinator.Core
{
    public class Resistor
    {
        public double Resistance { get; set; }
        public double Power { get; set; }

        public Resistor(double resistance, double power)
        {
            Resistance = resistance;
            Power = power;
        }
    }
}