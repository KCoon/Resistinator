﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCoon.Resistinator.Core
{
    /// <summary>
    ///     Represents circuit
    /// </summary>
    public class Circuit
    {
        public Circuit(IEnumerable<Assembly> assemblies)
        {
            Assemblies = assemblies.ToArray();
        }

        public Circuit(params Assembly[] assemblies)
        {
            Assemblies = assemblies;
        }

        public double TotalResistance => CalculateResistance(0);

        private Assembly[] Assemblies { get; }

        private double CalculateResistance(int index)
        {
            double totalResistance = 0;

            for(var i=index; i < Assemblies.Length; i++)
            {
                if (Assemblies[i].Link == Link.Serial)
                    totalResistance += Assemblies[i].Resistor.Resistance;
                else
                {
                    var r1 = Assemblies[i].Resistor.Resistance;
                    var r2 = CalculateResistance(i+1);
                    totalResistance += 1 / ((1/r1) + (1/r2));
                    break;
                }
            }

            return totalResistance;
        }

        public override string ToString()
        {
            var result = new StringBuilder("Total = ");
            result.Append(TotalResistance);
            foreach (var assembly in Assemblies)
            {
                result.Append(Environment.NewLine + assembly.Resistor.Resistance + 
                              " " + (assembly.Link == Link.Serial ? "S" : "P"));
            }
            return result.ToString();
        }
    }

}