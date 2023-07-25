namespace Skynet2
{
    public partial class FormSkynet : Form
    {
        private CRUD crud = new();
        private DatabaseContext databaseContext = new();
        private List<Person> people = new();
        private WebScraper webScraper = new();
        private List<PACs> listOfPacs = new();

        public FormSkynet()
        {
            Splashscreen splashScreen = new();
            splashScreen.Show();
            Thread.Sleep(5000);
            splashScreen.Close();
            InitializeComponent();
        }

        #region Private methods

        private void SearchAppointment()
        {
            people.Clear();
            people = crud.Read(crud.ReadPersonTable());
            var web = new Web();

            foreach (var item in people)
            {
                web.StartBrowser();
                web.Navigate("https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Consultar");
                web.WaitForLoad();
                web.AssignValue(TypeElement.Name, "cpf", item.Cpf).element.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
        }
               
        private async void MakeAppointment(List<PACs> listOfPacs)
        {
            FillRichTextBox();
            var web = new Web();

            foreach (var person in people)
            {
                var pac = from local in listOfPacs where local.Local == person.Pac select local.Id;

                if (pac != null)
                {
                    web.StartBrowser();
                    var link = $"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/{pac.FirstOrDefault()}";
                    web.Navigate(link);
                    web.WaitForLoad();
                    web.AssignValue(TypeElement.Id, "via", "1ª Via");
                    web.AssignValue(TypeElement.Id, "tipo", "Quero que o sistema escolha o horário mais próximo");
                    web.AssignValue(TypeElement.Id, "nome", person.Name);
                    web.AssignValue(TypeElement.Id, "cpf", person.Cpf);
                    web.AssignValue(TypeElement.Id, "pai", person.Cpf);
                    web.AssignValue(TypeElement.Id, "mae", person.Cpf);
                    var captcha_key = web.GetValue(TypeElement.Id, "grecaptcharesponse").element.GetAttribute("data-sitekey");
                    var solve_captcha = new Solve();
                    var result = await solve_captcha.ReCaptchaV2Async("f19489630e32745e0e7a81d18237b05d", captcha_key, link);
                    web.ExecuteScript($"document.querySelector('#g-recaptcha-response').innerHTML = '{result.Request}';");
                    web.AssignValue(TypeElement.Id, "dataNascimento", person.Birthdate).element.SendKeys(OpenQA.Selenium.Keys.Enter);
                    web.CloseBrowser();
                }                
            }

            SearchAppointment();
                        
            RichTextBoxPacs.Text += $"Finalizado às {DateTime.Now.ToShortTimeString()}";
        }

        private void FillRichTextBox()
        {
            RichTextBoxPacs.Text += $"Vagas disponíveis às {DateTime.Now.ToShortTimeString()}";
            RichTextBoxPacs.Text += "\n=========================================";
        }
                
        #endregion

        private void buttonSearchAppointment_Click(object sender, EventArgs e)
        {
            SearchAppointment();
        }

        private void buttonMakeAppointment_Click(object sender, EventArgs e)
        {
            string linkWeb = "https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento";
            //string linkLocal = "file:///C:/dev2/skynet/Skynet2/Skynet.Utils/agendamentos2.html";                      

            RichTextBoxPacs.Text += $"Começou a rodar às {DateTime.Now.ToShortTimeString()}\n\n";
              
            //Apontando para web
            listOfPacs = webScraper.GetAvailablePacs(linkWeb);
            //listOfPacs = webScraper.GetAvailablePacs(linkLocal);
            
            if(listOfPacs.Count > 0) 
            {                
                string message = $"Vagas disponíveis para o agendamento de RG em {listOfPacs.Count} PACs. Segue o link para acessar o sistema: {linkWeb}";
                
                WhatsApp whatsApp = new();
                whatsApp.SendMessage(message, "AGENDAMENTO RG");
                people = crud.Read(crud.ReadPersonTable());
                //Apontando para web
                //listOfPacs = webScraper.GetAvailablePacs(linkWeb);
                //listOfPacs = webScraper.GetAvailablePacs(linkLocal);
            }
            MakeAppointment(listOfPacs);    
        }

        private void buttonRegisterPerson_Click(object sender, EventArgs e)
        {
            FormPerson form = new();
            form.ShowDialog();
        }
    }
}