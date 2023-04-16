using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielowatkoweUwalanieAK2
{
    public class Student : Czlowiek //ta xD
    {

        private int id;

        public Student(int id)
        {
            this.id = id;
        }

        public void ProdukujWypociny()
        {
            while (true)
            {
                int coRobi = random.Next(0, 4);
                switch (coRobi)
                {
                    case 0:
                        //PijPiwo();
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


        //zrob zmienna co pinuje jaka prace oddalem
        public void UdawajZeRozumieszAssemblera()   //projekt
        {
            Program.mutex.WaitOne();
            


            if (Program.zaliczeniaProjektu.Contains(id))
            {
                Program.mutex.ReleaseMutex(); //ten student zrobil juz projekt
                return;
            }
            else
            {
                if (Program.zaliczeniaProjektu.Count(n => n == 0) == 2) //jezeli nikt nie oddal labow to oddaj 
                {
                    Console.WriteLine("Student {0} szuka wskaznika na stos w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                    Program.zaliczeniaProjektu[Array.IndexOf(Program.zaliczeniaProjektu, 0)] = id;
                    Program.mutex.ReleaseMutex();
                    return;
                }
                else if (Program.zaliczeniaProjektu.Contains(0))
                {                                   //jezeli ktos juz oddal laby
                    if ((Program.zaliczeniaWykladu.Contains(id)) && (Program.zaliczeniaLabow.Contains(id))) //ale ja oddalem pozostale to oddaj
                    {
                        Console.WriteLine("Student {0} szuka wskaznika na stos w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                        Program.zaliczeniaProjektu[Array.IndexOf(Program.zaliczeniaProjektu, 0)] = id;
                        Program.mutex.ReleaseMutex();
                        return;
                    }
                    else if ((Program.zaliczeniaLabow.Contains(id) && Program.zaliczeniaWykladu.Contains(0))) //jak oddam bedzie dla mnie miejsce na wyklad
                    {
                        Console.WriteLine("Student {0} zbiera na warunek w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                        Program.zaliczeniaProjektu[Array.IndexOf(Program.zaliczeniaProjektu, 0)] = id;
                        Program.mutex.ReleaseMutex();
                        return;
                    }
                    else if ((Program.zaliczeniaWykladu.Contains(id) && Program.zaliczeniaLabow.Contains(0))) //jak oddam bedzie dla mnie miejsce na laby
                    {
                        Console.WriteLine("Student {0} zbiera na warunek w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                        Program.zaliczeniaProjektu[Array.IndexOf(Program.zaliczeniaProjektu, 0)] = id;
                        Program.mutex.ReleaseMutex();
                        return;
                    }
                }
                Program.mutex.ReleaseMutex();
                return;

            }


        }


        public void ModlSieDoBiernata() //wyklad
        {
            Program.mutex.WaitOne();
            
            if (Program.zaliczeniaWykladu.Contains(id))
            {
                Program.mutex.ReleaseMutex(); //ten student zrobil juz wyklad
                return;
            }
            else
            {
                if (Program.zaliczeniaWykladu.Count(n => n == 0) == 2) //jezeli nikt nie oddal labow to oddaj 
                {
                    Console.WriteLine("Student {0} zbiera na warunek w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                    Program.zaliczeniaWykladu[Array.IndexOf(Program.zaliczeniaWykladu, 0)] = id;
                    Program.mutex.ReleaseMutex();
                    return;
                }
                else if (Program.zaliczeniaWykladu.Contains(0))
                {                                   //jezeli ktos juz oddal laby
                    if ((Program.zaliczeniaProjektu.Contains(id)) && (Program.zaliczeniaLabow.Contains(id))) //ale ja oddalem pozostale to oddaj
                    {
                        Console.WriteLine("Student {0} zbiera na warunek w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                        Program.zaliczeniaWykladu[Array.IndexOf(Program.zaliczeniaWykladu, 0)] = id;
                        Program.mutex.ReleaseMutex();
                        return;
                    }

                    else if ((Program.zaliczeniaProjektu.Contains(id) && Program.zaliczeniaLabow.Contains(0))) //jak oddam bedzie dla mnie miejsce na laby
                    {
                        Console.WriteLine("Student {0} zbiera na warunek w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                        Program.zaliczeniaWykladu[Array.IndexOf(Program.zaliczeniaWykladu, 0)] = id;
                        Program.mutex.ReleaseMutex();
                        return;
                    }
                    else if ((Program.zaliczeniaLabow.Contains(id) && Program.zaliczeniaProjektu.Contains(0))) //jak oddam bedzie dla mnie miejsce na projekt
                    {
                        Console.WriteLine("Student {0} zbiera na warunek w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                        Program.zaliczeniaWykladu[Array.IndexOf(Program.zaliczeniaWykladu, 0)] = id;
                        Program.mutex.ReleaseMutex();
                        return;
                    }


                }
                Program.mutex.ReleaseMutex();
                return;

            }



        }

        public void UczSieDokumentacjiIntelaNaPamiec()  //laby
        {
            Program.mutex.WaitOne();
            
            
            if (Program.zaliczeniaLabow.Contains(id))
            {
                Program.mutex.ReleaseMutex(); //ten student zrobil juz laby
                return;
            }
            else
            {
                if (Program.zaliczeniaLabow.Count(n => n==0) == 2) //jezeli nikt nie oddal labow to oddaj 
                {
                    Console.WriteLine("Student {0} zapomnial uwzglednic przeniesienia w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                    Program.zaliczeniaLabow[Array.IndexOf(Program.zaliczeniaLabow, 0)] = id;
                    Program.mutex.ReleaseMutex();
                    return;
                }
                else if (Program.zaliczeniaLabow.Contains(0))
                {                                   //jezeli ktos juz oddal laby
                    if ((Program.zaliczeniaProjektu.Contains(id)) && (Program.zaliczeniaWykladu.Contains(id))) //ale ja oddalem pozostale to oddaj
                    {
                        Console.WriteLine("Student {0} zapomnial uwzglednic przeniesienia w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                        Program.zaliczeniaLabow[Array.IndexOf(Program.zaliczeniaLabow, 0)] = id;
                        Program.mutex.ReleaseMutex();
                        return;
                    }

                    else if ((Program.zaliczeniaProjektu.Contains(id) && Program.zaliczeniaWykladu.Contains(0))) //jak oddam bedzie dla mnie miejsce na wyklad
                    {
                        Console.WriteLine("Student {0} zbiera na warunek w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                        Program.zaliczeniaLabow[Array.IndexOf(Program.zaliczeniaLabow, 0)] = id;
                        Program.mutex.ReleaseMutex();
                        return;
                    }
                    else if ((Program.zaliczeniaWykladu.Contains(id) && Program.zaliczeniaProjektu.Contains(0))) //jak oddam bedzie dla mnie miejsce na projekt
                    {
                        Console.WriteLine("Student {0} zbiera na warunek w watku {1}", id, Thread.CurrentThread.ManagedThreadId);
                        Program.zaliczeniaLabow[Array.IndexOf(Program.zaliczeniaLabow, 0)] = id;
                        Program.mutex.ReleaseMutex();
                        return;
                    }

                }
                Program.mutex.ReleaseMutex();
                return;

            }

        }
    }
}
