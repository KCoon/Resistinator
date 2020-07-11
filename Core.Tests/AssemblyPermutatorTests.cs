using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace KCoon.Resistinator.Core
{
    public class AssemblyPermutatorTests
    {
        [Test]
        public void Test1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                var assemblies = AssemblyPermutator.GetRandomPermutation(ArrangeResistors());
                foreach (var assembly in assemblies)
                {
                    Console.WriteLine(assembly.Resistor.Resistance + " " + assembly.Link);
                }
            }
        }
        
        [Test]
        public void Test2()
        {
            var circuits = AssemblyPermutator.GetAllPermutations(ArrangeResistors());

            int i = 0;
            foreach (var circuit in circuits)
            {
                Console.WriteLine(i);
                Console.WriteLine(circuit);
                i++;
            }
        }

        [Test]
        public void Test3()
        {
            double nominalResistance = 11.5;
            var permutations = AssemblyPermutator.GetAllPermutations(ArrangeResistors(23)).ToList();

            var bestFit = permutations.First();
            var smallestDelta = Math.Abs(bestFit.TotalResistance - nominalResistance);

            foreach (var p in permutations.Skip(1))
            {
                if (Math.Abs(p.TotalResistance - nominalResistance) < smallestDelta)
                {
                    bestFit = p;
                    smallestDelta = Math.Abs(bestFit.TotalResistance - nominalResistance);
                }
            }

            Console.WriteLine("Delta = " + smallestDelta);
            Console.WriteLine(bestFit);
        }

        private static IEnumerable<Resistor> ArrangeResistors()
        {
            return new List<Resistor>()
            {
                new Resistor(1, 0.25),
                new Resistor(2, 0.25),
                new Resistor(3, 0.25),
            };
        }
        private static IEnumerable<Resistor> ArrangeResistors(int depth)
        {
            var resistors = new List<Resistor>();
            for (var i = 0; i < depth; i++)
            {
                resistors.Add(new Resistor(1, 0.25));
            }
            return resistors;
        }
    }
}