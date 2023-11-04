using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*     1.В С # индексация начинается с нуля, но в некоторых языках программирования это не так.
                     Например, в Turbo Pascal индексация массиве начинается с 1. Напишите класс RangeOfArray, 
                     который позволяет работать с массивом такого типа,
                     в котором индексный диапазон устанавливается пользователем. Например, в диапазоне от 6 до 10, или от –9 до 15.*/


            Console.Write("Введите начальный индекс ");
            int startIndex=Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите конечный индекс ");
            int endIndex = Convert.ToInt32(Console.ReadLine());
            RangeOfArray arr = new RangeOfArray(startIndex, endIndex);

            for (int i = startIndex; i <= endIndex; i++)
            {
                arr[i] = i;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.WriteLine($"arr[{i}] = {arr[i]}");
            }
            Console.WriteLine("");

            /*  2.Написать программу «Продуктовый супермаркет»: выбирается ряд продуктов, рассчитывается
                 их сумма с учетом скидки в 5 % (скидка предоставляется, если покупка сделана с 8.00 до 12.00 по текущему времени) */


            /* ShoppingCart cart = new ShoppingCart();
             cart.showproducts();
             // Ввод продуктов и их количество

             Console.WriteLine("Введите продукт и количество (например, Хлеб):");
             string input = Console.ReadLine();
             Console.WriteLine("Введите количество продуктов ");
             int quantity = Convert.ToInt32(Console.ReadLine());
             while (!string.IsNullOrEmpty(input))
             {
                 string productName = input;
                 cart.AddToCart(productName, quantity);
                 Console.WriteLine("Добавить продукт если да {1}, нет {2}");
                 int add=Convert.ToInt32(Console.ReadLine());
                 if (add == 1)
                 {
                     input = Console.ReadLine();
                     quantity = Convert.ToInt32(Console.ReadLine());
                 }
                 else if (add == 2)
                 {
                     Console.WriteLine("");
                     break;
                 }
             }
             // Рассчет и вывод информации
             string applyDiscountInput = Console.ReadLine();
             cart.CalculateTotal();*/


            var cart = new ShoppingCart();
            cart.AddToCart("Хлеб", 2); // Добавление двух хлебов
            cart.AddToCart("Молоко", 3); // Добавление трех бутылок молока

            // Рассчет суммы с учетом скидки и вывод
            cart.CalculateTotal();



            /*3.	В файле хранится информация об объеме продаж товара за пять последних месяцев.
             * С помощью метода наименьших квадратов спрогнозировать объемы продаж на следующие три месяца.
             * В качестве линии тренда выбрать линейную функцию.*/

            double[] salesData = { 100, 120, 130, 140, 150 }; // Пример данных о продажах за пять месяцев

            SalesForecast salesForecast = new SalesForecast(salesData);

            Console.WriteLine("Введите количество месяцев для прогноза:");
            int futureMonths = int.Parse(Console.ReadLine());

            double[] forecast = salesForecast.LinearRegression(futureMonths);

            Console.WriteLine("Прогноз объемов продаж на следующие " + futureMonths + " месяцев:");

            for (int i = 0; i < futureMonths; i++)
            {
                Console.WriteLine("Месяц " + (salesData.Length + i + 1) + ": " + forecast[i]);
            }


            // Возможности индексатора 
            // ндексатор позволяет удобно обращаться к данным о продажах по месяцам в объекте класса SalesForecast.
            salesForecast[2] = 135;
        }
    }
}
