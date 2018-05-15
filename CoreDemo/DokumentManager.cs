using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDemo
{
    public class DokumentManager
    {
        public delegate void Print(Dokument dokument);
        Dokument dokument;


        public DokumentManager(string dokumenName="Rechnung")
        {
            dokument = new Dokument { Id = 1, Name = dokumenName, Path = @"c:\dokument.doc", Summe=200.10 };
            Console.WriteLine(dokument.ToString());

            Print printDokument = null;

            if (dokument.Id >=1)
            {
                printDokument += PrintHeader;
            }


            if (dokument.Name == "Rechnung")
            {
                printDokument += PrintTotal;
            }
            printDokument(dokument);

        }

        public void PrintTotal(Dokument dokument)
        {
            Console.WriteLine($"Dokument Summe {dokument.Summe} für id:" + dokument.Id);
        }

        public void PrintHeader(Dokument dokument)
        {
            Console.WriteLine("Dokument Header für id:" + dokument.Id);
        }

    }
}
