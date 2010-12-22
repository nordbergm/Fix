﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRack
{
    class Program
    {
        static void Main()
        {
            using (var server = new Server("http://*:1337/"))
            {
                var cracker = new CRacker(server.Start, server.Stop);
                cracker.AddHandler(new RequestPrinter().PrintRequest);
                cracker.AddHandler(new InfoPrinter().PrintInfo);
                cracker.AddPipe(new MethodDownshifter().DownshiftMethod);
                cracker.Start();
                Console.Write("Running. Press Enter to stop.");
                Console.ReadLine();
                cracker.Stop();
            }
        }
    }
}
