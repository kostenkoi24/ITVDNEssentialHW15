using System;
using System.Collections;

namespace Homework15_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Price[] prices = new Price[2];

            InputPrices(prices);

            ShowPrices(prices);

            string userInput = "";

            do
            {
                Console.WriteLine("Введите название магазина для поиска (type 'exite' for exite):");

                userInput = Console.ReadLine().ToLower();

                try
                {
                    Price[] price = Array.FindAll(prices, element => element.shop.ToLower() == userInput);

                    if (price.Length > 0)
                    {
                        ShowPrices(price);
                    }
                    else
                    {
                        throw new UserException();
                    }
                }
                catch(UserException e)
                {
                    e.Method();
                }
                finally
                {
                    Console.WriteLine("Попробуйте еще раз.");
                }

            } while (userInput != "exite");



            

            Console.ReadKey();

        }


        static void InputPrices(Price[] prices)
        {
            for (int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine($"Введите продукт: ");
                prices[i].product = Console.ReadLine();

                Console.WriteLine($"Введите магазин: ");
                prices[i].shop = Console.ReadLine();

                bool error = false;

                do
                {
                    Console.WriteLine($"Введите стоимость: ");

                    string userInput = Console.ReadLine();

                    try
                    {
                        
                        prices[i].cost = double.Parse(userInput);
                        error = false;
                    }
                    catch (Exception e)
                    {
                        error = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Вы ввели не корректный формат даты {userInput} - {e.Message}");
                        Console.ResetColor();
                    }
                }
                while (error);


            }

            Array.Sort(prices, new PricesComparer());

        }


        static void ShowPrices(Price[] prices)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{new string('-', 15)} Ваши магазины и товары {new string('-', 15)}");
            foreach (Price price in prices)
            {
                Console.WriteLine($"Магазин: {price.shop} ");
                Console.WriteLine($"Товар: {price.product}");
                Console.WriteLine($"Стоимость: {price.cost} ");
            }
            Console.ResetColor();
        }
    }

    class PricesComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(((Price)x).shop, ((Price)y).shop);
        }
    }


    class UserException : Exception
    {
        public void Method()
        {
            Console.WriteLine("Магазин не найден!");
        }
    }
}
