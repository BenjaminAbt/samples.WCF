// Example of self hosted WCF service without default configuration
// www.benjamin-abt.com

using System;
using System.ServiceModel;

namespace SchwabenCode.Examples.WCFCalculatorServices
{

    /// <summary>
    /// Service interface for general calc service
    /// </summary>
    public interface ICalcService
    {
        [OperationContract]
        int Add( Int32 n1, Int32 n2 );
    }
}