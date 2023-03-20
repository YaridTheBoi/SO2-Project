using System;
using System.Threading;

namespace WielowatkoweUwalanieAK2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Prowadzacy prowadzacy = new Prowadzacy();
            Student student = new Student();

            Thread watekStudencki = new Thread(new ThreadStart(student.ProdukujWypociny));
            Thread watekProwadzacych = new Thread(new ThreadStart(prowadzacy.UwalajStudentow));

            watekProwadzacych.Start();
            watekStudencki.Start();
        }
    }
}

