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

        public void GetData2(string url)
        {
            if (driver == null)
            {
                StartBrowser();
                Navigate(url);
                Thread.Sleep(2000);
                Navigate(url);
                Thread.Sleep(2000);
                Navigate(url);
                Thread.Sleep(2000);
                Navigate(url);                
            }            
        }
    }
}
