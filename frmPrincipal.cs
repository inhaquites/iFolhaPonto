using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iFolhaPonto
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            CriarBanco();
            CriarTabelas();
        }

        private void CriarBanco()
        {
            try
            {
                DalHelper.CriarBancoSQLite();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void CriarTabelas()
        {
            try
            {
                DalHelper.CriarTabelasSQlite();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void CadastraFeriados_Click(object sender, EventArgs e)
        {
            frmCadFeriado frm = new frmCadFeriado();
            Utils.abrirForm(true, frm, this);
        }
        
        private void CadastraColaborador_Click(object sender, EventArgs e)
        {
            frmCadColaboradores frm = new frmCadColaboradores();
            Utils.abrirForm(true, frm, this);
        }

        private void ImportaColaboradores_Click(object sender, EventArgs e)
        {
            frmImpColaboradores frm = new frmImpColaboradores();
            Utils.abrirForm(true, frm, this);
        }

        private void GeraFolhas_Click(object sender, EventArgs e)
        {
            frmGeraFolhasPonto frm = new frmGeraFolhasPonto();
            Utils.abrirForm(true, frm, this);
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            frmSobre frm = new frmSobre();
            Utils.abrirForm(true, frm, this);
        }
    }
}
