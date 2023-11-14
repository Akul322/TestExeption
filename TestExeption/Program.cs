using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MyException : Exception
    {
        public MyException()
        { }
        public MyException(string message)
            : base(message)
        { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += ShowNumber;
            try
            {
                numberReader.Read();
            }
            catch (MyException)
            {
                Console.WriteLine("Writed incorret value");
            }
            Console.ReadLine();
        }
        static void ShowNumber(int number)
        {
            List<string> ls = new List<string>();

            ls.Add("Негрич");
            ls.Add("Бобрик");
            ls.Add("Акулибаба");
            ls.Add("Чупилко");
            ls.Add("Хренов");

            switch (number)
            {
                case 1:
                    {
                        Console.WriteLine();
                        ls.Sort();

                        foreach (string lis in ls)
                        {
                            Console.WriteLine(lis);
                        }
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine();
                        ls.Sort();
                        ls.Reverse();

                        foreach (string lis in ls)
                        {
                            Console.WriteLine(lis);
                        }
                    }
                    break;
            }

        }
        class NumberReader
        {
            public delegate void EnteredNumberDel(int number);
            public event EnteredNumberDel NumberEnteredEvent;


            public void Read()
            {
                Console.WriteLine("Need write value 1 or 2");

                int number = Convert.ToInt32(Console.ReadLine());

                if (number != 1 && number != 2) throw new MyException();

                NumberEntered(number);
            }
            protected virtual void NumberEntered(int number)
            {
                NumberEnteredEvent?.Invoke(number);
            }
        }
    }
}
