using System.Collections;
using System.Collections.Generic;

namespace KCoon.Resistinator.Core
{
    public class AssemblyPermutations : IEnumerable<IEnumerable<Assembly>>
    {
        private readonly List<IEnumerable<Assembly>> _permutations;

        public AssemblyPermutations(List<IEnumerable<Assembly>> permutations)
        {
            _permutations = permutations;
        }

        public AssemblyPermutations()
        {
            _permutations = new List<IEnumerable<Assembly>>();
        }

        public IEnumerator<IEnumerable<Assembly>> GetEnumerator()
        {
            return _permutations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IEnumerable<Assembly> assemblies)
        {
            _permutations.Add(assemblies);
        }
    }
}