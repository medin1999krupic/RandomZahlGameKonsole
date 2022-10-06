using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateSpielConsole
{
    class Program
    {
        public static int GeneratedNumber { get; set; }
        public static int Versuche { get; set; }
        public static bool GameStarted { get; set; }
        public static bool Gewonnen { get; set; }

        static void Main(string[] args)
        {
            //String start = "START";


            ShowCommands();
            string frage = "";
            while((frage = Console.ReadLine().ToUpper()) != "EXIT")
            {
                if (frage.ToUpper() == "START")
                {
                    if(!GameStarted)
                        StartGame();

                    while(GameStarted)
                    {
                        Console.WriteLine("Gebe eine Zahl ein von 1 - 100.");
                        string eigegebeneZahlstr = Console.ReadLine();
                        int zahl;
                        bool isValidNumber = int.TryParse(eigegebeneZahlstr, out zahl);
                        if(isValidNumber)
                        {
                            ErgebnisAuswerten(zahl);
                            Versuche = Versuche - 1;
                        }
                           
                        else
                        {
                            
                            if (eigegebeneZahlstr.ToUpper() == "EXIT")
                            {
                                ExitGame();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Bitte geben Sie eine gültige Zahl ein.");
                            }
                        }

                        if(Versuche == 0 && !Gewonnen)
                        {
                            Console.WriteLine("Du hast verloren.");
                            GameStarted = false;
                            ShowCommands();
                        }

                        if(Gewonnen)
                        {
                            ShowCommands();
                        }
                    }
                }
                else
                {
                    ShowCommands();
                }

            }

            ExitGame();
            

        }

        private static void ShowCommands()
        {
            Console.WriteLine("Starte das Spiel indem du START schreibst.");
            Console.WriteLine("Drücke EXIT um das Spiel zu Beenden.");
        }

        private static void ExitGame()
        {
            Console.WriteLine("Das Spiel wird beendet!!!");
            Console.ReadLine();
        }

        private static void ErgebnisAuswerten(int zahl)
        {
            if (zahl == GeneratedNumber)
            {
                Console.WriteLine("Gewonnen");
                GameStarted = false;
                Gewonnen = true;
            }
            else if (zahl > GeneratedNumber)
            {
                Console.WriteLine("Zahl ist zu groß");
            }
            else
            {
                Console.WriteLine("Zahl ist zu klein");
            }
        }

        private static void StartGame()
        {
            //beginnt das spiel
            Console.WriteLine("Du bist im Spiel.");
            //string frage1 = Console.ReadLine();
            Console.WriteLine("Zahl wird Generiert ...");
            int num = new Random().Next(0, 100);
            GeneratedNumber = num;
            Versuche = 3;
            GameStarted = true;
        }
    }
}
