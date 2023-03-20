using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielowatkoweUwalanieAK2
{
    public class Prowadzacy : Czlowiek
    {





        public void UwalajStudentow()
        {
            while (true)
            {
                int coRobi = random.Next(0, 3);
                switch (coRobi)
                {
                    case 0:
                        PijPiwo();
                        break;
                    case 1:
                        Wystaw2Zero();
                        break;

                    case 2:
                        Wystaw3Zero();
                        break;

                    default:
                        break;
                }

                PijPiwo();
            }
        }

        public void Wystaw2Zero()
        {
            Console.WriteLine("Prowadacy uwalil studenta w watku {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public void Wystaw3Zero()
        {
            Console.WriteLine("Prowadzacy sie zlitowal w watku {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
