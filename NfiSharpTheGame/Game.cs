using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace NfiSharpTheGame
{
    public class Game
    {
        public void RitaHuvudmeny()
        {
            Console.WriteLine("1=Spela");
            Console.WriteLine("2=Highscore");
            Console.WriteLine("0=Avsluta");
        }

        public int RunGameRound()
        {
            Console.WriteLine("Jag tänker på ett tal mellan 1 och 100. Gissa vilket:");

            Random oRand = new Random();
            int secretTal = oRand.Next(1, 100);
            int antalGissningar = 0;
            while (true)
            {
                int gissning = Convert.ToInt32(Console.ReadLine());
                antalGissningar++;
                if (gissning == secretTal)
                {

                    Console.WriteLine("Hurra! Det var rätt");
                    break;
                }
                else if (gissning < secretTal)
                {
                    Console.WriteLine("Nej! Mitt tal är högre än så");
                }
                else if (gissning > secretTal)
                {
                    Console.WriteLine("Nej! Mitt tal är lägre än så");
                }

            }

            return antalGissningar;
        }

        public List<HighscoreItem> GetFromFile()
        {
            if (System.IO.File.Exists("C:\\Users\\stefa\\Temp\\a.txt"))
            {
                string filecontents =
                    File.ReadAllText("C:\\Users\\stefa\\Temp\\a.txt");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<HighscoreItem>>(filecontents);
            }

            return new List<HighscoreItem>();

        }

        public void SaveToFile(List<HighscoreItem> items)
        {
            string contents = Newtonsoft.Json.JsonConvert.SerializeObject(items);
            System.IO.File.WriteAllText("C:\\Users\\stefa\\Temp\\a.txt",contents);
        }


        public void Run()
        {
            //
            // oRand.Next(1,100) kommer ge ett  SLUMPTAL mellan 1 och 100

            //Spelet   :
            //Visa huvudmeny
            //  Välj vad du vill göra (1=Spela, 2=Se highscore, 0=exit) 
            //Om 0 så avslutas spelet
            //--- DVS - While input <> 0 

            List<HighscoreItem> highscores =  GetFromFile();

            while (true)
            {
                RitaHuvudmeny();
                int sel = Convert.ToInt32(Console.ReadLine());
                if (sel == 1)
                {
                    int antalGissningar = RunGameRound();

                    if (highscores.Count < 5 || antalGissningar < highscores[4].Value)
                    {
                        var item = new HighscoreItem();
                        item.Value = antalGissningar;
                        Console.WriteLine("Du kommer in på highscore!!! Vad heter du:");
                        item.Namn = Console.ReadLine();

                        highscores.Add(item);
                        highscores = highscores.OrderBy(r => r.Value).ToList();
                    }
                    while(highscores.Count > 5)
                        highscores.RemoveAt(5);

                    SaveToFile(highscores);

                    //Kolla om du kommer in på top 5
                    //Frågar vi om namn
                }
                if (sel == 2)
                {
                    Console.WriteLine("Visa highscore");
                    foreach (var antal in highscores)
                    {
                        Console.WriteLine($"{antal.Namn} {antal.Value}");
                    }
                }
                else if (sel == 0)
                {
                    break;
                }
            }


            Console.WriteLine("Kul att du var med och spelade");

        }
    }
}