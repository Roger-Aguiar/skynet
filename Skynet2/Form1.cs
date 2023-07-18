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
            //web.Navigate($"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/4de92783-0793-4e83-8bca-2beed7ddaa10");
            web.Navigate($"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/c582e8c8-8797-46e1-a4a3-d78b7b33bfad");
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
            //Pegar o id da PAC SUMAÚMA
            string url = string.Empty;
            
            switch(pac) 
            {
                case "PAC ALVORADA":
                    url = "40e88856-2a16-4aeb-8b2f-1b0e656d782c";
                    break;
                case "PAC COMPENSA":
                    url = "3313615e-a827-4c96-b1dd-74863c83a942";
                    break;
                case "PAC GALERIA DOS REMÉDIOS":
                    url = "e6947c92-b86a-48c7-8766-26ee10d526c8";
                    break;
                case "PAC LESTE":
                    url = "4de92783-0793-4e83-8bca-2beed7ddaa10";
                    break;
                case "PAC PARQUE DEZ":
                    url = "7ba2ef2a-be20-4e22-87be-97d7002646d8";
                    break;
                case "PAC SÃO JOSÉ":
                    url = "b9a621ac-86ae-44e4-be13-f0462fb301c8";
                    break;
                case "PAC SUMAÚMA":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "PAC STUDIO 5":
                    url = "c582e8c8-8797-46e1-a4a3-d78b7b33bfad";
                    break;
                case "PAC VIA NORTE":
                    url = "168f4c8b-3d65-4959-bd7d-d4559e167402";
                    break;
                case "PAC MUNICIPAL GALERIA ESPÍRITO SANTO":
                    url = "c9b42b99-155c-49a7-b485-3e36cdaffc87";
                    break;
                case "PAC MUNICIPAL T4 - SHOPPING PHELIPPE DAOU":
                    url = "e1d7e903-f117-40e3-bd68-9d9c3eac434b";
                    break;
                case "Açaí - Baratão da Carne":
                    url = "4dda6ee2-b241-412c-8fba-d07cc4a1127a";
                    break;
                case "Buriti - Águas de Manaus":
                    url = "acdaca05-18c0-41a6-8d46-5c91cecb125e";
                    break;
                case "Cupuaçu - Sesi Clube do Trabalhador":
                    url = "ad18d142-08be-479d-9fcc-e602cd808e97";
                    break;
                case "Tucumâ - Shopping Phelippe Daou":
                    url = "44b59e34-38ed-4356-b483-2c8fac8d70cd";
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