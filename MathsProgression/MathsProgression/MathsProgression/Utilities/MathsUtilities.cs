using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathsProgression.Utilities
{
    public class MathsUtilities
    {
        private static readonly ILog Log = LogManager.GetLogger("[Logger Class : MathsUtilities]");
        /// <summary>
        /// This method return <number>th rank of Fibonacci numbers
        /// This is a recursive method, please modify only last parameter
        /// usage : MathsUtilities.Fibonacci(0, 1, 1, rank desired);
        /// </summary>
        /// <param name="a">keep 0</param>
        /// <param name="b">keep 1</param>
        /// <param name="counter">keep 1</param>
        /// <param name="number">rank desired</param>
        /// <returns></returns>
        public static int Fibonacci(int a, int b, int counter, int number)
        {
            try
            {
                //Result is to high for int type
                if (number > 45)
                    return -1;
                if (counter < number + 1)
                    return Fibonacci(b, a + b, counter + 1, number);
                else
                    return a;
            }
            catch (Exception ex)
            {
                Log.Error("An error happened : " + ex.Message);
                throw;
            }
           
        }
    }
}