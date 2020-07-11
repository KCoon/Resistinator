using System.Collections.Generic;
using NUnit.Framework;

namespace KCoon.Resistinator.Core
{
    public class CircuitTests
    {
        [Test]
        public void Test1()
        {
            // arrange
            var circuit = ArrangeCircuit();

            // act
            var totalResistance = circuit.TotalResistance;

            // assert
            Assert.That(totalResistance, Is.EqualTo(2.2).Within(0.0001));
        }
        
        [Test]
        public void Test2()
        {
            // arrange
            var circuit = ArrangeBigCircuit(30);
            var foo = 0.0;

            // act
            for (int i = 0; i < 1e+6; i++)
            {
                foo += circuit.TotalResistance;
            }

        }

        private Circuit ArrangeCircuit()
        {
            return new Circuit(
                new Assembly(1, 0.25, Link.Serial),
                new Assembly(2, 0.25, Link.Parallel),
                new Assembly(3, 0.25, Link.Serial)
                );
        }
        
        private Circuit ArrangeBigCircuit(int depth)
        {
            var assemblies = new List<Assembly>();
            for (var i = 0; i < depth/2; i++)
            {
                assemblies.Add(new Assembly(1, 0.25, Link.Serial));
                assemblies.Add(new Assembly(1, 0.25, Link.Parallel));
            }

            return new Circuit(assemblies);
        }
    }
}