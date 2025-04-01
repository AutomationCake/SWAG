using NUnit.Framework;
using OpenQA.Selenium;
using SWAG.Pages;
using SWAG.Utilities;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SWAG.StepDefinitions
{
    [Binding]
    public class Product_Stepdefinition
    {
        private IWebDriver driver;
        private string getprice = "";

        public Product_Stepdefinition(IWebDriver driver)
        {
            this.driver = driver;
        }

        

        [Given(@"Navigate to product page")]
        public void GivenNavigateToProductPage()
        {

           By prodcu =  element.GetPropertyByName("openMenu");

            Actionutility.ActionClick(driver, prodcu);

            Actionutility.ActionClick(driver, ProductPage.openMenu);
            Actionutility.Click(driver, ProductPage.allItems);

            getprice = "test";
        }

        [Then(@"user able to see the open menu")]
        public void ThenUserAbleToSeeTheOpenMenu()
        {
            Assert.IsTrue(Actionutility.IsElementDisplayed(driver, ProductPage.openMenu));

            string str = getprice;
                
        }

        [Then(@"user able to see the product label ""([^""]*)""")]
        public void ThenUserAbleToSeeTheProductLabel(string input)
        {
            Assert.AreEqual(Actionutility.GetText(driver, ProductPage.productLabel), input);
            Assert.IsTrue(Actionutility.IsElementDisplayed(driver, ProductPage.productLabel));
        }

        [Then(@"user able to see the sort dropdown")]
        public void ThenUserAbleToSeeTheSortDropdown()
        {
            Assert.IsTrue(Actionutility.IsElementDisplayed(driver, ProductPage.productSortDropdown));
        }

        [Then(@"user able to see the inventory items")]
        public void ThenUserAbleToSeeTheInventoryItems()
        {
            Assert.IsTrue(Actionutility.IsElementDisplayed(driver, ProductPage.inventoryList));
        }

        [Then(@"use able to see the shopping cart")]
        public void ThenUseAbleToSeeTheShoppingCart()
        {
            Assert.IsTrue(Actionutility.IsElementDisplayed(driver, ProductPage.shopping_cart_container));
        }

        [When(@"user select the product ""([^""]*)"" and click Add to cart")]
        public void WhenUserSelectTheProductAndClickAddToCart(string productName)
        {
            Actionutility.Click(driver, ProductPage.addCartButton(productName));
        }

        [Then(@"user not able to see remove button ""([^""]*)""")]
        public void ThenUserNotAbleToSeeRemoveButton(string productName)
        {
            Assert.IsFalse(Actionutility.IsElementDisplayed(driver, ProductPage.removeButton(productName)));
        }

        [When(@"user select the product ""([^""]*)"" and click continue shopping")]
        public void WhenUserSelectTheProductAndClickContinueShopping(string productName)
        {
            Actionutility.Click(driver, CartPage.continueShoppingButton);
        }

        [Then(@"user able to see the product page")]
        public void ThenUserAbleToSeeTheProductPage()
        {
            Assert.IsTrue(Actionutility.IsElementDisplayed(driver, ProductPage.productLabel));
        }

        [When(@"user select the other product ""([^""]*)"" and click Add to cart")]
        public void WhenUserSelectTheOtherProductAndClickAddToCart(string productName)
        {
            Actionutility.Click(driver, ProductPage.addCartButton(productName));
        }


        [Then(@"user able to see remove button ""([^""]*)""")]
        public void ThenUserAbleToSeeRemoveButton(string productName)
        {
            Assert.IsTrue(Actionutility.IsElementDisplayed(driver, ProductPage.removeButton(productName)));
        }

        [Then(@"user able to see the cart count ""([^""]*)""")]
        public void ThenUserAbleToSeeTheCartCount(string count)
        {
            Assert.AreEqual(Actionutility.GetText(driver, ProductPage.shopping_cart_badge), count);
        }

        [When(@"user select the product ""([^""]*)"" and click remove")]
        public void WhenUserSelectTheProductAndClickRemove(string productName)
        {
            Actionutility.Click(driver, ProductPage.removeButton(productName));
        }

        [Then(@"user not able to see the cart count")]
        public void ThenUserNotAbleToSeeTheCartCount()
        {
            Assert.IsFalse(Actionutility.IsElementDisplayed(driver, ProductPage.shopping_cart_badge));
        }

        [When(@"user click the cart icon")]
        public void WhenUserClickTheCartIcon()
        {
            Actionutility.Click(driver, ProductPage.shopping_cart_container);
        }

        [Then(@"user able to see the added product ""([^""]*)"" in the cart")]
        public void ThenUserAbleToSeeTheAddedProductInTheCart(string productName)
        {
            Assert.AreEqual(Actionutility.GetText(driver,CartPage.inventory_item_name), productName);
        }

        [Then(@"user verify the product name ""([^""]*)"" and quantity ""([^""]*)""")]
        public void ThenUserVerifyTheProductNameAndQuantity(string productName, string quantity)
        {
            Assert.AreEqual(Actionutility.GetText(driver, CartPage.inventory_item_name), productName);
            Assert.AreEqual(Actionutility.GetText(driver, CartPage.cart_quantity), quantity);
        }

        
        [Then(@"user able to see the continue shopping button")]
        public void ThenUserAbleToSeeTheContinueShoppingButton()
        {
            Assert.IsTrue(Actionutility.IsElementDisplayed(driver, CartPage.continueShoppingButton));
        }

        [Then(@"user able to see the checkout button")]
        public void ThenUserAbleToSeeTheCheckoutButton()
        {
            Assert.IsTrue(Actionutility.IsElementDisplayed(driver, CartPage.checkoutButton));
        }

        [Then(@"user not able to see the name ""([^""]*)"" and quantity ""([^""]*)""")]
        public void ThenUserNotAbleToSeeTheNameAndQuantity(string productName, string quantity)
        
        {
            Assert.IsFalse(Actionutility.IsElementDisplayed(driver, CartPage.inventory_item_name));
            Assert.IsFalse(Actionutility.IsElementDisplayed(driver, CartPage.inventory_item_price));
        }

    }
}
