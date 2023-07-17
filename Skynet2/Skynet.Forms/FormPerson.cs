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
                Cpf = TextBoxCpf.Text,
                Birthdate = TextBoxBirthdate.Text,
                Pac = ComboBoxPacs.Text
            };
        }

        private void ClearFields()
        {
            TextBoxName.Clear();
            TextBoxCpf.Clear();
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
                TextBoxCpf.Text = persons[index].Cpf;
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
                persons.Clear();
                persons = crud.Read(crud.ReadPersonTable());
                FillFields();
                FillComboBoxCustomers();
                index = 0;
                ComboBoxCustomers.Text = "SELECIONE";
            }
        }
    }
}
