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
    public partial class frmCadColaboradores : Form
    {
        public frmCadColaboradores()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            LimpaDados();
            DesabilitaCampos();
            ExibirDados();
        }

        #region METODOS CRIADOS

        private void ExibirDados()
        {
            try
            {
                DataTable dt = new DataTable();                
                dt = Colaboradores.GetColaboradores();
                dtgColaboradores.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void HabilitaCampos()
        {
            txtCod.Enabled = true;
            txtColaborador.Enabled = true;
            txtCPF.Enabled = true;
            txtDepto.Enabled = true;
            txtCentroCusto.Enabled = true;
        }

        private void DesabilitaCampos()
        {
            txtCod.Enabled = false;
            txtColaborador.Enabled = false;
            txtCPF.Enabled = false;
            txtDepto.Enabled = false;
            txtCentroCusto.Enabled = false;
        }

        private void LimpaDados()
        {
            txtID.Text = "";
            txtCod.Text = "";
            txtColaborador.Text = "";
            txtCPF.Text = "";
            txtDepto.Text = "";
            txtCentroCusto.Text = "";
        }

        private Boolean VerificaCampos()
        {
            if (txtID.Text == "") //se fpr vazio é um novo registro
            {
                if (txtCod.Text == "")
                {
                    MessageBox.Show("Informe o COD.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (txtColaborador.Text == "")
                {
                    MessageBox.Show("Informe o Colaborador.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (txtCPF.Text == "")
                {
                    MessageBox.Show("Informe o CPF.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (txtDepto.Text == "")
                {
                    MessageBox.Show("Informe o Depto.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (txtCentroCusto.Text == "")
                {
                    MessageBox.Show("Informe o Centro Custo.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void EditarRegistro()
        {
            txtID.Text = dtgColaboradores.CurrentRow.Cells[0].Value.ToString();
            txtCod.Text = dtgColaboradores.CurrentRow.Cells[1].Value.ToString().Trim();
            txtColaborador.Text = dtgColaboradores.CurrentRow.Cells[2].Value.ToString();
            txtCentroCusto.Text = dtgColaboradores.CurrentRow.Cells[3].Value.ToString();
            txtDepto.Text = dtgColaboradores.CurrentRow.Cells[4].Value.ToString();
            txtCPF.Text = dtgColaboradores.CurrentRow.Cells[5].Value.ToString();

            btnSalvar.Enabled = true;
            btnCancelarEdicao.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = true;

            HabilitaCampos();
        }

        #endregion

        #region METODOS INTERNOS

        private void dtgColaboradores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarRegistro();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {
                try
                {
                    Colaboradores colaboradores = new Colaboradores();
                    if (txtID.Text != "")
                        colaboradores.ID = Convert.ToInt32(txtID.Text);
                    colaboradores.Cod = txtCod.Text;
                    colaboradores.Colaborador = txtColaborador.Text;
                    colaboradores.CentroCusto = txtCentroCusto.Text;
                    colaboradores.Depto = txtDepto.Text;
                    colaboradores.CPF = txtCPF.Text;



                    if (colaboradores.ID == 0)
                    {
                        Colaboradores.Add(colaboradores);
                        MessageBox.Show("Registro Salvo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Colaboradores.Update(colaboradores);
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Result = MessageBox.Show("Deseja realmente excluir o registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    Colaboradores.Delete(Convert.ToInt32(txtID.Text));
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
