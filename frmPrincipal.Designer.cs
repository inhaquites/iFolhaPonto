namespace iFolhaPonto
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.CadastraFeriados = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CadastraColaborador = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ImportaColaboradores = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.GeraFolhas = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CadastraFeriados,
            this.toolStripSeparator1,
            this.CadastraColaborador,
            this.toolStripSeparator2,
            this.ImportaColaboradores,
            this.toolStripSeparator3,
            this.GeraFolhas});
            this.Menu.Location = new System.Drawing.Point(0, 28);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1411, 79);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Menu";
            // 
            // CadastraFeriados
            // 
            this.CadastraFeriados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CadastraFeriados.Image = global::iFolhaPonto.Properties.Resources.Calendario;
            this.CadastraFeriados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CadastraFeriados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CadastraFeriados.Name = "CadastraFeriados";
            this.CadastraFeriados.Size = new System.Drawing.Size(76, 76);
            this.CadastraFeriados.Text = "Cadastrar Feriados";
            this.CadastraFeriados.Click += new System.EventHandler(this.CadastraFeriados_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 79);
            // 
            // CadastraColaborador
            // 
            this.CadastraColaborador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CadastraColaborador.Image = global::iFolhaPonto.Properties.Resources.Colaborador;
            this.CadastraColaborador.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CadastraColaborador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CadastraColaborador.Name = "CadastraColaborador";
            this.CadastraColaborador.Size = new System.Drawing.Size(76, 76);
            this.CadastraColaborador.Text = "Cadastrar Colaboradores";
            this.CadastraColaborador.ToolTipText = "Cadastrar Colaboradores";
            this.CadastraColaborador.Click += new System.EventHandler(this.CadastraColaborador_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 79);
            // 
            // ImportaColaboradores
            // 
            this.ImportaColaboradores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ImportaColaboradores.Image = global::iFolhaPonto.Properties.Resources.ImportarColaborador;
            this.ImportaColaboradores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ImportaColaboradores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImportaColaboradores.Name = "ImportaColaboradores";
            this.ImportaColaboradores.Size = new System.Drawing.Size(76, 76);
            this.ImportaColaboradores.Text = "Importar Colaboradores de Excel";
            this.ImportaColaboradores.Click += new System.EventHandler(this.ImportaColaboradores_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 79);
            // 
            // GeraFolhas
            // 
            this.GeraFolhas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GeraFolhas.Image = global::iFolhaPonto.Properties.Resources.GeraFolhas;
            this.GeraFolhas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GeraFolhas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GeraFolhas.Name = "GeraFolhas";
            this.GeraFolhas.Size = new System.Drawing.Size(76, 76);
            this.GeraFolhas.Text = "Gera Folhas Ponto";
            this.GeraFolhas.Click += new System.EventHandler(this.GeraFolhas_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 630);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1411, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSobre});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1411, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnSobre
            // 
            this.btnSobre.Name = "btnSobre";
            this.btnSobre.Size = new System.Drawing.Size(60, 24);
            this.btnSobre.Text = "Sobre";
            this.btnSobre.Click += new System.EventHandler(this.btnSobre_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 652);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "iDrigo";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStripButton CadastraFeriados;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CadastraColaborador;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ImportaColaboradores;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton GeraFolhas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSobre;
    }
}

