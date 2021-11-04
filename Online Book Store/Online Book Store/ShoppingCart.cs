using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Store
{
    class ShoppingCart
    {
        private static List<Product> itemsToPurchase;
        private static List<int> amountToPurchase;
        private static ShoppingCart instance = null;

        private ShoppingCart() { itemsToPurchase = new List<Product>(); amountToPurchase = new List<int>(); }

        public static ShoppingCart Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShoppingCart();
                }
                return instance;
            }
        }

        public void AddProduct(Product product, int amount)
        {
            if (itemsToPurchase.IndexOf(product) > -1)
            {
                amountToPurchase[itemsToPurchase.IndexOf(product)] += amount;
            }
            else
            {
                itemsToPurchase.Add(product);
                amountToPurchase.Add(amount);
            }

        }

        public bool RemoveProduct(Product product)
        {
            int index = itemsToPurchase.IndexOf(product);

            if (itemsToPurchase.Remove(product))
            {
                amountToPurchase.RemoveAt(index);
                return true;

            }
            else 
                return false;
        }

        public void CancelOrder()
        {
            itemsToPurchase.Clear();
        }

        public List<Product> GetItemsToProducts()
        {
            return itemsToPurchase;
        }
        public List<int> GetAmountsOfProducts()
        {
            return amountToPurchase;
        }

        
    }
}
