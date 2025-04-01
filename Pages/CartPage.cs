using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SWAG.Pages
{
    public class CartPage
    {

        public static  By productLabel { get { return By.ClassName("subheader"); } }

        public static By cart_quantity_label { get { return By.ClassName("cart_quantity_label"); } }

        public static By cart_desc_label { get { return By.ClassName("cart_desc_label"); } }

        public static By inventory_item_name { get { return By.ClassName("inventory_item_name"); } }

        public static By inventory_item_price { get { return By.ClassName("inventory_item_price"); } }

        public static By cart_quantity { get { return By.ClassName("cart_quantity"); } }

        public static By removeButton(string productName) { { return By.XPath($"//div[text()='{productName}']/../..//button[text()='REMOVE']"); } }

        public static By continueShoppingButton { get { return By.XPath("//a[normalize-space()='Continue Shopping']"); } }

        public static By checkoutButton { get { return By.XPath("//a[normalize-space()='CHECKOUT']"); } }

        

    }

   
}
