using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T28MATIKKAPELI
{
    class Program
    {
        /*Ohjelma kysyy toistuvasti peruslaskujen laskutoimituksia. Ohjelma arpoo luvut, käyttäjän on pystyttävä ohjaamaan mitä laskuja lasketaan, voiko vastaus olla negatiivinen, 
         onko luvut vain kokonaislukuja, onko osamäärät vain kokonaislukuja. Oikeasta vastauksesta käyttäjä saa palkinnon, ne ilmoitetaan käyttäjälle ajoittain.
         Ohjelmaa voi kehittää toistamaan väärin menneet laskut.*/

        //Aliohjelma pluslaskuille
        public static int PlusCalc()
        {
            int num1, num2, sum;

            Random rnd = new Random();
            num1 = rnd.Next(1, 100);
            num2 = rnd.Next(1, 100);

            sum = num1 + num2;

            Console.WriteLine(num1+ " + "+num2+ " = ");
            Console.WriteLine("Ilmoita vastauksesi: ");

            return sum;
        }

        //aliohjelma miinuslaskuille
        public static int MinusCalc()
        {
            int num1, num2, minus;
            Random rnd = new Random();
            num1 = rnd.Next(1, 100);
            num2 = rnd.Next(1, 100);           
            minus = num1 - num2;
            

             Console.WriteLine(num1 + " - " +num2+ " = ");


            return minus;
        }

        //aliohjelma kertolaskuille
        public static int MultiplCalc()
        {
            int num1, num2, multipl;
            Random rnd = new Random();
            num1 = rnd.Next(1, 10);
            num2 = rnd.Next(1, 10);
            multipl = num1 * num2;

            Console.WriteLine(num1+ " * " +num2+ " = ");

            return multipl;
        }

        //aliohjelma jakolaskuille//kokeile math.round pyöristystä
        public static double DivisionCalc()
        {
            int choice;
            double num1, num2, div;

            Random rnd = new Random();
            num1 = rnd.Next(1, 10);
            num2 = rnd.Next(1, 10);

            div = num1 / num2;
            div = Math.Round(div, 1);//Näyttää vastauksen yhden desimaalin tarkkuudella.

            Console.WriteLine("Pyöristetäänkö murtoluvut kokonaisluvuiksi?\nDesimaali erotetaan pilkulla. \n1 kyllä \n2 ei");
            choice = int.Parse(Console.ReadLine());
            Console.Clear();

            if(choice == 1)
            {
                Console.WriteLine(num1 + " / " + num2 + " = ");//kokonaislukuja.
                div = Convert.ToInt32(div);
            }

            else
            {
                Console.WriteLine(num1 + " / " + num2 + " = ");//murtoluku vastauksille.
            }

            return div;
        }

        //aliohjelma jossa verrataan laskutoimitusta ja käyttäjän antamaa arvoa.
        private static void Compare(double answr1, double answr2, ref List<int> points, ref int pointCount)
        {           
            if (answr1 == answr2)
            {
                Console.WriteLine("\nHiphei, oikein meni, saat pisteen!!");
                points.Add(1);
                pointCount = points.Count();
                Console.WriteLine("Sinulla on nyt " + pointCount + " piste(ttä)!!");
            }

            else
            {
                Console.WriteLine("\nOlen pahoillani, vastaus on väärä.");
                Console.WriteLine("Sinulla on nyt " + pointCount + " piste(ttä)!!");
            }
        }

        static void Main(string[] args)
        {
            //muuttujat
            int plusC, minusC, multiplC, num1=0, answer, pointCount=0;
            double divC, answer2;  
            List<int> points = new List<int>();

            //käyttäjän tervehtiminen
            Console.WriteLine("\n-------- --------- --------- --------- ---------\n");
            Console.WriteLine(" ----Heikunkeikun tervetuloa matikkapeliin----");
            Console.WriteLine("\n-------- --------- --------- --------- ---------\n");

            try
            {
                //Käyttäjä valitsee mitä haluaa tehdä, laskun valinta toistuu niin monta kertaa kun num1 muuttujan arvo on jokin muu kuin viisi.
                while (num1 != 5)
                {
                    Console.WriteLine("\nIlmoita millaisia laskutoimitusta haluat harjoitella");
                    Console.WriteLine("1 plus \n2 miinus \n3 kerto \n4 jako \n5 poistu");

                    num1 = int.Parse(Console.ReadLine());//käyttäjä antaa numron
                    Console.Clear();

                    if(num1 == 1)
                    {
                        plusC = PlusCalc();
                        answer = int.Parse(Console.ReadLine());
                        Compare(answer, plusC, ref points, ref pointCount);
                    }

                    else if(num1 == 2)
                    {
                        minusC = MinusCalc();
                        answer = int.Parse(Console.ReadLine());
                        Compare(answer, minusC, ref points, ref pointCount);
                    }

                    else if(num1 == 3)
                    {
                        multiplC = MultiplCalc();
                        answer = int.Parse(Console.ReadLine());
                        Compare(answer, multiplC, ref points, ref pointCount);
                    }

                    else if(num1 == 4)
                    {
                        divC = DivisionCalc();
                        answer2 = double.Parse(Console.ReadLine());
                        Compare(answer2, divC, ref points, ref pointCount);
                    }


                    Console.ReadKey();
                    Console.Clear();
                }
                                                         
            }

            catch (FormatException)
            {
                Console.WriteLine("Virheellinen syöte, koitappa joskus toiste uudelleen.");
            }

            catch(DivideByZeroException)
            {

                Console.WriteLine("Koitettiin jakaa nollalla, ei onnistuu. :(");
            }

            finally
            {
                //Ohjelma sulkeutuu
                Console.WriteLine("Kivakiva kiitos kun pelasit, heipp");
                Console.ReadLine();
            }
        }
    }
}
