using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielowatkoweUwalanieAK2
{
    public class Prowadzacy : Czlowiek
    {



        private int id;

        public Prowadzacy(int id)
        {
            this.id = id;
        }

        private bool sprawdzCzyStudentOddalWszystko(int idStudenta)
        {
            if (Program.zaliczeniaProjektu.Contains(idStudenta) && Program.zaliczeniaWykladu.Contains(idStudenta) && Program.zaliczeniaLabow.Contains(idStudenta))
            {
                return true;
            }
            return false;
        }


        public void UwalajStudentow()
        {
            while (true)
            {
                int coRobi = random.Next(0, 3);
                switch (coRobi)
                {
                    case 0:
                        //PijPiwo();
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
                Console.WriteLine("Projekt: [ {0} , {1} ]", Program.zaliczeniaProjektu[0],Program.zaliczeniaProjektu[1]);
                Console.WriteLine("Wyklad: [ {0} , {1} ]", Program.zaliczeniaWykladu[0],Program.zaliczeniaWykladu[1]);
                Console.WriteLine("Laby: [ {0} , {1} ]", Program.zaliczeniaLabow[0],Program.zaliczeniaLabow[1]);
            }
        }

        public void Wystaw2Zero()
        {
            Program.mutex.WaitOne();
            
            for(int i =0; i<3; i++)
            {
                if (sprawdzCzyStudentOddalWszystko(i + 1))
                {
                    Console.WriteLine("Prowadacy uwalil studenta {0} w watku {1}", i+1 ,Thread.CurrentThread.ManagedThreadId);
                    Program.zaliczeniaProjektu[Array.IndexOf(Program.zaliczeniaProjektu, i + 1)] = 0;
                    Program.zaliczeniaLabow[Array.IndexOf(Program.zaliczeniaLabow, i + 1)] = 0;
                    Program.zaliczeniaWykladu[Array.IndexOf(Program.zaliczeniaWykladu, i + 1)] = 0;
                    Program.mutex.ReleaseMutex();
                    return;
                }

            }
            Program.mutex.ReleaseMutex();
            return;
        }

        public void Wystaw3Zero()
        {
            Program.mutex.WaitOne();

            for (int i = 0; i < 3; i++)
            {
                if (sprawdzCzyStudentOddalWszystko(i + 1))
                {
                    Console.WriteLine("Prowadacy zlitowal sie nad studentem {0} w watku {1}", i + 1, Thread.CurrentThread.ManagedThreadId);

                    Program.zaliczeniaProjektu[Array.IndexOf(Program.zaliczeniaProjektu, i + 1)] = 0;
                    Program.zaliczeniaLabow[Array.IndexOf(Program.zaliczeniaLabow, i + 1)] = 0;
                    Program.zaliczeniaWykladu[Array.IndexOf(Program.zaliczeniaWykladu, i + 1)] = 0;
                    Program.mutex.ReleaseMutex();
                    return;
                }

            }
            Program.mutex.ReleaseMutex();
            return;
        }
    }
}
