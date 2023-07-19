using System.Data;

namespace Skynet2.Skynet.Shared
{
    public class WebScraper : Web
    {
        public DataTable GetData(string url)
        {
            //Experimentar essa linha de código para ver se a página vai atualizar automaticamente
            //Navigate(url).element.SendKeys(OpenQA.Selenium.Keys.F5);
            if (driver == null)
                StartBrowser();

            var items = new List<Item>();
            Navigate(url);
            var elements = GetValue(TypeElement.Xpath, "/html/body/div[1]/div[3]/div/div[2]/div").element.FindElements(By.ClassName("thumbnail"));

            foreach (var element in elements)
            {
                items.Add(new Item() 
                {
                    Title = element.FindElement(By.ClassName("title")).GetAttribute("title"),
                    Price = element.FindElement(By.ClassName("price")).Text,
                    Description = element.FindElement(By.ClassName("description")).Text
                });
            }
            
            return Base.ConvertTo(items);
        }

        public void GetAvailablePacs(string url)
        {
            List<PACs> listOfPacs = new();

            if (driver == null)
            {
                StartBrowser();
                Navigate(url);
                var tableOfAvailablePacs = GetValue(TypeElement.Xpath, "//*[@id=\"form\"]/div[2]/div/table").element.FindElements(By.ClassName("table"));

                while (tableOfAvailablePacs.Count == 0) 
                {
                    Thread.Sleep(5000);
                    Navigate(url);
                    tableOfAvailablePacs = GetValue(TypeElement.Xpath, "//*[@id=\"form\"]/div[2]/div/table").element.FindElements(By.ClassName("table"));
                }

                foreach (var availablePacs in tableOfAvailablePacs)
                {
                    listOfPacs.Add(new PACs() 
                    {
                        Id = availablePacs.FindElement(By.TagName("tr")).GetAttribute("id"),
                        Local = availablePacs.FindElement(By.TagName("td")).Text//Ver uma forma de obter o índice da coluna
                    });                    
                }
            }
            //return listOfPacs;
        }
    }
}
