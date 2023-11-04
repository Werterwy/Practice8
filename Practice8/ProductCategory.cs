using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8
{
    public class ProductCategory
    {
        private Dictionary<string, decimal> productsInCategory;

        public ProductCategory()
        {
            productsInCategory = new Dictionary<string, decimal>();
        }
        //Индексатор
        public decimal this[string productName]
        {
            get
            {
                if (productsInCategory.ContainsKey(productName))
                {
                    return productsInCategory[productName];
                }
                else
                {
                    Console.WriteLine("Продукт не найден.");
                    return 0.0M;
                }
            }
            set
            {
                productsInCategory[productName] = value;
            }
        }

        public IEnumerable<string> ProductNames
        {
            get
            {
                return productsInCategory.Keys;
            }
        }
    }

}
