using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Console.WriteLine("Введите число N");
            string nstr = Console.ReadLine();
            int n = 0;
            try
            {
                n = Convert.ToInt32(nstr);
            }
            catch
            {
                Console.WriteLine("Не число");
                Console.ReadLine();
                Run();
                Environment.Exit(0);
            }
            int[,] array = new int[n, n];            
            int diag = 0;
            int col = 0;
            int row = 0;            
            bool magesquare = true;
            int arraylength = array.Length / n;

            Console.WriteLine("\n");
            Console.WriteLine("Введите целые числа по столбцам");
            for (int i = 0; i < arraylength; i++)
            {
                for (int j = 0; j < arraylength; j++)
                {
                    try
                    {
                        array[j, i] = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        j--;
                    }
                }
                col = col + array[i, 0];
                row = row + array[0, i];
                diag = diag + array[i, i];                
            }

            if (col != row || row != diag)
            {
                magesquare = false;
            }

            int currentcol = 0;
            string str = "";
            for (int i = 0; i < arraylength; i++)
            {     
                for (int j = 0; j < arraylength; j++)
                {
                    str = str + " " + array[i, j];
                    if (magesquare)
                    {
                        currentcol = currentcol + array[i,j];
                        if (j == arraylength -1 & currentcol != col)
                        {
                            magesquare = false;
                            break;
                        }
                        else if (j == arraylength - 1)
                        {
                            currentcol = 0;
                        }                        
                    }
                }

                Console.WriteLine(str + " ");                
                str = "";
            }

            int currentrow = 0;
            for (int i = 0; i < arraylength; i++)
            {
                for (int j = 0; j < arraylength; j++)
                {
                    if (magesquare)
                    {
                        currentrow = currentrow + array[j, i];
                        if (j == arraylength - 1 & currentrow != col)
                        {
                            magesquare = false;
                            break;

                        }
                        else if (j == arraylength - 1)
                        {
                            currentrow = 0;
                        }
                    }
                }
                Console.WriteLine(str + " ");                
            }

            int currentdiag = 0;
            for (int i = 0; i < array.Length / n; i++)
            {
                {
                    currentdiag = currentdiag + array[i, i];
                    if (i == arraylength - 1 & currentdiag != col)
                    {
                        magesquare = false;
                        break;
                    }
                    else if (i == (array.Length / n) - 1)
                    {
                        currentdiag = 0;
                    }
                }
            }

            for (int i = 0; i < arraylength ; i++)
            {
                {
                    currentdiag = currentdiag + array[arraylength-1-i, i];
                    if (i == arraylength - 1 & currentdiag != col)
                    {
                        magesquare = false;
                        break;
                    }
                    else if (i == arraylength - 1)
                    {
                        currentdiag = 0;
                    }
                }
            }
            if (magesquare)
            {
                Console.WriteLine("Магический квадрат");
            }
            else
            {
                Console.WriteLine("Не магический квадрат");
            }
            
            Console.ReadLine();
            Run();
            Environment.Exit(0);
        }
    }
}