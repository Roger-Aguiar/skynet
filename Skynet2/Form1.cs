namespace Skynet2
{
    public partial class FormSkynet : Form
    {
        private CRUD crud = new();
        private DatabaseContext databaseContext = new();
        private List<Person> people = new();

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

        private void MakeAppointment()
        {
            var web = new Web();

            foreach (var item in people)
            {
                web.StartBrowser();
                #pragma warning disable CS8604 // Possible null reference argument.
                //web.Navigate($"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/{SelectPac(item.Pac)}");
                #pragma warning restore CS8604 // Possible null reference argument.
                //It closes the browser
                //web.CloseBrowser();
                web.AssignValue(TypeElement.Id, "via", "1ª Via");
                web.AssignValue(TypeElement.Id, "tipo", "Quero que o sistema escolha o horário mais próximo");
                web.AssignValue(TypeElement.Id, "nome", item.Name);
                web.AssignValue(TypeElement.Id, "cpf", item.Cpf);
                web.AssignValue(TypeElement.Id, "dataNascimento", item.Birthdate).element.SendKeys(OpenQA.Selenium.Keys.Enter);
                //Inserir o código para quebrar o capctcha
            }
        }

        private async void TryMakeAppointment(List<PACs> listOfPacs)
        {
            //char[] delimiterChars = { ' ', ',', '.', ':', '-', '\t' };
            var web = new Web();

            foreach (var item in people)
            {
                var pac = from local in listOfPacs where local.Local == item.Pac select local.Id;

                web.StartBrowser();
                var link = $"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/{pac}";
                web.Navigate(link);
                web.WaitForLoad();
                web.AssignValue(TypeElement.Id, "via", "1ª Via");
                web.AssignValue(TypeElement.Id, "tipo", "Quero que o sistema escolha o horário mais próximo");
                web.AssignValue(TypeElement.Id, "nome", item.Name);
                web.AssignValue(TypeElement.Id, "cpf", item.Cpf);
                var captcha_key = web.GetValue(TypeElement.Id, "grecaptcharesponse").element.GetAttribute("data-sitekey");
                var solve_captcha = new Solve();
                var result = await solve_captcha.ReCaptchaV2Async("f19489630e32745e0e7a81d18237b05d", captcha_key, link);
                web.ExecuteScript($"document.querySelector('#g-recaptcha-response').innerHTML = '{result.Request}';");
                web.AssignValue(TypeElement.Id, "dataNascimento", item.Birthdate).element.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
        }

        private void ExecuteWebScraper()
        {
            WebScraper webScraper = new();
            var computers = webScraper.GetData("https://webscraper.io/test-sites/e-commerce/allinone/computers");
            var tablets = webScraper.GetData("https://webscraper.io/test-sites/e-commerce/allinone/computers/tablets");
            var laptops = webScraper.GetData("https://webscraper.io/test-sites/e-commerce/allinone/computers/laptops");

            var parameters = new ParamsDataTable("Data", @"C:\temp\excel", new List<DataTables>
            {
                new DataTables("Computers", computers),
                new DataTables("Laptops", laptops),
                new DataTables("Tablets", tablets)
            });

            Base.GenerateExcel(parameters);
        }

        #endregion

        private void buttonSearchAppointment_Click(object sender, EventArgs e)
        {
            SearchAppointment("001.361.422-30");
        }

        private void buttonMakeAppointment_Click(object sender, EventArgs e)
        {
            WebScraper webScraper = new();
            //var listOfPacs = webScraper.GetAvailablePacs("https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento");
            var listOfPacs = webScraper.GetAvailablePacs("file:///C:/dev2/skynet/Skynet2/Skynet.Utils/agendamentos.html");
            //TryMakeAppointment(listOfPacs);

            MessageBox.Show("Vagas disponíveis!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RichTextBoxPacs.Text = $"Vagas disponíveis \n{DateTime.Now.ToShortTimeString()}\n\n";

            foreach (var item in listOfPacs)
                RichTextBoxPacs.Text += $"Id: {item.Id}\n{item.Local}\n";
        }

        private void buttonRegisterPerson_Click(object sender, EventArgs e)
        {
            FormPerson form = new();
            form.ShowDialog();
        }

        private void FormSkynet_Load(object sender, EventArgs e)
        {
            people.Clear();
            people = crud.Read(crud.ReadPersonTable());
        }
    }
}