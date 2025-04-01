using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SWAG.Pages
{
    public class ProductPage : CartPage
    {
       
        public static By openMenu { get { return By.ClassName("bm-burger-button"); } }

        public static By productLabel { get { return By.ClassName("product_label"); } }

        public static By productSortDropdown { get { return By.ClassName("product_sort_container"); } }

        public static By inventoryList { get { return By.ClassName("inventory_list"); } }

        public static By allItems { get { return By.XPath("//a[text()='All Items']"); } }

        public static By shopping_cart_container { get { return By.Id("shopping_cart_container"); } }

        public static By addCartButton (string productName) {  { return By.XPath($"//div[text()='{productName}']/../../..//button[text()='ADD TO CART']"); } }

        public static By removeButton(string productName) { { return By.XPath($"//div[text()='{productName}']/../../..//button[text()='REMOVE']"); } }

        public static By shopping_cart_badge { get { return By.XPath("//span[contains(@class,'shopping_cart_badge')]"); } }
    }
}
