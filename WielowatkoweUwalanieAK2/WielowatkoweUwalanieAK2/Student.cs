using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielowatkoweUwalanieAK2
{
    public class Student : Czlowiek //ta xD
    {
        
        public void ProdukujWypociny()
        {
            while (true)
            {
                int coRobi = random.Next(0, 4);
                switch (coRobi)
                {
                    case 0:
                        PijPiwo();
                        break;
                    case 1:
                        UdawajZeRozumieszAssemblera();
                        break;

                    case 2:
                        ModlSieDoBiernata();
                        break;

                    case 3:
                        UczSieDokumentacjiIntelaNaPamiec();
                        break;

                    default: 
                        break;
                }

                PijPiwo();
            }
        }

        public void UdawajZeRozumieszAssemblera()
        {
            Console.WriteLine("Student szuka wskaznika na stos w watku {0}", Thread.CurrentThread.ManagedThreadId);
        }


        public void ModlSieDoBiernata()
        {
            Console.WriteLine("Student zbiera na warunek w watku {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public void UczSieDokumentacjiIntelaNaPamiec()
        {
            Console.WriteLine("Student zapomnial uwzglednic przeniesienia w watku {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
