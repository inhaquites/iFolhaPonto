namespace iFolhaPonto
{
    partial class frmGeraFolhasPonto
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgResultadoPesquisa = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAnoCompetencia = new System.Windows.Forms.TextBox();
            this.cmbMesCompetencia = new System.Windows.Forms.ComboBox();
            this.cmbCentroCusto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btnPesquisar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGerar = new System.Windows.Forms.ToolStripButton();
            this.chkMarcaTodos = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultadoPesquisa)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkMarcaTodos);
            this.groupBox1.Controls.Add(this.dtgResultadoPesquisa);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(928, 483);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // dtgResultadoPesquisa
            // 
            this.dtgResultadoPesquisa.AllowUserToAddRows = false;
            this.dtgResultadoPesquisa.AllowUserToDeleteRows = false;
            this.dtgResultadoPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgResultadoPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResultadoPesquisa.Location = new System.Drawing.Point(9, 113);
            this.dtgResultadoPesquisa.Name = "dtgResultadoPesquisa";
            this.dtgResultadoPesquisa.RowTemplate.Height = 24;
            this.dtgResultadoPesquisa.Size = new System.Drawing.Size(913, 364);
            this.dtgResultadoPesquisa.TabIndex = 23;
            this.dtgResultadoPesquisa.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dtgResultadoPesquisa_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtAnoCompetencia);
            this.groupBox2.Controls.Add(this.cmbMesCompetencia);
            this.groupBox2.Controls.Add(this.cmbCentroCusto);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(9, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(913, 70);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(530, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Competência";
            // 
            // txtAnoCompetencia
            // 
            this.txtAnoCompetencia.Location = new System.Drawing.Point(753, 19);
            this.txtAnoCompetencia.Name = "txtAnoCompetencia";
            this.txtAnoCompetencia.Size = new System.Drawing.Size(52, 22);
            this.txtAnoCompetencia.TabIndex = 4;
            // 
            // cmbMesCompetencia
            // 
            this.cmbMesCompetencia.FormattingEnabled = true;
            this.cmbMesCompetencia.Location = new System.Drawing.Point(626, 17);
            this.cmbMesCompetencia.Name = "cmbMesCompetencia";
            this.cmbMesCompetencia.Size = new System.Drawing.Size(121, 24);
            this.cmbMesCompetencia.TabIndex = 3;
            // 
            // cmbCentroCusto
            // 
            this.cmbCentroCusto.FormattingEnabled = true;
            this.cmbCentroCusto.Location = new System.Drawing.Point(100, 17);
            this.cmbCentroCusto.Name = "cmbCentroCusto";
            this.cmbCentroCusto.Size = new System.Drawing.Size(360, 24);
            this.cmbCentroCusto.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Centro Custo";
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPesquisar,
            this.toolStripSeparator3,
            this.btnGerar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(952, 39);
            this.tsMenu.TabIndex = 3;
            this.tsMenu.Text = "toolStrip1";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPesquisar.Image = global::iFolhaPonto.Properties.Resources.Pesquisar;
            this.btnPesquisar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPesquisar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(36, 36);
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btnGerar
            // 
            this.btnGerar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGerar.Enabled = false;
            this.btnGerar.Image = global::iFolhaPonto.Properties.Resources.GeraFolhas2;
            this.btnGerar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGerar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(36, 36);
            this.btnGerar.Text = "Gerar Planilhas";
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // chkMarcaTodos
            // 
            this.chkMarcaTodos.AutoSize = true;
            this.chkMarcaTodos.Location = new System.Drawing.Point(9, 86);
            this.chkMarcaTodos.Name = "chkMarcaTodos";
            this.chkMarcaTodos.Size = new System.Drawing.Size(118, 21);
            this.chkMarcaTodos.TabIndex = 24;
            this.chkMarcaTodos.Text = "Marcar Todos";
            this.chkMarcaTodos.UseVisualStyleBackColor = true;
            this.chkMarcaTodos.CheckedChanged += new System.EventHandler(this.chkMarcaTodos_CheckedChanged);
            // 
            // frmGeraFolhasPonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 537);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGeraFolhasPonto";
            this.ShowIcon = false;
            this.Text = "Gera Folhas Ponto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultadoPesquisa)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbCentroCusto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtgResultadoPesquisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAnoCompetencia;
        private System.Windows.Forms.ComboBox cmbMesCompetencia;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btnPesquisar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnGerar;
        private System.Windows.Forms.CheckBox chkMarcaTodos;
    }
}