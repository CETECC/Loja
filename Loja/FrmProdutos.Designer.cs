namespace Loja
{
    partial class FrmProdutos
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
            this.lstProdutos = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPreco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstProdutos
            // 
            this.lstProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colNome,
            this.colPreco,
            this.colDescricao});
            this.lstProdutos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstProdutos.FullRowSelect = true;
            this.lstProdutos.HideSelection = false;
            this.lstProdutos.Location = new System.Drawing.Point(0, 0);
            this.lstProdutos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstProdutos.MultiSelect = false;
            this.lstProdutos.Name = "lstProdutos";
            this.lstProdutos.Size = new System.Drawing.Size(713, 235);
            this.lstProdutos.TabIndex = 0;
            this.lstProdutos.UseCompatibleStateImageBehavior = false;
            this.lstProdutos.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            this.colNome.Width = 148;
            // 
            // colPreco
            // 
            this.colPreco.DisplayIndex = 3;
            this.colPreco.Text = "Preço";
            this.colPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colPreco.Width = 124;
            // 
            // colDescricao
            // 
            this.colDescricao.DisplayIndex = 2;
            this.colDescricao.Text = "Descrição";
            this.colDescricao.Width = 199;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Adicionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstProdutos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produtos";
            this.Load += new System.EventHandler(this.FrmProdutos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstProdutos;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.ColumnHeader colPreco;
        private System.Windows.Forms.ColumnHeader colDescricao;
        private System.Windows.Forms.Button button1;
    }
}