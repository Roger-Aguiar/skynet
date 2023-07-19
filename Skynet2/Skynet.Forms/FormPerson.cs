using EasyAutomationFramework;
using javax.swing.border;
using TwoCaptcha;

namespace Skynet2.Skynet.Forms
{
    public partial class FormPerson : Form
    {
        private DatabaseContext databaseContext = new();
        private List<Person> persons = new();
        private int index = 0;
        private CRUD crud = new();

        public FormPerson()
        {
            InitializeComponent();
        }

        #region Private methods

        private Person FillPersonModel()
        {
            return new Person
            {
                Name = TextBoxName.Text,
                Cpf = MaskedTextBoxCpf.Text,
                Birthdate = TextBoxBirthdate.Text,
                Pac = ComboBoxPacs.Text
            };
        }

        private void ClearFields()
        {
            TextBoxName.Clear();
            MaskedTextBoxCpf.Clear();
            TextBoxBirthdate.Clear();
            ComboBoxPacs.Text = "SELECIONE";
            ComboBoxCustomers.Text = "SELECIONE";
            TextBoxName.Focus();
        }

        private void FillFields()
        {
            if (persons.Count > 0)
            {
                TextBoxName.Text = persons[index].Name;
                MaskedTextBoxCpf.Text = persons[index].Cpf;
                TextBoxBirthdate.Text = persons[index].Birthdate;
                ComboBoxPacs.Text = persons[index].Pac;
                LabelCustomerToMakeAppointment.Text = $"{persons.Count} cliente(s) para agendar.";
            }
        }

        private void FillComboBoxCustomers()
        {
            ComboBoxCustomers.Items.Clear();
            foreach (var item in persons)
                ComboBoxCustomers.Items.Add(item.Name);
        }

        private async void TryMakeAppointment()
        {
            var web = new Web();

            web.StartBrowser();
            var link = $"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/c582e8c8-8797-46e1-a4a3-d78b7b33bfad";
            //web.Navigate($"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/4de92783-0793-4e83-8bca-2beed7ddaa10");
            web.Navigate(link);
            web.WaitForLoad();


            //document.querySelector("#g-recaptcha-response").innerHTML = 'teste';
            //It closes the browser
            //web.CloseBrowser();
            web.AssignValue(TypeElement.Id, "via", "1ª Via");
            web.AssignValue(TypeElement.Id, "tipo", "Quero que o sistema escolha o horário mais próximo");
            web.AssignValue(TypeElement.Id, "nome", TextBoxName.Text);
            web.AssignValue(TypeElement.Id, "cpf", MaskedTextBoxCpf.Text);
            var captcha_key = web.GetValue(TypeElement.Id, "grecaptcharesponse").element.GetAttribute("data-sitekey");
            var solve_captcha = new Solve();
            var result = await solve_captcha.ReCaptchaV2Async("f19489630e32745e0e7a81d18237b05d", captcha_key, link);
            web.ExecuteScript($"document.querySelector('#g-recaptcha-response').innerHTML = '{result.Request}';");
            web.AssignValue(TypeElement.Id, "dataNascimento", "25/04/1986").element.SendKeys(OpenQA.Selenium.Keys.Enter);
        }

        #endregion

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            crud.Create(FillPersonModel());
            persons.Clear();
            persons = crud.Read(crud.ReadPersonTable());
            FillFields();
            FillComboBoxCustomers();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void FormPerson_Load(object sender, EventArgs e)
        {
            persons.Clear();
            persons = crud.Read(crud.ReadPersonTable());
            FillFields();
            FillComboBoxCustomers();
        }

        private void ComboBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = ComboBoxCustomers.SelectedIndex >= 0 ? ComboBoxCustomers.SelectedIndex : 0;
            FillFields();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja remover esse cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                crud.Delete(persons[index]);
                index = 0;
                persons.Clear();
                persons = crud.Read(crud.ReadPersonTable());
                FillFields();
                FillComboBoxCustomers();

                ComboBoxCustomers.Text = "SELECIONE";
            }
        }

        private void ButtonMakeAppointment_Click(object sender, EventArgs e)
        {
            TryMakeAppointment();
        }
    }
}
