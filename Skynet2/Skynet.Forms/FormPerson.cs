using Microsoft.EntityFrameworkCore;
using Skynet2.Skynet.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet2.Skynet.Forms
{
    public partial class FormPerson : Form
    {
        private DatabaseContext databaseContext = new();
        private List<Person> persons = new();
        private int index = 0;

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
            TextBoxName.Text = persons[index].Name;
            TextBoxCpf.Text = persons[index].Cpf;
            TextBoxBirthdate.Text = persons[index].Birthdate;
            ComboBoxPacs.Text = persons[index].Pac;
            LabelCustomerToMakeAppointment.Text = $"{persons.Count} cliente(s) para agendar.";
        }

        private void FillComboBoxCustomers()
        {
            ComboBoxCustomers.Items.Clear();
            foreach (var item in persons)
                ComboBoxCustomers.Items.Add(item.Name);
        }

        private FormattableString ReadPersonTable() => $"select * from persons;";

        private void Create()
        {
            databaseContext.Add(FillPersonModel());
            databaseContext.SaveChanges();
            MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private List<Person> Read() => databaseContext.Persons.FromSqlInterpolated(ReadPersonTable()).ToList();

        #endregion

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Create();
            persons.Clear();
            persons = Read();
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
            persons = Read();
            FillFields();
            FillComboBoxCustomers();
        }

        private void ComboBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxCustomers.SelectedIndex != -1)
            {
                index = ComboBoxCustomers.SelectedIndex;
                FillFields();
            }
        }

        private void LabelCustomerToMakeAppointment_Click(object sender, EventArgs e)
        {

        }
    }
}
