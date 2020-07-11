using System.Collections.Generic;
using System.Linq;

namespace KCoon.Resistinator.Core
{
    public class Circuit
    {
        public Circuit(IEnumerable<Assembly> assemblies)
        {
            Assemblies = assemblies;
        }

        public Circuit(params Assembly[] assemblies)
        {
            Assemblies = assemblies;
        }

        public double TotalResistance => CalculateResistance(Assemblies);

        private IEnumerable<Assembly> Assemblies { get; }

        private static double CalculateResistance(IEnumerable<Assembly> assemblies)
        {
            double totalResistance = 0;
            var enumerable = assemblies.ToList();
            for(var i=0; i<enumerable.Count(); i++)
            {
                if (enumerable[i].Link == Link.Serial)
                    totalResistance += enumerable[i].Resistor.Resistance;
                else
                {
                    var r1 = enumerable[i].Resistor.Resistance;
                    var r2 = CalculateResistance(enumerable.Skip(i + 1));
                    totalResistance += 1 / ((1/r1) + (1/r2));
                    break;
                }
            }

            return totalResistance;
        }
    }

}