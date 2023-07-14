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

        #endregion

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            using var databaseContext = new DatabaseContext();
            databaseContext.Add(FillPersonModel());
            databaseContext.SaveChanges();
            MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
