using System;
using System.Collections.Generic;

namespace Generic_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //aight så dessa är cringe men jag kunde inte komma på något annat som skulle funka med min fina copy paste selection thingy. Du vet vilken.
            string[] cringeMan = { "Hello. ", "Hiya! ", "Wassup! " };
            string[] cringeMan2 = { "My name is ", "I'm ", "This G be called " };
            string[] cringeMan3 = { "Gunfrid.", "Gunnar.", "Gunhild." };
            Queue<string> queue = new Queue<string>();
            string[][] possLines = new string[3][];//så d3enna grabben lagrar array i array yippie hippie
            possLines[0] = cringeMan;
            possLines[1] = cringeMan2;
            possLines[2] = cringeMan3;
            //denna är en bastard child
            //den låter mig inte göra possLines[0] = {"","",""}; av oförklarad anledning
            //därav cringe

            for (int i = 0; i < possLines.GetLength(0); i++)    //så vi loopar igenom arrayen och låter användaren välja vilken line som enqueueas. hip hurra för fria val.
            {
                queue.Enqueue(Selection(possLines[i]));
                Console.Clear();
            }
            string line="";
            while (queue.Count > 0)
            {
                line += queue.Dequeue(); //sen slammmar vi in valen i strängen line hårdare än the undertaker kastade mankind från toppen av the hell in a cell den 28:e juni 1998 
            }

            System.Console.WriteLine(line);
            Console.ReadLine();

        }


        //you know the usual shebang
        static void PrintChoices(string[] choices, int current)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                if (current == i)
                {
                    System.Console.WriteLine($">  {choices[i]}");
                }
                else
                {
                    System.Console.WriteLine($"  {choices[i]} ");
                }
            }
        }
        static string Selection(string[] choices)
        {
            int current = 0;
            while (true)
            {
                Console.Clear();
                PrintChoices(choices, current);
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        {
                            current++;
                            current = current % choices.Length;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            current--;
                            if (current < 0) { current = choices.Length - 1; }
                            else
                            {
                                current = Math.Abs(current % choices.Length); //This now works properly
                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            return choices[current];
                        }
                    default:
                        {
                            // handle everything else
                        }
                        break;
                }
            }
        }
    }
}