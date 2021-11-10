using System;

namespace Project_A
{
    struct Articles
    {
        public static int numberOfArticles;
        public decimal price;
        public string name;

    }

    class Program
    {
        
        static Articles[] articles = new Articles[Articles.numberOfArticles];
        const decimal vat = 0.25M;
        static int k = 0;

        public static void Main(string[] args)
        {

            Console.Title = "Project A";
            Console.WriteLine("Welcome to Project A \nLet's print a receipt");
            int i = 0;
            bool result = false;

            while (!result) //Loops untill the right value is entered
            {
                Console.WriteLine("How many articles do you want? (From 1 to 10): ");
                result = NrOfArticles();

                if (!result)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input, try again! Only numbers.");
                    Console.ForegroundColor = ConsoleColor.White;


                }

            }


            while (i < Articles.numberOfArticles)
            {

                Console.WriteLine($"Enter name and price for article #{i}. In the format name; price (example Beer; 2,25): ");
                result = ReadArticle();

                if (result)
                {
                    i++;
                }

            } 

            PrintReciept();


        }


    #region methods

        public static bool NrOfArticles()
        {
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out int nrOfArticles);

            if (result && nrOfArticles != 0 && nrOfArticles <= 10)
            {
                Articles.numberOfArticles = nrOfArticles;
                return true; 
            }

            return false; 
        }

        
        public static bool ReadArticle()
        {
            string[][] input = new string[Articles.numberOfArticles][];
            string userInput = Console.ReadLine();
            if (!userInput.Contains(';'))
            {
                Console.WriteLine("Use ;");
                return false;
            }

            input[k] = userInput.Split(';');


            string name = input[k][0];
            decimal price = 0;
                
            bool stringIsNumber = int.TryParse(name, out int number0);
            bool decimalIsANumber = decimal.TryParse(input[k][1], out price);

            if (stringIsNumber)
                Console.Clear(); Console.WriteLine("Name cannot be number");

            if (string.IsNullOrWhiteSpace(name))
                Console.Clear(); Console.WriteLine("Name cannot be whitespace");

            if (string.IsNullOrEmpty(name))
                Console.Clear(); Console.WriteLine("name cannot be empty");

            if (!decimalIsANumber)
                Console.Clear(); Console.WriteLine("price must be a number");


            if (decimalIsANumber && price != 0 && !stringIsNumber && !string.IsNullOrEmpty(name))
            {
                articles[k].name = name;
                articles[k].price = price;
                k++;
                return true;

            }

            return false; 

        }

        public static void PrintReciept()
        {
            decimal totalPrice = 0;
            decimal tax;

            Console.WriteLine($"Number of items purchased: {Articles.numberOfArticles}");

            Console.WriteLine("{0,-20} {1,14} {2,18}", "#", "Name", "Price");

            for (int i = 0; i < articles.Length; i++)
            {
                Console.WriteLine($"{i,-30} {articles[i].name} {articles[i].price,20:c}");
                totalPrice += articles[i].price;
            }

            tax = totalPrice * vat;

            Console.WriteLine();
            Console.WriteLine("{0,-35} {1,20}", "Total purchase", $"{totalPrice:c}");
            Console.WriteLine("{0,-35} {1,20}", "Includes VAT (25%):", $"{ tax:c}");

        }
        
     #endregion methods



    }



}

