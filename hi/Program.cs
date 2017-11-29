using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SumItUp
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcp = new TcpClient("jlab13.eal.dk", 11101);

            Stream stream = tcp.GetStream();

            StreamReader streamreader = new StreamReader(stream);
            StreamWriter streamwriter = new StreamWriter(stream);
            streamwriter.AutoFlush = true;

            string FindSum(int num1, int num2)
            {
                return (num1 + num2).ToString();
            }

            for (int i = 0; i < 100; i++)
            {
                string line = streamreader.ReadLine();
                Console.WriteLine(line);

                if (line.IndexOf("eal{") != -1 )
                {
                    Console.ReadKey();
                    break;
                }

                string[] stringArray = line.Split(' ');
                string result = FindSum(int.Parse(stringArray[0]), int.Parse(stringArray[1]));
                streamwriter.WriteLine(result);
                Console.WriteLine(result);
            }
        }
    }
}
