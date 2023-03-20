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
            Console.WriteLine("Piwo jest pite w watku {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(random.Next(500, 2500));
        }

    }
}
