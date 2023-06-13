using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace WebServices2
{
    /// <summary>
    /// Summary description for CartService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CartService : System.Web.Services.WebService
    {
        private static List<CartItem> cartItems = new List<CartItem>();

        [WebMethod]
        public void AddToCart(string itemId, int quantity)
        {
            // Check if the item already exists in the cart
            CartItem existingItem = cartItems.FirstOrDefault(item => item.ItemId == itemId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                // Fetch item details from a database or any other source
                string itemName = GetItemName(itemId);
                decimal price = GetItemPrice(itemId);

                // Create a new cart item
                CartItem newItem = new CartItem
                {
                    ItemId = itemId,
                    ItemName = itemName,
                    Price = price,
                    Quantity = quantity
                };

                cartItems.Add(newItem);
            }
        }

        [WebMethod]
        public void RemoveFromCart(string itemId)
        {
            // Find the item in the cart
            CartItem itemToRemove = cartItems.FirstOrDefault(item => item.ItemId == itemId);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }
        }

        [WebMethod]
        public List<CartItem> GetCartItems()
        {
            return cartItems;
        }

        // Dummy methods to retrieve item details (replace with your own implementation)
        private string GetItemName(string itemId)
        {
            // Fetch the item name from a database or any other source
            return "Item " + itemId;
        }

        private decimal GetItemPrice(string itemId)
        {
            // Fetch the item price from a database or any other source
            return 9.99m;
        }
    }

    public class CartItem
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }


}
}
