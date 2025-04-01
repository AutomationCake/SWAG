using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SWAG.Pages
{
        
    public class element : ProductPage
    {

        public static By GetPropertyByName(string propertyName)
        {
            // Get the property using reflection    
            PropertyInfo property = typeof(element).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if (property != null)
            {
                // Return the value of the property
                return (By)property.GetValue(null, null);
            }
            // If the property is not found, return null or throw an exception based on your needs
            throw new ArgumentException($"Property '{propertyName}' not found");
        }
    }
}
