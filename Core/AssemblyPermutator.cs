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

            var assemblies = new List<Assembly>();
            foreach (var resistor in resistors)
            {
                assemblies.Add(new Assembly(resistor, (Link)random.Next(2)));
            }

            return assemblies;
        }

        public static AssemblyPermutations GetAllPermutations(IEnumerable<Resistor> resistors)
        {
            var resistorsList = resistors.ToList();
            var permutations = new AssemblyPermutations(); 
            var resistorCount = resistorsList.Count;
            var numberOfPossiblePermutations = (long)Math.Pow(2, resistorCount);

            for (int i = 0; i < numberOfPossiblePermutations; i++)
            {
                var assemblies = new List<Assembly>();
                for (int j = 0; j < resistorCount; j++)
                {
                    var link = (Link)((i & (1 << j))>>j);
                    assemblies.Add(new Assembly(resistorsList[j], link));
                }
                permutations.Add(assemblies);
            }

            return permutations;
        }
    }
}