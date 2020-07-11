using System;
using System.Collections.Generic;
using System.Linq;

namespace KCoon.Resistinator.Core
{
    public static class AssemblyPermutator
    {
        public static IEnumerable<Assembly> GetRandomPermutation(IEnumerable<Resistor> resistors)
        {
            var random = new Random();
            return resistors.Select(resistor => new Assembly(resistor, (Link) random.Next(2))).ToList();
        }

        public static IEnumerable<Circuit> GetAllPermutations(IEnumerable<Resistor> resistors)
        {
            var resistorsList = resistors.ToList();
            var resistorCount = resistorsList.Count;
            var numberOfPossiblePermutations = (long)Math.Pow(2, resistorCount);
            var permutations = new Circuit[numberOfPossiblePermutations];

            var currentAssemblies = new Assembly[resistorCount];

            for (int i = 0; i < numberOfPossiblePermutations; i++)
            {
                for (int j = 0; j < resistorCount; j++)
                {
                    var link = (Link)((i & (1 << j))>>j);
                    currentAssemblies[j] = new Assembly(resistorsList[j], link);
                }
                permutations[i] = new Circuit(currentAssemblies);
            }

            return permutations;
        }
    }
}