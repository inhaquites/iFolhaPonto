using iFolhaPonto.Models;
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
    public partial class frmCadFeriado : Form
    {
        public frmCadFeriado()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            populaComboTipos();
            LimpaDados();
            DesabilitaCampos();
            ExibirDados();
        }

        #region METODOS CRIADOS

        private void populaComboTipos()
        {
            // Bind combobox to dictionary
            Dictionary<string, string> vlrs = new Dictionary<string, string>();
            vlrs.Add("", "");
            vlrs.Add("N", "Nacional");
            vlrs.Add("E", "Estadual");
            vlrs.Add("M", "Municipal");
            cmbTipo.DataSource = new BindingSource(vlrs, null);
            cmbTipo.DisplayMember = "Value";
            cmbTipo.ValueMember = "Key";
            
            // Get combobox selection (in handler)
            string value = ((KeyValuePair<string, string>)cmbTipo.SelectedItem).Value;
        }

        private void ExibirDados()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Feriados.GetFeriados();
                dtgFeriados.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }        

        private void HabilitaCampos()
        {
            txtDescricao.Enabled = true;
            txtData.Enabled = true;
            cmbTipo.Enabled = true;
        }

        private void DesabilitaCampos()
        {
            txtDescricao.Enabled = false;
            txtData.Enabled = false;
            cmbTipo.Enabled = false;
        }

        private void LimpaDados()
        {
            txtID.Text = "";
            txtDescricao.Text = "";
            txtData.Text = "";
            cmbTipo.SelectedIndex = 0; ;
        }

        private Boolean VerificaCampos()
        {
            if (txtID.Text == "") //se fpr vazio é um novo registro
            {
                if (txtDescricao.Text == "")
                {
                    MessageBox.Show("Informe a Descrição do Feriado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (cmbTipo.SelectedIndex == 0)
                {
                    MessageBox.Show("Informe o Tipo do Feriado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void EditarRegistro()
        {
            txtID.Text = dtgFeriados.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = dtgFeriados.CurrentRow.Cells[1].Value.ToString().Trim();
            txtData.Text = dtgFeriados.CurrentRow.Cells[2].Value.ToString();
            cmbTipo.SelectedValue = dtgFeriados.CurrentRow.Cells[3].Value.ToString();

            btnSalvar.Enabled = true;
            btnCancelarEdicao.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = true;

            HabilitaCampos();
        }

        #endregion

        #region METODOS INTERNOS

        private void dtgFeriados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarRegistro();
        }

        #endregion

        #region BOTOES

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitaCampos();

            btnSalvar.Enabled = true;
            btnCancelarEdicao.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Result = MessageBox.Show("Deseja realmente excluir o registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    Feriados.Delete(Convert.ToInt32(txtID.Text));
                    MessageBox.Show("Registro Deletado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ExibirDados();
                    LimpaDados();
                    DesabilitaCampos();

                    btnSalvar.Enabled = false;
                    btnCancelarEdicao.Enabled = false;
                    btnNovo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnExcluir.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {
                try
                {
                    Feriados feriados = new Feriados();
                    if (txtID.Text != "")
                        feriados.ID = Convert.ToInt32(txtID.Text);
                    feriados.Descricao = txtDescricao.Text;
                    feriados.Data = Convert.ToDateTime(txtData.Text);
                    //N = Nacional; E = Estadual; M = Municipal
                    feriados.Tipo = cmbTipo.SelectedValue.ToString();

                    if (feriados.ID == 0)
                    {
                        Feriados.Add(feriados);
                        MessageBox.Show("Registro Salvo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Feriados.Update(feriados);
                        MessageBox.Show("Registro Atualizado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ExibirDados();
                    LimpaDados();
                    DesabilitaCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                }

                btnSalvar.Enabled = false;
                btnCancelarEdicao.Enabled = false;
                btnNovo.Enabled = true;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = false;
            }
            else
            {
                return;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarRegistro();
        }

        private void btnCancelarEdicao_Click(object sender, EventArgs e)
        {
            LimpaDados();

            btnSalvar.Enabled = false;
            btnCancelarEdicao.Enabled = false;
            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = false;

            DesabilitaCampos();
        }

        #endregion

    }
}
