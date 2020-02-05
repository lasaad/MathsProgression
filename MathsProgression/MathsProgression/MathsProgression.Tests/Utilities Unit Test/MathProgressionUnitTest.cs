using System;
using MathsProgression.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathsProgression.Tests
{
    [TestClass]
    public class MathProgressionTest
    {
        [TestMethod]
        public void FibonacciTest()
        {
            int resultat = MathsUtilities.Fibonacci(0, 1, 1, 5); 
            Assert.AreEqual(5, resultat, "method must return 5 ");
            
            resultat = MathsUtilities.Fibonacci(0, 1, 1, 6); 
            Assert.AreEqual(8, resultat, "method must return 8 ");

            resultat = MathsUtilities.Fibonacci(0, 1, 1, 35);
            Assert.AreEqual(9227465, resultat, "method must return 9 227 465 ");

        }
    }
}
