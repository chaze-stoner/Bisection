using System;
using System.Threading;
using System.Collections.Generic;

namespace Bisection
{
    class Program
    {
        static List<int> list = new List<int>();
        static List<int> counter = new List<int>();
        static List<int> list2 = new List<int>();
        static List<int> counter2 = new List<int>();
        static void Main()
        {
            Title();
            MainMenu();
        }

        /*******************************************************
         * used to rummage through an array of 10 numbers and
         * allows the computer to figure out if your number was 
         * between 1 and 10.
         *******************************************************/
        static void Bisection_Method(int[] list, int? input)
        {
            int start = list[0];
            int end = list[list.Length - 1];
            int middle = (start + end) / 2;

            String s;

            do
            {
                if (input == middle) { s = $"Your number is: {middle}\n"; CenterText(s); break; }
                if (input > middle) { start = middle + 1; s = $"Your number is larger than: {start}\n"; CenterText(s); }
                if (input < middle) { end = middle - 1; s = $"Your number is smaller than: {end}\n"; CenterText(s); }

                middle = (start + end) / 2;

            }
            while (true);
        }

        /***************************
         * Part One of the exercise
         ***************************/
        static void ImplementBisectionAlg()
        {
            Console.Clear();
            string s;
            int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            s = "Please input a number from 1 - 10\n";
            CenterText(s);
            int? input = 0;
            try
            {
                CWrite(" ");
                input = Convert.ToInt32(Console.ReadLine());
                if (input < 0 || input > 10)
                {
                    s = "Please input a number between 1 and 10\n";
                    CenterText(s);
                    s = "Press ENTER to to return to the main menu\n";
                    CenterText(s);
                    Console.ReadLine();
                    Console.Clear();

                    ImplementBisectionAlg();
                }
            }
            catch (FormatException) { ImplementBisectionAlg(); }

            Bisection_Method(list, input);

            Thread.Sleep(2000);

            MainMenu();
        }

        /*********************************
         * Human player guess what number
         * the computer picked.
         *********************************/
        static void HumanPlays()
        {

            string s;
            Random r = new Random();
            int cn = r.Next(1, 1001);

            int i = 0;
            do
            {
                Console.Clear();

                s = "please input a number from 1 - 1000\n";
                CenterText(s);
                int? input = 0;
                try
                {
                    CWrite(" ");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input < 0 || input > 1000)
                    {
                        s = "Please input a number between 1 and 10!\n";
                        CenterText(s);
                        s = "Press ENTER to to return to the main menu.\n";
                        CenterText(s);
                        Console.Clear();

                        HumanPlays();
                    }
                }
                catch (FormatException) { HumanPlays(); }

                if (input > cn)
                {
                    s = $"The number is smaller than: {input}\n";
                    CenterText(s);
                    s = "Press Enter to Try again\n";
                    CenterText(s);
                    Console.ReadLine();
                }
                if (input < cn)
                {
                    s = $"The number is larger than: {input}\n";
                    CenterText(s);
                    s = "Press Enter to Try again";
                    CenterText(s);
                    Console.ReadLine();
                }
                if (input == cn)
                {
                    list.Add(i);
                    counter.Add(1);
                    s = $"Correct, the number is: {input} and it took you {i} turns\n";
                    CenterText(s);
                    s = $"The average number of trys is {CountList(list) / counter.Count}\n";
                    CenterText(s);
                    Console.ReadLine();
                    break;
                }
                i++;
            }
            while (true);

            Thread.Sleep(2000);

            MainMenu();
        }

        /*********************************
         * Computer player guess what number
         * the human picked.
         *********************************/
        static void ComputerPlayers()
        {
            Console.Clear();

            Random r = new Random();
            int low = 1;
            int high = 101;

            string s = "Please input a number between 1 and 100";
            CenterText(s);
            Console.WriteLine();

            int hn = 0;
            try
            {
                CWrite("");
                hn = Convert.ToInt32(Console.ReadLine());
                if (hn < 0 || hn > 100)
                {
                    CenterText(s);
                    Console.WriteLine();
                    s = "Press ENTER to to return to the main menu.";
                    CenterText(s);
                    Console.ReadLine();
                    Console.Clear();

                    ComputerPlayers();
                }
            }
            catch (FormatException) { ComputerPlayers(); }

            int i = 0;
            do
            {
                Console.Clear();

                int cn = r.Next(low, high);

                //if (i == 0) { cn = 50; }

                if (cn == hn)
                {
                    list2.Add(i);
                    counter2.Add(1);
                    s = $"The computer has guessed the number {cn} in {i} turns\n";
                    CenterText(s);
                    s = $"The average number of tries is {CountList(list2) / counter2.Count}\n";
                    CenterText(s);
                    s = "Press ENTER to continue";
                    CenterText(s);
                    Console.ReadLine();
                    break;
                }

                s = $"The computer picks {cn}\n";
                CenterText(s);

                s = $"Enter 1 if the computers number is lower than the number you put in\n";
                CRLCT(s);
                s = $"Enter 2 if the computers number is higher than the number you put in\n";
                CRLCT(s);
                CWrite("");
                string input = Console.ReadLine().ToLower();

                if (input == "1") { low = cn + 1; }
                if (input == "2") { high = cn - 1; }
                if (low == high) { low = 1; high = 101; }

                i++;
            }
            while (true);

            MainMenu();
        }

        /*********************************
         * Used to sum a lits of ints
         *********************************/
        static int CountList(List<int> list)
        {
            int av = 0;
            foreach (int i in list)
            {
                av += i;
            }
            return av;
        }

        static void Title()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.Title = "BISECTION";
            Console.WindowWidth = 80;
            Console.WindowHeight = 20;

            String s;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            s = "@@@@@@@  @@@  @@@@@@ @@@@@@@@  @@@@@@@ @@@@@@@ @@@  @@@@@@  @@@  @@@";
            CenterText(s);
            Console.WriteLine();
            s = "@@!  @@@ @@! !@@     @@!      !@@        @!!   @@! @@!  @@@ @@!@!@@@";
            CenterText(s);
            Console.WriteLine();
            s = "@!@!@!@  !!@  !@@!!  @!!!:!   !@!        @!!   !!@ @!@  !@! @!@@!!@!";
            CenterText(s);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            s = "!!:  !!! !!:     !:! !!:      :!!        !!:   !!: !!:  !!! !!:  !!!";
            CenterText(s);
            Console.WriteLine();
            s = ":: : ::  :   ::.: :  : :: ::   :: :: :    :    :    : :. :  ::    : ";
            CenterText(s);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            s = "PRESS ENTER TO CONTINUE";
            CenterText(s);
            Console.ReadLine();

        }

        static void TypeWrite(string str)
        {
            foreach (var i in str)
            {
                Console.Write(i.ToString());
                Thread.Sleep(15);
            }
        }
        static void CenterText(string s)
        {
            TypeWrite((String.Format("{0," + ((Console.WindowWidth / 2) + (s.Length / 2)) + "}", s)));
        }
        static void CRLCT(string s)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (s.Length / 2)) + "}", s));
        }
        static void CWrite(string s)
        {
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + (s.Length / 2)) + "}", s));
        }

        static void MainMenu()
            {
                Console.Clear();

                string s;

                s = "Press 1 for ImplementBisectionAlg\n";
                CRLCT(s);
                s = "Press 2 for Human Input\n";
                CRLCT(s);
                s = "Press 3 for Computer Input\n";
                CRLCT(s);
                s = "To Exit the application\n";
                CRLCT(s);

                ConsoleKeyInfo input = Console.ReadKey();
                if (input.Key == ConsoleKey.D1)
                {
                    ImplementBisectionAlg();
                }
                if (input.Key == ConsoleKey.D2)
                {
                    HumanPlays();
                }
                if (input.Key == ConsoleKey.D3)
                {
                    ComputerPlayers();

                }
                if (input.Key == ConsoleKey.D4)
                {
                    s = "Thanks for Playing with Bisection...";
                    CRLCT(s);
                    Environment.Exit(1);
                }
                else MainMenu();
            }
        
    }
}
