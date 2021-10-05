using System;

namespace Project_A
{
    class Program
    {

        

        static void Main(string[] args)
        {


            string[] mixedArticles = new string[2];
            int[] price = new int[2];
            mixedArticles = Console.ReadLine().Split(';');

            for (int i = 0; i < 6; i++)
            {
                if (i % 2 != 0)
                    Int32.TryParse(mixedArticles[i], out price[i]);

                Console.WriteLine(price[i]);

            }

            //0,1,2,3,4,5,6




            Console.WriteLine(mixedArticles[0]);
            Console.WriteLine(mixedArticles[1]);
            Console.WriteLine(price);




            Console.Title = "Project A";
            Console.WriteLine("Let's print a receipt");


            Articles.InputArticles();


            for (int i = 0; i < Articles.numberOfArticles; i++)
            {

                Console.WriteLine($"Write the name and the price for article #{i}");
                Articles.mixedArticles = Console.ReadLine().Split(';');

                Console.WriteLine(Articles.mixedArticles[0]) ;
               


            }


        }

        class Articles
        {
            public static int numberOfArticles;
            public static double[] articlePrices = new double[numberOfArticles];
            public static string[] articelNames = new string[numberOfArticles];
            public static string[] mixedArticles = new string[numberOfArticles];

            public static void InputArticles()
            {

                Console.WriteLine("How many articles do you want? (From 1 to 10)");
                numberOfArticles = Convert.ToInt32(Console.ReadLine());

            }

           
        
                
                
            
      
            
        
        }
    }


    
}

/*
 
 
 
 


           
            int numberOfArticles = 0;

            int[] articlePrices = new int [numberOfArticles];
            string[] articelNames = new string[numberOfArticles];
            

            Console.WriteLine("How many articles do you want? (From 1 to 10)");
            numberOfArticles = Convert.ToInt32(Console.ReadLine());
            
            do
            {
               int i = 0; 
               Console.WriteLine($"Write the name and the price for article #{i}" );
               articles = Console.ReadLine();
                
                i++;

                if(articles.Item1 == "" ){ }

            } while (0 < numberOfArticles);
 
 
 
 */
