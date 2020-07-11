namespace KCoon.Resistinator.Core
{
    public class Assembly
    {
        public Resistor Resistor { get; }
        public Link Link { get; }

        public Assembly(Resistor resistor, Link link)
        {
            Resistor = resistor;
            Link = link;
        }

        public Assembly(double resistance, double power, Link link)
        {
            Resistor = new Resistor(resistance, power);
            Link = link;
        }
    }
}