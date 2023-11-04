using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8
{
    public class ShoppingCart
    {
        public ProductCategory ProductCategory { get; }
        public Dictionary<string, int> shoppingCart;

        public ShoppingCart()
        {
            ProductCategory = new ProductCategory();

            // Определение списка продуктов и их цен
            ProductCategory["Хлеб"] = 2.0M;
            ProductCategory["Молоко"] = 1.5M;
            ProductCategory["Яйца"] = 1.2M;
            ProductCategory["Фрукты"] = 3.0M;
            ProductCategory["Овощи"] = 15.0M;

            shoppingCart = new Dictionary<string, int>();
        }
        public void showproducts()
        {
            Console.WriteLine("Все продукты ");
            foreach (var productName in ProductCategory.ProductNames)
            {
                Console.WriteLine(productName);
            }
        }
        public void AddToCart(string productName, int quantity)
        {
            // Добавление продукта в корзину
            if (ProductCategory[productName] > 0) // Проверка наличия продукта в ProductCategory
            {
                shoppingCart[productName] = quantity;
            }
            else
            {
                Console.WriteLine("Продукт не найден.");
            }
        }

        public void CalculateTotal()
        {
            // Рассчет суммы покупки
            decimal totalAmount = 0.0M;

            foreach (var item in shoppingCart)
            {
                totalAmount += ProductCategory[item.Key] * item.Value;
            }

            decimal discount = 0.0M;
            DateTime currentTime = DateTime.Now;
            if (currentTime.Hour == 12)
            {
                if (currentTime.Minute <= 0)
                {
                    discount = 0.05M; // 5% скидка
                    Console.WriteLine("Скидка действует");
                }
            }
            else if (currentTime.Hour > 8 && currentTime.Hour < 12)
            {
                discount = 0.05M; // 5% скидка
                Console.WriteLine("Скидка действует");
            }
            totalAmount -= totalAmount * discount;

            DisplayCartContents();

            Console.WriteLine($"Итого: {totalAmount}");
        }

        // Вывод содержимого корзины
        public void DisplayCartContents()
        {

            Console.WriteLine("Продукты в корзине:");
            foreach (var item in shoppingCart)
            {
                Console.WriteLine($"{item.Key}: {item.Value} x {ProductCategory[item.Key]} = {item.Value * ProductCategory[item.Key]}");
            }
        }
    }
}
