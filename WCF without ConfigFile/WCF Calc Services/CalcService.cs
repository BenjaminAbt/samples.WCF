// Example of self hosted WCF service without default configuration
// www.benjamin-abt.com

using System;

namespace SchwabenCode.Examples.WCFCalculatorServices
{
    /// <summary>
    /// Service implementation of calc service
    /// </summary>
    public class CalcService : ICalcService
    {
        /// <summary>
        /// Returns the sum of both passed numbers
        /// </summary>
        public int Add( Int32 n1, Int32 n2 )
        {
            return n1 + n2;
        }
    }
}
