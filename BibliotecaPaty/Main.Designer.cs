namespace BibliotecaPaty
{
    partial class Main
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gbox_adicionar = new System.Windows.Forms.GroupBox();
            this.cb_adicionar = new System.Windows.Forms.CheckBox();
            this.gbox_atualizar = new System.Windows.Forms.GroupBox();
            this.cb_atualizar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbox_adicionar.SuspendLayout();
            this.gbox_atualizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(874, 368);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(470, 22);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(337, 33);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gbox_adicionar
            // 
            this.gbox_adicionar.Controls.Add(this.cb_adicionar);
            this.gbox_adicionar.Location = new System.Drawing.Point(272, 14);
            this.gbox_adicionar.Name = "gbox_adicionar";
            this.gbox_adicionar.Size = new System.Drawing.Size(93, 43);
            this.gbox_adicionar.TabIndex = 2;
            this.gbox_adicionar.TabStop = false;
            this.gbox_adicionar.Text = "Adicionar";
            // 
            // cb_adicionar
            // 
            this.cb_adicionar.AutoSize = true;
            this.cb_adicionar.ForeColor = System.Drawing.Color.Black;
            this.cb_adicionar.Location = new System.Drawing.Point(9, 20);
            this.cb_adicionar.Name = "cb_adicionar";
            this.cb_adicionar.Size = new System.Drawing.Size(80, 19);
            this.cb_adicionar.TabIndex = 0;
            this.cb_adicionar.Text = "Selecionar";
            this.cb_adicionar.UseVisualStyleBackColor = true;
            this.cb_adicionar.CheckedChanged += new System.EventHandler(this.cb_adicionar_CheckedChanged);
            // 
            // gbox_atualizar
            // 
            this.gbox_atualizar.Controls.Add(this.cb_atualizar);
            this.gbox_atualizar.Location = new System.Drawing.Point(371, 14);
            this.gbox_atualizar.Name = "gbox_atualizar";
            this.gbox_atualizar.Size = new System.Drawing.Size(93, 43);
            this.gbox_atualizar.TabIndex = 3;
            this.gbox_atualizar.TabStop = false;
            this.gbox_atualizar.Text = "Atualizar";
            // 
            // cb_atualizar
            // 
            this.cb_atualizar.AutoSize = true;
            this.cb_atualizar.ForeColor = System.Drawing.Color.Black;
            this.cb_atualizar.Location = new System.Drawing.Point(6, 20);
            this.cb_atualizar.Name = "cb_atualizar";
            this.cb_atualizar.Size = new System.Drawing.Size(80, 19);
            this.cb_atualizar.TabIndex = 0;
            this.cb_atualizar.Text = "Selecionar";
            this.cb_atualizar.UseVisualStyleBackColor = true;
            this.cb_atualizar.CheckedChanged += new System.EventHandler(this.cb_atualizar_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.gbox_atualizar);
            this.Controls.Add(this.gbox_adicionar);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximumSize = new System.Drawing.Size(900, 1100);
            this.MinimumSize = new System.Drawing.Size(900, 450);
            this.Name = "Main";
            this.Style = MetroFramework.MetroColorStyle.Pink;
            this.Text = "Biblioteca da Paty V2.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbox_adicionar.ResumeLayout(false);
            this.gbox_adicionar.PerformLayout();
            this.gbox_atualizar.ResumeLayout(false);
            this.gbox_atualizar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnPrint;
        private GroupBox gbox_adicionar;
        private CheckBox cb_adicionar;
        private GroupBox gbox_atualizar;
        private CheckBox cb_atualizar;
    }
}