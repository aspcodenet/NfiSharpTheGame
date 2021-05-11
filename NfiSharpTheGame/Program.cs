using System;

namespace NfiSharpTheGame
{
    class Program
    {

        static void Main(string[] args)
        {
            //
            Random oRand = new Random();  
            // oRand.Next(1,100) kommer ge ett  SLUMPTAL mellan 1 och 100

            //Spelet   :
            //Visa huvudmeny
            //  Välj vad du vill göra (1=Spela, 2=Se highscore, 0=exit) 
            //Om 0 så avslutas spelet
            //--- DVS - While input <> 0 

            while (true)
            {
                Console.WriteLine("1=Spela");
                Console.WriteLine("2=Highscore");
                Console.WriteLine("0=Avsluta");
                int sel = Convert.ToInt32(Console.ReadLine());
                if (sel == 1)
                {
                    int secretTal = oRand.Next(1, 100);
                    Console.WriteLine("Jag tänker på ett tal mellan 1 och 100. Gissa vilket:");
                    while (true)
                    {
                        int gissning = Convert.ToInt32(Console.ReadLine());
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


                }
                if (sel == 2)
                {
                    Console.WriteLine("Visa highscore");
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
