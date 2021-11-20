using System;

namespace Project_A
{
    class Program
    {
        struct Articles
        {
            public decimal price;
            public string name;
        }

        static int NrOfArticles;
        static Articles[] articles;
        const decimal _vat = 0.25M;
        static int k = 0;

        public static void Main(string[] args)
        {

            Console.Title = "Project A";
            Console.WriteLine("Welcome to Project A \nLet's print a receipt");
            int i = 0;
            bool result = false;

            while (!result)
            {
                Console.WriteLine("How many articles do you want? (From 1 to 10): ");
                result = TryReadNrArticles(out NrOfArticles);

                if (!result)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input, try again! Only numbers.");
                    Console.ForegroundColor = ConsoleColor.White;


                }

                articles = new Articles[NrOfArticles];
                

            }

            while (i < articles.Length)
            {
                Console.WriteLine($"Enter name and price for article #{i}. In the format name; price (example Beer; 2,25): ");
                result = TryReadArticle();

                if (result)
                {
                    i++;
                }
            } 

            PrintReciept();
        }


    #region methods

        public static bool TryReadNrArticles(out int nrArticles)
        {
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out int nrOfArticles);

            if (result && nrOfArticles != 0 && nrOfArticles <= 10)
            {
                nrArticles = nrOfArticles;
                return true; 
            }

            nrArticles = 0;
            return false; 
        }

        
        public static bool TryReadArticle()
        {
            string[][] input = new string[NrOfArticles][];
            string userInput = Console.ReadLine();
            if (!userInput.Contains(';'))
            {
                Console.WriteLine("Format error");
                return false;
            }

            input[k] = userInput.Split(';');

            string name = input[k][0];
            decimal price = 0;
 
            bool stringIsNumber = int.TryParse(name, out int number0);
            bool decimalIsANumber = decimal.TryParse(input[k][1], out price);

            if (stringIsNumber || string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name error");
                return false;
            }


            if (!decimalIsANumber || price == 0)
            {
                Console.WriteLine("Price error");
                return false;
            }

            articles[k].name = name;
            articles[k].price = price;
            k++;
            return true;

        }

        public static void PrintReciept()
        {
            decimal totalPrice = 0;
            decimal vat;

            Console.WriteLine($"Number of items purchased: {NrOfArticles}");

            Console.WriteLine("{0} {1,15} {2,20}", "#", "Name", "Price");

            for (int i = 0; i < articles.Length; i++)
            {
                Console.WriteLine($"{i} {articles[i].name, 15} {articles[i].price,20:c}");
                totalPrice += articles[i].price;
            }

            vat = totalPrice * _vat;

            Console.WriteLine();
            Console.WriteLine("{0} {1,23}", "Total purchase", $"{totalPrice:c}");
            Console.WriteLine("{0} {1,18}", "Includes VAT (25%):", $"{ vat:c}");

        }
        
     #endregion methods



    }



}

