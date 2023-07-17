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
            TextBoxCpf = new TextBox();
            label3 = new Label();
            TextBoxBirthdate = new TextBox();
            label4 = new Label();
            ComboBoxPacs = new ComboBox();
            label5 = new Label();
            ButtonDelete = new Button();
            ButtonNew = new Button();
            label6 = new Label();
            ComboBoxCustomers = new ComboBox();
            LabelCustomerToMakeAppointment = new Label();
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
            TextBoxName.TabIndex = 1;
            // 
            // ButtonSave
            // 
            ButtonSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonSave.Location = new Point(12, 212);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(130, 31);
            ButtonSave.TabIndex = 2;
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
            // TextBoxCpf
            // 
            TextBoxCpf.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxCpf.Location = new Point(165, 91);
            TextBoxCpf.Name = "TextBoxCpf";
            TextBoxCpf.Size = new Size(321, 29);
            TextBoxCpf.TabIndex = 5;
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
            // TextBoxBirthdate
            // 
            TextBoxBirthdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxBirthdate.Location = new Point(165, 126);
            TextBoxBirthdate.Name = "TextBoxBirthdate";
            TextBoxBirthdate.Size = new Size(321, 29);
            TextBoxBirthdate.TabIndex = 7;
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
            ComboBoxPacs.Items.AddRange(new object[] { "PAC ALVORADA", "PAC COMPENSA", "PAC GALERIA DOS REMÉDIOS", "PAC LESTE", "PAC PARQUE DEZ", "PAC SÃO JOSÉ", "PAC STUDIO 5", "PAC SUMAÚMA", "PAC VIA NORTE", "PAC MUNICIPAL GALERIA ESPÍRITO SANTO", "PAC MUNICIPAL T4 - SHOPPING PHELIPPE DAOU", "Açaí - Baratão da Carne", "Buriti - Águas de Manaus", "Cupuaçu - Sesi Clube do Trabalhador", "Tucumâ - Shopping Phelippe Daou" });
            ComboBoxPacs.Location = new Point(165, 161);
            ComboBoxPacs.Name = "ComboBoxPacs";
            ComboBoxPacs.Size = new Size(321, 29);
            ComboBoxPacs.TabIndex = 8;
            ComboBoxPacs.Text = "SELECIONE";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 164);
            label5.Name = "label5";
            label5.Size = new Size(36, 21);
            label5.TabIndex = 9;
            label5.Text = "Pac:";
            // 
            // ButtonDelete
            // 
            ButtonDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonDelete.Location = new Point(186, 212);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new Size(130, 31);
            ButtonDelete.TabIndex = 10;
            ButtonDelete.Text = "Deletar";
            ButtonDelete.UseVisualStyleBackColor = true;
            ButtonDelete.Click += ButtonDelete_Click;
            // 
            // ButtonNew
            // 
            ButtonNew.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonNew.Location = new Point(356, 212);
            ButtonNew.Name = "ButtonNew";
            ButtonNew.Size = new Size(130, 31);
            ButtonNew.TabIndex = 11;
            ButtonNew.Text = "Novo";
            ButtonNew.UseVisualStyleBackColor = true;
            ButtonNew.Click += ButtonNew_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(16, 266);
            label6.Name = "label6";
            label6.Size = new Size(68, 21);
            label6.TabIndex = 13;
            label6.Text = "Clientes:";
            // 
            // ComboBoxCustomers
            // 
            ComboBoxCustomers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ComboBoxCustomers.FormattingEnabled = true;
            ComboBoxCustomers.Location = new Point(165, 263);
            ComboBoxCustomers.Name = "ComboBoxCustomers";
            ComboBoxCustomers.Size = new Size(321, 29);
            ComboBoxCustomers.TabIndex = 12;
            ComboBoxCustomers.Text = "SELECIONE";
            ComboBoxCustomers.SelectedIndexChanged += ComboBoxCustomers_SelectedIndexChanged;
            // 
            // LabelCustomerToMakeAppointment
            // 
            LabelCustomerToMakeAppointment.AutoSize = true;
            LabelCustomerToMakeAppointment.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            LabelCustomerToMakeAppointment.Location = new Point(16, 298);
            LabelCustomerToMakeAppointment.Name = "LabelCustomerToMakeAppointment";
            LabelCustomerToMakeAppointment.Size = new Size(0, 25);
            LabelCustomerToMakeAppointment.TabIndex = 14;
            // 
            // FormPerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 332);
            Controls.Add(LabelCustomerToMakeAppointment);
            Controls.Add(label6);
            Controls.Add(ComboBoxCustomers);
            Controls.Add(ButtonNew);
            Controls.Add(ButtonDelete);
            Controls.Add(label5);
            Controls.Add(ComboBoxPacs);
            Controls.Add(TextBoxBirthdate);
            Controls.Add(label4);
            Controls.Add(TextBoxCpf);
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
        private TextBox TextBoxCpf;
        private Label label3;
        private TextBox TextBoxBirthdate;
        private Label label4;
        private ComboBox ComboBoxPacs;
        private Label label5;
        private Button ButtonDelete;
        private Button ButtonNew;
        private Label label6;
        private ComboBox ComboBoxCustomers;
        private Label LabelCustomerToMakeAppointment;
    }
}