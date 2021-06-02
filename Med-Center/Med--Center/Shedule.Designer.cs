
namespace Med__Center
{
    partial class Shedule
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
            this.components = new System.ComponentModel.Container();
            this.appointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medCenterDataSet = new Med__Center.MedCenterDataSet();
            this.appointmentsTableAdapter = new Med__Center.MedCenterDataSetTableAdapters.AppointmentsTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDoc = new System.Windows.Forms.Button();
            this.buttonPat = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medCenterDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // appointmentsBindingSource
            // 
            this.appointmentsBindingSource.DataMember = "Appointments";
            this.appointmentsBindingSource.DataSource = this.medCenterDataSet;
            // 
            // medCenterDataSet
            // 
            this.medCenterDataSet.DataSetName = "MedCenterDataSet";
            this.medCenterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // appointmentsTableAdapter
            // 
            this.appointmentsTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(28, 289);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(349, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "ВРАЧ";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(505, 289);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(314, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.Text = "ПАЦИЕНТ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Врач";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Пациент";
            // 
            // buttonDoc
            // 
            this.buttonDoc.Location = new System.Drawing.Point(383, 287);
            this.buttonDoc.Name = "buttonDoc";
            this.buttonDoc.Size = new System.Drawing.Size(75, 23);
            this.buttonDoc.TabIndex = 9;
            this.buttonDoc.Text = "Поиск";
            this.buttonDoc.UseVisualStyleBackColor = true;
            this.buttonDoc.Click += new System.EventHandler(this.buttonDoc_Click);
            // 
            // buttonPat
            // 
            this.buttonPat.Location = new System.Drawing.Point(825, 289);
            this.buttonPat.Name = "buttonPat";
            this.buttonPat.Size = new System.Drawing.Size(75, 23);
            this.buttonPat.TabIndex = 10;
            this.buttonPat.Text = "Поиск";
            this.buttonPat.UseVisualStyleBackColor = true;
            this.buttonPat.Click += new System.EventHandler(this.buttonPat_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 1);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(909, 244);
            this.textBox1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Выполнить поиск";
            // 
            // Shedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 322);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonPat);
            this.Controls.Add(this.buttonDoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "Shedule";
            this.Text = "Shedule";
            this.Load += new System.EventHandler(this.Shedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medCenterDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MedCenterDataSet medCenterDataSet;
        private System.Windows.Forms.BindingSource appointmentsBindingSource;
        private MedCenterDataSetTableAdapters.AppointmentsTableAdapter appointmentsTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDoc;
        private System.Windows.Forms.Button buttonPat;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}