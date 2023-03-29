using System;
using System.Threading;

namespace WielowatkoweUwalanieAK2
{
    public class Program
    {
        public static Mutex mutex = new Mutex();
        public static int[] zaliczeniaLabow = new int[] {0,0};
        public static int[] zaliczeniaWykladu = new int[] { 0, 0 };   
        public static int[] zaliczeniaProjektu = new int[] { 0, 0 };


        static void Main(string[] args)
        {
            

            Prowadzacy prowadzacy1 = new Prowadzacy(1);
            Prowadzacy prowadzacy2 = new Prowadzacy(2); 

            Student student1 = new Student(1);
            Student student2 = new Student(2);
            Student student3 = new Student(3);

            Thread watekStudencki1 = new Thread(new ThreadStart(student1.ProdukujWypociny));
            Thread watekStudencki2 = new Thread(new ThreadStart(student2.ProdukujWypociny));
            Thread watekStudencki3 = new Thread(new ThreadStart(student3.ProdukujWypociny));

            Thread watekProwadzacych1 = new Thread(new ThreadStart(prowadzacy1.UwalajStudentow));
            Thread watekProwadzacych2 = new Thread(new ThreadStart(prowadzacy2.UwalajStudentow));

            watekProwadzacych1.Start();
            watekProwadzacych2.Start();


            watekStudencki1.Start();
            watekStudencki2.Start();
            watekStudencki3.Start();


            watekStudencki1.Join();
            watekStudencki2.Join();
            watekStudencki3.Join();

            watekProwadzacych1.Join();
            watekProwadzacych2.Join();
        }
    }
}

