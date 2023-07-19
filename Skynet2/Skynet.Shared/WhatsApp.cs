namespace Skynet2.Skynet.Shared
{
    public class WhatsApp : Web
    {
        public void SendMessage(string message, string to)
        {
            var web = new Web();
            web.StartBrowser(TypeDriver.GoogleChorme, "C:\\Users\\roger\\AppData\\Local\\Google\\Chrome\\User Data");
            web.Navigate("https://web.whatsapp.com/");
            web.WaitForLoad();
            web.AssignValue(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div/div[2]/div/div[1]/p", to).element.SendKeys(OpenQA.Selenium.Keys.Enter);
            //var elementSearch = AssignValue(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div/div[2]/div/div[1]/p", to);
            //selectable-text copyable-text iq0m558w g0rxnol2
        }
    }
}
