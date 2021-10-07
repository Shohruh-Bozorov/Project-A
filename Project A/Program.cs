using System;

namespace Project_A
{
    class Program
    {

        static void Main(string[] args)
        {
            methods.ChangeConsole();
            string text1 = "How many articles do you want? (From 1 to 10)";
            bool result = false;
            string text2 = "\nWrong input, try again! Only numbers.";
            
            int i = 0;

            do
            {
                Console.WriteLine(text1);
                result = methods.NrOfArticles();
                if (!result) 
                {
                    methods.ChangeFontColor(text2);
                    Console.WriteLine(text2);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                
                }
                    



            } while (result == false);



            Console.WriteLine(result);






        }



        class Articles
        {
            public static int numberOfArticles;

            #region arrays

            public static string[] mixedArticles = new string[numberOfArticles];
            public static double[] articlePrice = new double[numberOfArticles];
            public static string[] articelName = new string[numberOfArticles];

            #endregion arrays







        }

        class methods
        {


            public static bool NrOfArticles()
            {

                bool result = false;
                int nrOfArticles;
                string Input = Console.ReadLine();
                result = int.TryParse(Input, out nrOfArticles);


                if (result && nrOfArticles != 0)
                {
                    Articles.numberOfArticles = nrOfArticles;
                    result = true;

                }
                else return result; // returns false if tryparse failed

                return result; // returns truee if tryparse succeded

            }

            public static void ChangeConsole()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();

                Console.Title = "Project A";
                Console.WriteLine("Let's print a receipt");
            }


            public static string ChangeFontColor(string text)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return text;
                
            }





        }

      





    }


    
}

/*
 
 
 
 


           




            

 
 
 */
