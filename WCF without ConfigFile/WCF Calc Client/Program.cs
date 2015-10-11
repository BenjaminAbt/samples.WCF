// Example of self hosted WCF service without default configuration
// www.benjamin-abt.com


using System;
using System.ServiceModel;
using SchwabenCode.Examples.WCFCalculatorServices;

namespace SchwabenCode.Examples.WCFCalculatorClient
{
    class Program
    {

        // use a general config for this values and do not put that in your productive code!
        public const String Host = "net.tcp://localhost";
        public const Int32 Port = 31227;
        public const String ServiceName = "MathService";

        static void Main( string[ ] args )
        {
            // Address
            string svcAddress = Host + ":" + Port + "/" + ServiceName;

            // Binding
            NetTcpBinding tcpb = new NetTcpBinding( SecurityMode.Message );
            ChannelFactory<ICalcService> chFactory = new ChannelFactory<ICalcService>( tcpb );


            // Endpoint
            EndpointAddress epAddress = new EndpointAddress( svcAddress );

            // Create Channel
            ICalcService calcService = chFactory.CreateChannel( epAddress );

            if ( calcService == null )
            {
                throw new Exception( "Failed to create channel for " + epAddress );
            }
            try
            {
                const int n1 = 4;
                const int n2 = 5;

                Console.WriteLine( "Connected to service '" + svcAddress + "'." );
                var result = calcService.Add( n1, n2 );


                Console.WriteLine( "The result of " + n1 + "+" + n2 + " is '" + result + "'." );

                Console.WriteLine( "Press key to quit." );
                Console.ReadKey( );
            }
            finally
            {
                chFactory.Close( );
            }
        }
    }
}
