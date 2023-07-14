using EasyAutomationFramework;
using System;

namespace Skynet2
{
    public partial class FormSkynet : Form
    {
        public FormSkynet()
        {
            InitializeComponent();
        }

        #region Private methods

        private void SearchAppointment(string cpf)
        {
            var web = new Web();
            //It starts the browser, Google Chrome by default
            web.StartBrowser();
            //It allows to navigate to a specified page
            web.Navigate("https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Consultar");
            //It closes the browser
            //web.CloseBrowser();
            web.AssignValue(TypeElement.Name, "cpf", cpf).element.SendKeys(OpenQA.Selenium.Keys.Enter);
        }

        private void MakeAppointment()
        {
            var web = new Web();
            for (int i = 0; i < 4; i++)
            {
                web.StartBrowser();
                web.Navigate("https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento");
                web.CloseBrowser();
            }

            //web.AssignValue(TypeElement.Name, "cpf", cpf).element.SendKeys(OpenQA.Selenium.Keys.Enter);
        }

        #endregion

        private void buttonSearchAppointment_Click(object sender, EventArgs e)
        {
            SearchAppointment("001.361.422-30");

        }

        private void buttonMakeAppointment_Click(object sender, EventArgs e)
        {

        }

        /*Lista de PACs
         Pac Sumaúma
        Pac Via Norte
        Pac Alvorada
        Pac São José
        Pac Galeria dos remédios
        Pac Parque 10
        Pac Educandos
        Pac Compensa
        Pac Leste
         */
    }
}