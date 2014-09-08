using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Change
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skapa variabler.
            double totalSum;
            double subTotal;
            double roundOff;

            int paid;
            int back;

                     
            // Efterfråga totalsumma och erhållet belopp. 
            Console.Write("Ange totalsumma      : ");
            totalSum = double.Parse(Console.ReadLine());

            Console.Write("Ange erhållet belopp : ");
            paid = int.Parse(Console.ReadLine());

                if(paid<totalSum)
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Det betalade beloppet är för lite!\n");
                Console.ResetColor();
                    return;
                }
             

            // Skapa kvitto, här görs uträkningar och öresavrundning.
            subTotal = (uint)Math.Round(totalSum, MidpointRounding.AwayFromZero);
            roundOff = totalSum - subTotal;

            // Beräknar hur mycket köparen får tillbaka.
            back = paid - (int)subTotal;



            // Presentera kvitto.
            Console.WriteLine();
            Console.WriteLine("KVITTO");
            Console.WriteLine("----------------------------------\n");
            Console.WriteLine(String.Format("Totalt            :{0,15:c}", totalSum)); // Totalt man betalt från början.
            Console.WriteLine(String.Format("Öresavrunding     :{0,15:c}", roundOff)); // Avrundningen, vilket ger en ny totalsumma att betala.
            Console.WriteLine(String.Format("Att betala        :{0,15:c}", subTotal)); // Den nya totalsumman.
            Console.WriteLine(String.Format("Kontant           :{0,15:c}", paid));     // Det betalade beloppet.
            Console.WriteLine(String.Format("Tillbaka          :{0,15:c}\n", back));   // Beloppet du får tillbaka.
            Console.WriteLine("----------------------------------\n");

            //String.Format är till för att höger eller vänsterjustera text. Ex {0,10} ger högerjusterat, minusvärde på tian ger istället vänsterjusterat.
            //Jag hittade denna infon här: http://www.csharp-examples.net/align-string-with-spaces/


            // Presentera sedlar och mynt.
            int fiveHundreds = 500;
            int hundreds = 100;
            int fifties = 50;
            int twenties = 20;
            int tens = 10;
            int fives = 5;
            int ones = 1;
             

            //500
            int temp = 0;                                           // Gör en temporär int som kan hålla talet efter dividering.
            temp = back / fiveHundreds;
            back = back % fiveHundreds;                             //Ger antalet femhundralappar. Denna formeln återanvänds för resterande sedlar och mynt.
            if (temp > 0)
            {
                Console.WriteLine("500 - lappar         :{0}", temp);
            }

                //100
                temp = back / hundreds;
                back = back % hundreds;
                if (temp > 0)
                {
                    Console.WriteLine("100 - lappar         :{0}", temp);
                }

                    //50
                    temp = back / fifties;
                    back = back % fifties;
                    if (temp > 0)
                    {
                        Console.WriteLine("50  - lappar         :{0}", temp);
                    }

                        //20
                        temp = back / twenties;
                        back = back % twenties;
                        if (temp > 0)
                        {
                            Console.WriteLine("20  - lappar         :{0}", temp);
                        }
                            
                            //10
                            temp = back / tens;
                            back = back % tens;
                            if (temp > 0)
                            {
                                    Console.WriteLine("10  - lappar         :{0}", temp);
                            }

                                //5
                                temp = back / fives;
                                back = back % fives;
                                if (temp > 0)
                                {
                                    Console.WriteLine("5   - kronor         :{0}", temp);
                                }

                                    //1
                                    temp = back / ones;
                                    back = back % ones;
                                    if (temp > 0)
                                    {
                                        Console.WriteLine("1   - kronor         :{0}", temp);
                                    }

        }
    }
}
