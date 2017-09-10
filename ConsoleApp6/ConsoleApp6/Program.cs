using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            First();
            Second();
        }

        static void First()
        {
            string[] strBytes;

            using (FileStream stream = new FileStream(@"Fibonachi.txt", FileMode.OpenOrCreate))
            {
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                strBytes = (Encoding.Default.GetString(bytes)).Split(' ');
            }

            // Размер задается в два раза больше, так как нам необходимо записать 
            //столько же чисел Фибоначи в последоватеьлность, сколько их было изначально
            int[] fibonachiNumbers = new int[strBytes.Length * 2];

            for (int i = 0; i < (strBytes.Length); i++)
            {
                fibonachiNumbers[i] = Int32.Parse(strBytes[i]);
            }

            for (int i = 0; i < strBytes.Length; i++)
            {
                fibonachiNumbers[strBytes.Length + i] = fibonachiNumbers[strBytes.Length + i - 1] + fibonachiNumbers[strBytes.Length + i - 2];
            }

            using (FileStream stream = new FileStream(@"Fibonachi.txt", FileMode.OpenOrCreate))
            {
                string strStream = "";

                for (int i = 0; i < fibonachiNumbers.Length; i++)
                {
                    strStream += fibonachiNumbers[i].ToString();
                    if (i < (fibonachiNumbers.Length - 1)) strStream += " ";
                }

                byte[] bytes = new byte[strStream.Length];
                bytes = Encoding.Default.GetBytes(strStream);
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        static void Second()
        {
            int a, b;
            string[] strBytes;
            string summa;

            using (FileStream stream = new FileStream("INPUT.txt", FileMode.OpenOrCreate))
            {
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                strBytes = (Encoding.Default.GetString(bytes)).Split(' ');
                a = Int32.Parse(strBytes[0]);
                b = Int32.Parse(strBytes[1]);
            }

            using (FileStream stream = new FileStream("OUTPUT.txt", FileMode.OpenOrCreate))
            {
                summa = string.Format("{0}", a+b);
                byte[] bytes = new byte[summa.Length];
                bytes = Encoding.Default.GetBytes(summa);
                stream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
