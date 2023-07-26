using Skynet2.Skynet.Models;

namespace Skynet2.Skynet.Forms
{
    public partial class FormPerson : Form
    {
        private DatabaseContext databaseContext = new();
        private List<Person> persons = new();
        private int index = 0;
        private CRUD crud = new();
        private bool update = true;

        public FormPerson()
        {
            InitializeComponent();
        }

        #region Private methods

        private Person FillPersonModel()
        {
            return new Person
            {
                Name = TextBoxName.Text.ToUpper(),
                Cpf = MaskedTextBoxCpf.Text,
                Birthdate = MaskedTextBoxBirthDate.Text,
                Pac = ComboBoxPacs.Text,
                Mae = TextBoxMother.Text.ToUpper(),
                Pai = TextBoxFather.Text.ToUpper()
            };
        }

        private void ClearFields()
        {
            TextBoxName.Clear();
            TextBoxMother.Clear();
            TextBoxFather.Clear();
            MaskedTextBoxCpf.Clear();
            MaskedTextBoxBirthDate.Clear();
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
                MaskedTextBoxBirthDate.Text = persons[index].Birthdate;
                ComboBoxPacs.Text = persons[index].Pac;
                LabelCustomerToMakeAppointment.Text = $"{persons.Count} cliente(s) para agendar.";
                TextBoxFather.Text = persons[index].Pai;
                TextBoxMother.Text = persons[index].Mae;
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
            var link = $"https://amcin.e-instituto.com.br/Vsoft.iDSPS.Agendamento/Agendamento/Agendar/2421095c-7085-4746-abe4-0f9883f857c1";
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

        private async void SearchCPF(string cpf, string birthdate)
        {
            var link = $"https://servicos.receita.fazenda.gov.br/Servicos/CPF/ConsultaSituacao/ConsultaPublica.asp";
            var web = new Web();

            web.StartBrowser();            
            web.Navigate(link);
            web.WaitForLoad();

            web.AssignValue(TypeElement.Id, "txtCPF", cpf);
            web.AssignValue(TypeElement.Id, "txtDataNascimento", birthdate);
            var captcha_key = web.GetValue(TypeElement.Id, "hcaptcha").element.GetAttribute("data-sitekey");
            var solve_captcha = new Solve();
            var result = await solve_captcha.ReCaptchaV2Async("f19489630e32745e0e7a81d18237b05d", captcha_key, link);
            web.ExecuteScript($"document.querySelector('#g-recaptcha-response').innerHTML = '{result.Request}';");            
        }

        #endregion

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!update)
                crud.Create(FillPersonModel());
            else
                crud.Update(FillPersonModel());

            persons.Clear();
            persons = crud.Read(crud.ReadPersonTable());
            FillFields();
            FillComboBoxCustomers();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            update = false;
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

        private void ButtonSearchCpf_Click(object sender, EventArgs e) => SearchCPF(MaskedTextBoxCpf.Text, MaskedTextBoxBirthDate.Text);
    }
}
