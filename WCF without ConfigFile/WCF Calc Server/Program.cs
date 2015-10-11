// Example of self hosted WCF service without default configuration
// www.benjamin-abt.com

using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using SchwabenCode.Examples.WCFCalculatorServices;

namespace SchwabenCode.Examples.WCFCalculatorServer
{
    class Program
    {
        // use a general config for this values and do not put that in your productive code!
        public const String Host = "net.tcp://localhost";
        public const Int32 Port = 31227; 
        public const String ServiceName = "MathService";

        static void Main( string[ ] args )
        {
            // service location
            string svcAddress = Host + ":" + Port + "/" + ServiceName;
            Uri svcUri = new Uri( svcAddress );

            // Creare Service reference
            using ( ServiceHost sh = new ServiceHost( typeof( CalcService ), svcUri ) )
            {
                // Binding
                NetTcpBinding tcpBinding = new NetTcpBinding( SecurityMode.Message );

                // Behavior
                ServiceMetadataBehavior behavior = new ServiceMetadataBehavior( );
                sh.Description.Behaviors.Add( behavior );
                sh.AddServiceEndpoint( typeof( IMetadataExchange ), MetadataExchangeBindings.CreateMexTcpBinding( ), "mex" );

                //Endpoint
                sh.AddServiceEndpoint( typeof( ICalcService ), tcpBinding, svcAddress );

                // Open
                sh.Open( );

                Console.WriteLine( "Service started '" + svcAddress + "' ...Press key to quit." );
                Console.ReadKey( );

                Console.WriteLine( "Quit. Press key to close." );
                Console.ReadKey( );

                // Close
                sh.Close( );
            }

        }
    }
}
