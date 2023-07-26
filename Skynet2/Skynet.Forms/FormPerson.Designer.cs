namespace Skynet2.Skynet.Forms
{
    partial class FormPerson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            TextBoxName = new TextBox();
            ButtonSave = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ComboBoxPacs = new ComboBox();
            label5 = new Label();
            ButtonDelete = new Button();
            ButtonNew = new Button();
            label6 = new Label();
            ComboBoxCustomers = new ComboBox();
            LabelCustomerToMakeAppointment = new Label();
            ButtonSearchCpf = new Button();
            MaskedTextBoxCpf = new MaskedTextBox();
            MaskedTextBoxBirthDate = new MaskedTextBox();
            TextBoxFather = new TextBox();
            label7 = new Label();
            TextBoxMother = new TextBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 59);
            label1.Name = "label1";
            label1.Size = new Size(56, 21);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // TextBoxName
            // 
            TextBoxName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxName.Location = new Point(165, 56);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(321, 29);
            TextBoxName.TabIndex = 0;
            // 
            // ButtonSave
            // 
            ButtonSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonSave.Location = new Point(12, 272);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(130, 31);
            ButtonSave.TabIndex = 6;
            ButtonSave.Text = "Salvar";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(124, 9);
            label2.Name = "label2";
            label2.Size = new Size(255, 25);
            label2.TabIndex = 3;
            label2.Text = "Clientes para agendamento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 94);
            label3.Name = "label3";
            label3.Size = new Size(40, 21);
            label3.TabIndex = 4;
            label3.Text = "CPF:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 129);
            label4.Name = "label4";
            label4.Size = new Size(147, 21);
            label4.TabIndex = 6;
            label4.Text = "Data de nascimento";
            // 
            // ComboBoxPacs
            // 
            ComboBoxPacs.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ComboBoxPacs.FormattingEnabled = true;
            ComboBoxPacs.Items.AddRange(new object[] { "PAC-COMPENSA", "PAC - SHOPPING LESTE", "PAC-MUNICIPAL T4", "PAC - SÃO JOSÉ", "PAC - MUN. GALERIA ESP. SANTO", "PAC - GALERIA DOS REMÉDIOS", "PAC - STUDIO 5", "PAC - ALVORADA", "PAC - SHOPPING PARQUE 10 MALL", "PAC - SUMAÚMA", "PAC - SHOPPING VIA NORTE", "PAC - Móvel Açaí", "PAC - Móvel Buriti", "PAC - Móvel Cupuaçu", "PAC - Móvel Tucumã" });
            ComboBoxPacs.Location = new Point(165, 231);
            ComboBoxPacs.Name = "ComboBoxPacs";
            ComboBoxPacs.Size = new Size(321, 29);
            ComboBoxPacs.TabIndex = 5;
            ComboBoxPacs.Text = "SELECIONE";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 234);
            label5.Name = "label5";
            label5.Size = new Size(36, 21);
            label5.TabIndex = 9;
            label5.Text = "Pac:";
            // 
            // ButtonDelete
            // 
            ButtonDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonDelete.Location = new Point(186, 272);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new Size(130, 31);
            ButtonDelete.TabIndex = 7;
            ButtonDelete.Text = "Deletar";
            ButtonDelete.UseVisualStyleBackColor = true;
            ButtonDelete.Click += ButtonDelete_Click;
            // 
            // ButtonNew
            // 
            ButtonNew.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonNew.Location = new Point(356, 272);
            ButtonNew.Name = "ButtonNew";
            ButtonNew.Size = new Size(130, 31);
            ButtonNew.TabIndex = 8;
            ButtonNew.Text = "Novo";
            ButtonNew.UseVisualStyleBackColor = true;
            ButtonNew.Click += ButtonNew_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 349);
            label6.Name = "label6";
            label6.Size = new Size(68, 21);
            label6.TabIndex = 13;
            label6.Text = "Clientes:";
            // 
            // ComboBoxCustomers
            // 
            ComboBoxCustomers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ComboBoxCustomers.FormattingEnabled = true;
            ComboBoxCustomers.Location = new Point(165, 346);
            ComboBoxCustomers.Name = "ComboBoxCustomers";
            ComboBoxCustomers.Size = new Size(321, 29);
            ComboBoxCustomers.TabIndex = 10;
            ComboBoxCustomers.Text = "SELECIONE";
            ComboBoxCustomers.SelectedIndexChanged += ComboBoxCustomers_SelectedIndexChanged;
            // 
            // LabelCustomerToMakeAppointment
            // 
            LabelCustomerToMakeAppointment.AutoSize = true;
            LabelCustomerToMakeAppointment.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            LabelCustomerToMakeAppointment.Location = new Point(12, 397);
            LabelCustomerToMakeAppointment.Name = "LabelCustomerToMakeAppointment";
            LabelCustomerToMakeAppointment.Size = new Size(0, 25);
            LabelCustomerToMakeAppointment.TabIndex = 14;
            // 
            // ButtonSearchCpf
            // 
            ButtonSearchCpf.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonSearchCpf.Location = new Point(12, 309);
            ButtonSearchCpf.Name = "ButtonSearchCpf";
            ButtonSearchCpf.Size = new Size(474, 31);
            ButtonSearchCpf.TabIndex = 9;
            ButtonSearchCpf.Text = "Consultar CPF";
            ButtonSearchCpf.UseVisualStyleBackColor = true;
            ButtonSearchCpf.Click += ButtonSearchCpf_Click;
            // 
            // MaskedTextBoxCpf
            // 
            MaskedTextBoxCpf.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MaskedTextBoxCpf.Location = new Point(165, 91);
            MaskedTextBoxCpf.Mask = "000.000.000-00";
            MaskedTextBoxCpf.Name = "MaskedTextBoxCpf";
            MaskedTextBoxCpf.Size = new Size(321, 29);
            MaskedTextBoxCpf.TabIndex = 1;
            // 
            // MaskedTextBoxBirthDate
            // 
            MaskedTextBoxBirthDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MaskedTextBoxBirthDate.Location = new Point(165, 126);
            MaskedTextBoxBirthDate.Mask = "00/00/0000";
            MaskedTextBoxBirthDate.Name = "MaskedTextBoxBirthDate";
            MaskedTextBoxBirthDate.Size = new Size(321, 29);
            MaskedTextBoxBirthDate.TabIndex = 2;
            MaskedTextBoxBirthDate.ValidatingType = typeof(DateTime);
            // 
            // TextBoxFather
            // 
            TextBoxFather.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxFather.Location = new Point(165, 161);
            TextBoxFather.Name = "TextBoxFather";
            TextBoxFather.Size = new Size(321, 29);
            TextBoxFather.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(12, 164);
            label7.Name = "label7";
            label7.Size = new Size(103, 21);
            label7.TabIndex = 16;
            label7.Text = "Nome do pai:";
            // 
            // TextBoxMother
            // 
            TextBoxMother.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxMother.Location = new Point(165, 196);
            TextBoxMother.Name = "TextBoxMother";
            TextBoxMother.Size = new Size(321, 29);
            TextBoxMother.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(12, 199);
            label8.Name = "label8";
            label8.Size = new Size(111, 21);
            label8.TabIndex = 18;
            label8.Text = "Nome da mãe:";
            // 
            // FormPerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 479);
            Controls.Add(TextBoxMother);
            Controls.Add(label8);
            Controls.Add(TextBoxFather);
            Controls.Add(label7);
            Controls.Add(MaskedTextBoxBirthDate);
            Controls.Add(MaskedTextBoxCpf);
            Controls.Add(ButtonSearchCpf);
            Controls.Add(LabelCustomerToMakeAppointment);
            Controls.Add(label6);
            Controls.Add(ComboBoxCustomers);
            Controls.Add(ButtonNew);
            Controls.Add(ButtonDelete);
            Controls.Add(label5);
            Controls.Add(ComboBoxPacs);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ButtonSave);
            Controls.Add(TextBoxName);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "FormPerson";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de clientes";
            Load += FormPerson_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TextBoxName;
        private Button ButtonSave;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox ComboBoxPacs;
        private Label label5;
        private Button ButtonDelete;
        private Button ButtonNew;
        private Label label6;
        private ComboBox ComboBoxCustomers;
        private Label LabelCustomerToMakeAppointment;
        private Button ButtonSearchCpf;
        private MaskedTextBox MaskedTextBoxCpf;
        private MaskedTextBox MaskedTextBoxBirthDate;
        private TextBox TextBoxFather;
        private Label label7;
        private TextBox TextBoxMother;
        private Label label8;
    }
}