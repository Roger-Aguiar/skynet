namespace Skynet2
{
    partial class FormSkynet
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonSearchAppointment = new Button();
            buttonMakeAppointment = new Button();
            buttonRegisterPerson = new Button();
            SuspendLayout();
            // 
            // buttonSearchAppointment
            // 
            buttonSearchAppointment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSearchAppointment.Location = new Point(12, 12);
            buttonSearchAppointment.Name = "buttonSearchAppointment";
            buttonSearchAppointment.Size = new Size(252, 44);
            buttonSearchAppointment.TabIndex = 0;
            buttonSearchAppointment.Text = "Consultar agendamento";
            buttonSearchAppointment.UseVisualStyleBackColor = true;
            buttonSearchAppointment.Click += buttonSearchAppointment_Click;
            // 
            // buttonMakeAppointment
            // 
            buttonMakeAppointment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonMakeAppointment.Location = new Point(12, 62);
            buttonMakeAppointment.Name = "buttonMakeAppointment";
            buttonMakeAppointment.Size = new Size(252, 44);
            buttonMakeAppointment.TabIndex = 1;
            buttonMakeAppointment.Text = "Fazer agendamentos";
            buttonMakeAppointment.UseVisualStyleBackColor = true;
            buttonMakeAppointment.Click += buttonMakeAppointment_Click;
            // 
            // buttonRegisterPerson
            // 
            buttonRegisterPerson.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonRegisterPerson.Location = new Point(12, 112);
            buttonRegisterPerson.Name = "buttonRegisterPerson";
            buttonRegisterPerson.Size = new Size(252, 44);
            buttonRegisterPerson.TabIndex = 2;
            buttonRegisterPerson.Text = "Cadastrar cliente";
            buttonRegisterPerson.UseVisualStyleBackColor = true;
            buttonRegisterPerson.Click += buttonRegisterPerson_Click;
            // 
            // FormSkynet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(276, 165);
            Controls.Add(buttonRegisterPerson);
            Controls.Add(buttonMakeAppointment);
            Controls.Add(buttonSearchAppointment);
            MaximizeBox = false;
            Name = "FormSkynet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Skynet";
            Load += FormSkynet_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSearchAppointment;
        private Button buttonMakeAppointment;
        private Button buttonRegisterPerson;
    }
}