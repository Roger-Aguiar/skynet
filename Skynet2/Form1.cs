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

        private void SearchAppointment(string cpf)
        {
            people.Clear();
            people = crud.Read(crud.ReadPersonTable());
            var web = new Web();

            foreach (var item in people)
            {
                web.StartBrowser();
                web.Navigate("https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Consultar");
                web.AssignValue(TypeElement.Name, "cpf", item.Cpf).element.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
        }
               
        private async void TryMakeAppointment(List<PACs> listOfPacs)
        {
            var web = new Web();

            while(people.Count > 0 && listOfPacs.Count > 0)
            {
                FillRichTextBox();
                var pac = from local in listOfPacs where local.Local == people[0].Pac select local.Id;

                web.StartBrowser();
                var link = $"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/{pac.FirstOrDefault()}";
                web.Navigate(link);
                web.WaitForLoad();
                web.AssignValue(TypeElement.Id, "via", "1ª Via");
                web.AssignValue(TypeElement.Id, "tipo", "Quero que o sistema escolha o horário mais próximo");
                web.AssignValue(TypeElement.Id, "nome", people[0].Name);
                web.AssignValue(TypeElement.Id, "cpf", people[0].Cpf);
                var captcha_key = web.GetValue(TypeElement.Id, "grecaptcharesponse").element.GetAttribute("data-sitekey");
                var solve_captcha = new Solve();
                var result = await solve_captcha.ReCaptchaV2Async("f19489630e32745e0e7a81d18237b05d", captcha_key, link);
                web.ExecuteScript($"document.querySelector('#g-recaptcha-response').innerHTML = '{result.Request}';");
                web.AssignValue(TypeElement.Id, "dataNascimento", people[0].Birthdate).element.SendKeys(OpenQA.Selenium.Keys.Enter);
                
                people.RemoveAt(0);
                //Este aponta para o site
                //listOfPacs = webScraper.GetAvailablePacs("https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento");
                listOfPacs.Clear();
                //Apontando para localhost
                listOfPacs = webScraper.GetAvailablePacs("file:///C:/dev2/skynet/Skynet2/Skynet.Utils/agendamentos.html");
            }
            RichTextBoxPacs.Text += $"Finalizado às {DateTime.Now.ToShortTimeString()}";
        }

        private void FillRichTextBox()
        {
            RichTextBoxPacs.Text += $"Vagas disponíveis \n{DateTime.Now.ToShortTimeString()}\n\n";

            foreach (var item in listOfPacs)
                RichTextBoxPacs.Text += $"Id: {item.Id}\n{item.Local}\n\n";

            RichTextBoxPacs.Text += "=========================================";
        }
                
        #endregion

        private void buttonSearchAppointment_Click(object sender, EventArgs e)
        {
            SearchAppointment("001.361.422-30");
        }

        private void buttonMakeAppointment_Click(object sender, EventArgs e)
        {
            people.Clear();
            people = crud.Read(crud.ReadPersonTable());

            RichTextBoxPacs.Text += $"Começou a rodar às {DateTime.Now.ToShortTimeString()}\n\n";
              
            //Apontando para web
            //listOfPacs = webScraper.GetAvailablePacs("https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento");
            listOfPacs = webScraper.GetAvailablePacs("file:///C:/dev2/skynet/Skynet2/Skynet.Utils/agendamentos.html");
            if(listOfPacs.Count > 0)
            {
                TryMakeAppointment(listOfPacs);
            }
        }

        private void buttonRegisterPerson_Click(object sender, EventArgs e)
        {
            FormPerson form = new();
            form.ShowDialog();
        }
    }
}