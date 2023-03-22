using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WCF_Chat.ChatService)))
            {
                host.Open();
                Console.WriteLine("The host has started successfully");
                Console.ReadLine();
            }
        }
    }
}
