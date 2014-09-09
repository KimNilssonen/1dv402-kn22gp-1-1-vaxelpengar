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
            // 1. Skapa variabler.

            double totalSum;
            double roundOff;
            uint subTotal;
            uint paid = 0;
            uint back;


            // 2. Efterfråga totalsumma och erhållet belopp.

            // While-loop för att kunna skriva om vid fel inmatning.
            while (true)
            {
                try // Try använder jag för att kunna använda en catch som tar hand om fel vid inmatning, exempel om man skriver bokstäver istället för siffor.
                {
                    Console.Write("Ange totalsumma      : ");
                    totalSum = double.Parse(Console.ReadLine());
                    if (totalSum < 1) // En if-sats som kollar om värdet är mindre än 1. Skulle detta stämma så stänger programmet.
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Totalsumman är för liten, måste vara mer än 1!\n");
                        Console.ResetColor();
                        return;
                    }
                    break; // Bryter ut ut loopen om inga fel påträffats.
                }
                catch      // Fångar upp eventuella fel vid inmatning som jag nämnde tidigare. Om detta händer så börjar loopen om.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel format, endast siffror är tillåtna!\n");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Ange erhållet belopp : ");
                    paid = uint.Parse(Console.ReadLine());

                    if (paid < totalSum)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Det betalade beloppet är för lite, köpet kunde inte genomföras!\n");
                        Console.ResetColor();
                        return;
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel Format, endast siffror är tillåtna!\n");
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det betalade beloppet är för stort eller negativt. Försök igen.\n");
                    Console.ResetColor();
                }
            }


            // 3. Skapa kvitto, här görs uträkningar och öresavrundning.

            // Avrundningsformeln. (MidpointRounding.AwayFromZero gör att mitten (0,5) drar sig från nollan istället för mot. Dvs det avrundas numera uppåt.
            subTotal = (uint)Math.Round(totalSum, MidpointRounding.AwayFromZero);
            roundOff = totalSum - subTotal;

            // Beräknar hur mycket köparen får tillbaka.
            back = paid - (uint)subTotal;



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



            // 4. Presentera sedlar och mynt.

            //Ger alla lappar och kronor en riktig identifierare, istället för att hårdkoda in alla summor senare.
            uint fiveHundreds = 500;
            uint hundreds = 100;
            uint fifties = 50;
            uint twenties = 20;
            uint tens = 10;
            uint fives = 5;
            uint ones = 1;

            //500
            Console.ForegroundColor = ConsoleColor.Green;
            uint temp = 0;                                              // Gör en temporär uint som kan hålla talet efter dividering.
            temp = back / fiveHundreds;                                 // Temp får värdet efter divideringen. Ex, 1200/500=2. Resterande av detta är 200.
            back = back % fiveHundreds;                                 // Back får resterande dvs, 200.
            if (temp > 0)                                               // Back används sedan med sitt nya värde i resterande uträkningar.
            {
                Console.WriteLine("500 - lappar         :{0}\n", temp);
            }

            //100
            temp = back / hundreds;
            back = back % hundreds;
            if (temp > 0)
            {
                Console.WriteLine("100 - lappar         :{0}\n", temp);
            }

            //50
            temp = back / fifties;
            back = back % fifties;
            if (temp > 0)
            {
                Console.WriteLine("50  - lappar         :{0}\n", temp);
            }

            //20
            temp = back / twenties;
            back = back % twenties;
            if (temp > 0)
            {
                Console.WriteLine("20  - lappar         :{0}\n", temp);
            }

            //10
            temp = back / tens;
            back = back % tens;
            if (temp > 0)
            {
                Console.WriteLine("10  - lappar         :{0}\n", temp);
            }

            //5
            temp = back / fives;
            back = back % fives;
            if (temp > 0)
            {
                Console.WriteLine("5   - kronor         :{0}\n", temp);
            }

            //1
            temp = back / ones;
            back = back % ones;
            if (temp > 0)
            {
                Console.WriteLine("1   - kronor         :{0}\n", temp);
            }
            Console.ResetColor();
        }
    }
}