namespace Skynet2.Skynet.Shared
{
    public class WebScraper : Web
    {                                
        public List<PACs> GetAvailablePacs(string url)
        {
            List<PACs> listOfPacs = new();

            if (driver == null)
            {                
                StartBrowser();
                Navigate(url);
                WaitForLoad();
                var tableOfAvailablePacs = GetValue(TypeElement.Xpath, "//*[@id=\"form\"]/div[2]/div/table/tbody").element.FindElements(By.TagName("tr"));
                
                while (tableOfAvailablePacs.Count == 0)
                {
                    Thread.Sleep(5000);
                    Navigate(url);
                    WaitForLoad();
                    tableOfAvailablePacs = GetValue(TypeElement.Xpath, "//*[@id=\"form\"]/div[2]/div/table/tbody").element.FindElements(By.TagName("tr"));
                }

                foreach (var availablePacs in tableOfAvailablePacs)
                {
                    listOfPacs.Add(new PACs()
                    {
                        Id = availablePacs.GetAttribute("id"),
                        Local = availablePacs.FindElement(By.TagName("td")).Text
                    });
                }
                CloseBrowser();
            }
            return listOfPacs;
        }
    }
}
