using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielowatkoweUwalanieAK2
{
    public class Czlowiek
    {
        public Random random = new Random();
        public void PijPiwo()
        {
            //Console.WriteLine("Piwo jest pite w watku {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(random.Next(500, 2500));
        }

        public void PokazBufory()
        {
            Console.WriteLine("Projekt: [ {0} , {1} ]", Program.zaliczeniaProjektu[0],Program.zaliczeniaProjektu[1]);
            Console.WriteLine("Wyklad: [ {0} , {1} ]", Program.zaliczeniaWykladu[0],Program.zaliczeniaWykladu[1]);
            Console.WriteLine("Laby: [ {0} , {1} ]", Program.zaliczeniaLabow[0],Program.zaliczeniaLabow[1]);
        }

    }
}
