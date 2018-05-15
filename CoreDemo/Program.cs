using System;
using System.Collections.Generic;

namespace CoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DokumentManager dokumentManager = new DokumentManager("Rechnung");
            DokumentManager dokumentManager2 = new DokumentManager("Rechnung2");
            

            //DemoManager demoManager = new DemoManager();
            //List<Demo> demos = demoManager.CreateList(12);

            //demoManager.DemoListInfo(demos);

            //Console.WriteLine("Anzahl:" + demos.Count);
            //Console.WriteLine("Names:" + demoManager.GetAllNames(demos));
            Console.ReadKey();
        }
    }
}
