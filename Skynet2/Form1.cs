using Skynet2.Skynet.Models;
using System.Windows.Forms;
using TwoCaptcha;

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

        private async void TryMakeAppointment()
        {
            var web = new Web();
            foreach (var item in people)
            {
                web.StartBrowser();
                var link = $"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/c582e8c8-8797-46e1-a4a3-d78b7b33bfad";
                web.Navigate(link);
                web.WaitForLoad();

                //It closes the browser
                //web.CloseBrowser();
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

        private string SelectPac(string pac)
        {
            //To do
            //Pegar o id da PAC SUMAÚMA
            string url = string.Empty;

            switch (pac)
            {
                case "PAC ALVORADA":
                    url = "40e88856-2a16-4aeb-8b2f-1b0e656d782c";
                    break;
                case "PAC COMPENSA":
                    url = "3313615e-a827-4c96-b1dd-74863c83a942";
                    //     241bfd26-2024-4017-bdea-018b237f9a45
                    break;
                case "PAC GALERIA DOS REMÉDIOS":
                    url = "e6947c92-b86a-48c7-8766-26ee10d526c8";
                    //     79dc7604-9137-4b43-9139-8b0165ccff69
                    break;
                case "PAC LESTE":
                    url = "4de92783-0793-4e83-8bca-2beed7ddaa10";
                    //     4b8b0b67-b803-4017-be18-44234b66ad65
                    break;
                case "PAC PARQUE DEZ":
                    url = "7ba2ef2a-be20-4e22-87be-97d7002646d8";
                    break;
                case "PAC SÃO JOSÉ":
                    url = "b9a621ac-86ae-44e4-be13-f0462fb301c8";
                    //     4d69d477-ad17-42f6-ba1d-777ec27f149c
                    break;
                case "PAC SUMAÚMA":
                    url = "5922517b-5184-4cf2-afe2-2cca6449f499";
                    break;
                case "PAC STUDIO 5":
                    url = "c582e8c8-8797-46e1-a4a3-d78b7b33bfad";
                    //     b0798f61-acaf-4c7f-8827-92fbc3a817e7
                    break;
                case "PAC VIA NORTE":
                    url = "168f4c8b-3d65-4959-bd7d-d4559e167402";
                    break;
                case "PAC MUNICIPAL GALERIA ESPÍRITO SANTO":
                    url = "c9b42b99-155c-49a7-b485-3e36cdaffc87";
                    //     ba91fefa-e615-438d-9a9e-8128de401ca9
                    break;
                case "PAC MUNICIPAL T4 - SHOPPING PHELIPPE DAOU":
                    url = "e1d7e903-f117-40e3-bd68-9d9c3eac434b";
                    //     4e779419-2d48-4ab2-8799-6fb9dc3a26a4
                    break;
                case "Açaí - Baratão da Carne":
                    url = "4dda6ee2-b241-412c-8fba-d07cc4a1127a";
                    //4f42e05c-6d5c-4174-8cb7-fa62284b83b0
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

        private void FormSkynet_Load(object sender, EventArgs e)
        {
            people.Clear();
            people = crud.Read(crud.ReadPersonTable());
        }
    }
}