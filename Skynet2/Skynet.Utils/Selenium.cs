/*using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the ChromeDriver instance
        IWebDriver driver = new ChromeDriver();

        // Navigate to the desired page
        driver.Navigate().GoToUrl("https://example.com");

        try
        {
            // Wait for the element to be present (adjust the timeout as needed)
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.TagName("tr")));

            // Now you can interact with the element
            // For example, you can print the element's text
            Console.WriteLine("Element text: " + element.Text);
        }
        catch (NoSuchElementException ex)
        {
            // Handle the exception if the element is not found
            Console.WriteLine("Element not found: " + ex.Message);
        }
        finally
        {
            // Remember to close the WebDriver when you're done
            driver.Quit();
        }
    }
}
*/