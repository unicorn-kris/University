
namespace Med_Center
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Имя = new System.Windows.Forms.ToolStrip();
            this.Добавить = new System.Windows.Forms.ToolStripDropDownButton();
            this.запись = new System.Windows.Forms.ToolStripButton();
            this.каб = new System.Windows.Forms.ToolStripButton();
            this.расп = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Имя.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Имя
            // 
            this.Имя.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Добавить,
            this.запись,
            this.каб,
            this.расп});
            this.Имя.Location = new System.Drawing.Point(0, 0);
            this.Имя.Name = "Имя";
            this.Имя.Size = new System.Drawing.Size(686, 25);
            this.Имя.TabIndex = 0;
            this.Имя.Text = "Добавить";
            this.Имя.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Имя_ItemClicked);
            // 
            // Добавить
            // 
            this.Добавить.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Добавить.Image = ((System.Drawing.Image)(resources.GetObject("Добавить.Image")));
            this.Добавить.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Добавить.Name = "Добавить";
            this.Добавить.Size = new System.Drawing.Size(72, 22);
            this.Добавить.Text = "Добавить";
            // 
            // запись
            // 
            this.запись.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.запись.Image = ((System.Drawing.Image)(resources.GetObject("запись.Image")));
            this.запись.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.запись.Name = "запись";
            this.запись.Size = new System.Drawing.Size(115, 22);
            this.запись.Text = "Записать пациента";
            // 
            // каб
            // 
            this.каб.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.каб.Image = ((System.Drawing.Image)(resources.GetObject("каб.Image")));
            this.каб.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.каб.Name = "каб";
            this.каб.Size = new System.Drawing.Size(119, 22);
            this.каб.Text = "Добавить кабинеты";
            // 
            // расп
            // 
            this.расп.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.расп.Image = ((System.Drawing.Image)(resources.GetObject("расп.Image")));
            this.расп.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.расп.Name = "расп";
            this.расп.Size = new System.Drawing.Size(146, 22);
            this.расп.Text = "Посмотреть расписание";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(686, 325);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Имя);
            this.Name = "Form1";
            this.Text = "MedCenter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Имя.ResumeLayout(false);
            this.Имя.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Имя;
        private System.Windows.Forms.ToolStripDropDownButton Добавить;
        private System.Windows.Forms.ToolStripButton запись;
        private System.Windows.Forms.ToolStripButton каб;
        private System.Windows.Forms.ToolStripButton расп;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

