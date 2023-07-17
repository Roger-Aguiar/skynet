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
                //It closes the browser
                //web.CloseBrowser();
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
                web.Navigate($"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/{SelectPac(item.Pac)}");
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

        private void TryMakeAppointment()
        {
            var web = new Web();
            
            web.StartBrowser();
            #pragma warning disable CS8604 // Possible null reference argument.
            web.Navigate($"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/4de92783-0793-4e83-8bca-2beed7ddaa10");
            #pragma warning restore CS8604 // Possible null reference argument.
            //It closes the browser
            //web.CloseBrowser();
            web.AssignValue(TypeElement.Id, "via", "1ª Via");
            web.AssignValue(TypeElement.Id, "tipo", "Quero que o sistema escolha o horário mais próximo");
            web.AssignValue(TypeElement.Id, "nome", "Roger Siva Santos Aguiar");
            web.AssignValue(TypeElement.Id, "cpf", "075.826.356-20");
            //web.AssignValue(TypeElement.Id, "dataNascimento", "25/04/1986");
            web.AssignValue(TypeElement.Id, "dataNascimento", "25/04/1986").element.SendKeys(OpenQA.Selenium.Keys.Enter);
            //Inserir o código para quebrar o capctcha
            //https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/4de92783-0793-4e83-8bca-2beed7ddaa10
        }
        private string SelectPac(string pac)
        {
            //To do
            //Ainda tem que trocar os Ids das PACs em cada "url"
            string url = string.Empty;
            
            switch(pac) 
            {
                case "PAC ALVORADA":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "PAC COMPENSA":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "PAC GALERIA DOS REMÉDIOS":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "PAC LESTE":
                    url = "4de92783-0793-4e83-8bca-2beed7ddaa10";
                    break;
                case "PAC PARQUE DEZ":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "PAC SÃO JOSÉ":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "PAC SUMAÚMA":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "PAC STUDIO 5":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "PAC VIA NORTE":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "PAC MUNICIPAL GALERIA ESPÍRITO SANTO":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "PAC MUNICIPAL T4 - SHOPPING PHELIPPE DAOU":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "Açaí - Baratão da Carne":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "Buriti - Águas de Manaus":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "Cupuaçu - Sesi Clube do Trabalhador":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "Tucumâ - Shopping Phelippe Daou":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
            }
            return url;
        }

        #endregion

        private void buttonSearchAppointment_Click(object sender, EventArgs e)
        {
            SearchAppointment("001.361.422-30");

        }

        private void buttonMakeAppointment_Click(object sender, EventArgs e)
        {
            //MakeAppointment();
            TryMakeAppointment();
        }

        private void buttonRegisterPerson_Click(object sender, EventArgs e)
        {
            FormPerson form = new();
            form.ShowDialog();
        }
    }
}