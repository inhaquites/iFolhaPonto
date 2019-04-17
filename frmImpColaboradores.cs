using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using iFolhaPonto.Models;

namespace iFolhaPonto
{
    public partial class frmImpColaboradores : Form
    {
        string arquivoExcel;

        public frmImpColaboradores()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            LimpaDataGrid();
            btnImportar.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            CarregaDadosExcel();

            btnImportar.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int CountJaCadastrados = 0;
            int RegistrosCarregadosDoExcel = dtgDadosExternos.Rows.Count;

            for (int i = 0; i < dtgDadosExternos.Rows.Count; i++)
            {
                if(!ColaboradorJaCadastrado(dtgDadosExternos.Rows[i].Cells[4].Value.ToString()))
                {
                    Colaboradores colab = new Colaboradores
                    {
                        Cod = dtgDadosExternos.Rows[i].Cells[0].Value.ToString().Trim(),
                        Colaborador = dtgDadosExternos.Rows[i].Cells[1].Value.ToString().Trim(),
                        CentroCusto = dtgDadosExternos.Rows[i].Cells[2].Value.ToString().Trim(),
                        Depto = dtgDadosExternos.Rows[i].Cells[3].Value.ToString().Trim(),
                        CPF = dtgDadosExternos.Rows[i].Cells[4].Value.ToString().Trim()
                    };
                    Colaboradores.Add(colab);
                }
                else
                {
                    CountJaCadastrados++;
                }
            }

            if (RegistrosCarregadosDoExcel == CountJaCadastrados)
            {
                MessageBox.Show("Os Registos não puderam ser importados pois todos os CPFs já constam na base de dados", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (CountJaCadastrados > 0)
            {
                MessageBox.Show("Nem Todos os registos puderam ser importados pois alguns CPFs já constam na base de dados", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (CountJaCadastrados == 0)
            {
                MessageBox.Show("Registros importados com sucesso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ColaboradorJaCadastrado(dtgDadosExternos.Rows[0].Cells[4].Value.ToString());
        }

        
        private void CarregaDadosExcel()
        {
            try
            {
                LimpaDataGrid();

                OpenFileDialog vAbreArq = new OpenFileDialog();
                vAbreArq.Filter = "Arquivo do Excel 2003|*.xls";
                vAbreArq.Title = "Selecione o Arquivo";
                if (vAbreArq.ShowDialog() == DialogResult.OK)
                {
                    arquivoExcel = vAbreArq.FileName;

                    //converte os dados do Excel para um DataTable
                    DataTable dt = GetTabelaExcel(arquivoExcel);
                    //ajusta a largura das colunas aos dados
                    dtgDadosExternos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dtgDadosExternos.DataSource = dt;
                    //No total de registros
                    lblRegistros.Text = (dtgDadosExternos.Rows.Count).ToString() + " Registros carregados...";
                    string[] listaNomeColunas = dt.Columns.OfType<DataColumn>().Select(x => x.ColumnName).ToArray();
                }

                if (dtgDadosExternos.Rows.Count > 0)
                    btnSalvar.Enabled = true;
                else
                    btnSalvar.Enabled = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro :" + ex.Message);
            }
        }

        private DataTable GetTabelaExcel(string arquivoExcel)
        {
            DataTable dt = new DataTable();
            try
            {
                //pega a extensão do arquivo
                string Ext = Path.GetExtension(arquivoExcel);
                string connectionString = "";
                //verifica a versão do Excel pela extensão
                if (Ext == ".xls")
                { //para o  Excel 97-03    
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" + arquivoExcel + "; Extended Properties = 'Excel 8.0;HDR=YES'";
                }
                else if (Ext == ".xlsx")
                { //para o  Excel 07 e superior
                    connectionString = "Provider=Microsoft.ACE.OLEDB.16.0; Data Source =" + arquivoExcel + "; Extended Properties = 'Excel 8.0;HDR=YES'";
                }
                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
                cmd.Connection = conn;
                conn.Open();
                DataTable dtSchema;
                dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string nomePlanilha = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                conn.Close();
                //le todos os dados da planilha para o Data Table    
                conn.Open();
                cmd.CommandText = "SELECT * From [" + nomePlanilha + "]";
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dt);
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtgDadosExternos.DataSource = null;
            dtgDadosExternos.Rows.Clear();
            dtgDadosExternos.Columns.Clear();
            lblRegistros.Text = "0 Registros carregados...";

            btnImportar.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void LimpaDataGrid()
        {
            dtgDadosExternos.DataSource = null;
            dtgDadosExternos.Rows.Clear();
            dtgDadosExternos.Columns.Clear();
        }

        private Boolean ColaboradorJaCadastrado(string CPF)
        {
            DataTable dt = new DataTable();
            dt = Colaboradores.GetColaboradorPorCPF(CPF);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }

}