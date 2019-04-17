using iFolhaPonto.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace iFolhaPonto
{
    public partial class frmGeraFolhasPonto : Form
    {
        public frmGeraFolhasPonto()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            populaComboCompetencia();
            populaComboCentroCustos();

            btnPesquisar.Enabled = true;
            btnGerar.Enabled = false;
        }

        private void GeraDadosExcel()
        {
            // Inicia o componente Excel
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            //Cria uma planilha temporária na memória do computador
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //incluindo dados
            xlWorkSheet.Cells[1, 1] = "Linha 1";
            xlWorkSheet.Cells[1, 2] = "123";
            //xlWorkSheet.Cells[1, 3] = "456";
            xlWorkSheet.Cells[1, 4] = "789";
            xlWorkSheet.Cells[2, 1] = "linha 2";
            xlWorkSheet.Cells[2, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
            xlWorkSheet.Cells[2, 2] = "123";
            xlWorkSheet.Cells[2, 3] = "456";
            xlWorkSheet.Cells[2, 4] = "789";

            //Mesclar celulas ok
            xlWorkSheet.Range[xlWorkSheet.Cells[1, 2], xlWorkSheet.Cells[1, 3]].Merge();




            //Seleciona Range para por bordas
            Excel.Range tRange = xlWorkSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[2, 4]];
            tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            tRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

            //borda em tudo
            //Excel.Range tRange = xlWorkSheet.UsedRange;
            //tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            //tRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

            //o arquivo foi salvo na pasta Meus Documentos.
            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            //Salva o arquivo de acordo com a documentação do Excel.
            xlWorkBook.SaveAs(caminho + @"\arquivo.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
            Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            MessageBox.Show("Concluído. Verifique em " + caminho + @"\arquivo.xls");
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            GeraDadosExcel();
        }

        private void populaComboCompetencia()
        {
            // Bind combobox to dictionary
            Dictionary<string, string> vlrs = new Dictionary<string, string>();
            vlrs.Add("", "");
            vlrs.Add("1", "Janeiro");
            vlrs.Add("2", "Fevereiro");
            vlrs.Add("3", "Março");
            vlrs.Add("4", "Abril");
            vlrs.Add("5", "Maio");
            vlrs.Add("6", "Junho");
            vlrs.Add("7", "Julho");
            vlrs.Add("8", "Agosto");
            vlrs.Add("9", "Setembro");
            vlrs.Add("10", "Outubro");
            vlrs.Add("11", "Novembro");
            vlrs.Add("12", "Dezembro");
            cmbMesCompetencia.DataSource = new BindingSource(vlrs, null);
            cmbMesCompetencia.DisplayMember = "Value";
            cmbMesCompetencia.ValueMember = "Key";

            // Get combobox selection (in handler)
            string value = ((KeyValuePair<string, string>)cmbMesCompetencia.SelectedItem).Value;
        }

        private void populaComboCentroCustos()
        {
            // Bind combobox to dictionary
            Dictionary<string, string> vlrs = new Dictionary<string, string>();
            vlrs.Add("", "");

            System.Data.DataTable dt = Colaboradores.GetCentroCustos();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                vlrs.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[0].ToString());
            }

            cmbCentroCusto.DataSource = new BindingSource(vlrs, null);
            cmbCentroCusto.DisplayMember = "Value";
            cmbCentroCusto.ValueMember = "Key";

            // Get combobox selection (in handler)
            string value = ((KeyValuePair<string, string>)cmbCentroCusto.SelectedItem).Value;
        }
                
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {
                try
                {
                    Utils.populaDataGridView(ref dtgResultadoPesquisa, Colaboradores.GetColaboradoresPorCentroCusto(cmbCentroCusto.SelectedValue.ToString()));
                    dtgResultadoPesquisa.Columns[0].Width = 25;
                    dtgResultadoPesquisa.Columns[0].HeaderText = "";
                    dtgResultadoPesquisa.Columns[0].ReadOnly = false;
                    dtgResultadoPesquisa.Columns[0].Frozen = true;
                    dtgResultadoPesquisa.Columns[1].Visible = true;
                    dtgResultadoPesquisa.Columns[1].Width = 200;
                    dtgResultadoPesquisa.Columns[2].Width = 200;
                    dtgResultadoPesquisa.Columns[3].Width = 200;

                    if (dtgResultadoPesquisa.Rows.Count > 0)
                    {
                        btnGerar.Enabled = true;
                    }
                    else
                    {
                        btnGerar.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                }
            }
        }        

        private Boolean VerificaCampos()
        {
            if (cmbCentroCusto.SelectedIndex == 0)
            {
                MessageBox.Show("Informe o Centro Custo", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbMesCompetencia.SelectedIndex == 0)
            {
                MessageBox.Show("Informe o Mês de Competência", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtAnoCompetencia.Text == "")
            {
                MessageBox.Show("Informe o Ano de Competência", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void dtgResultadoPesquisa_MouseUp(object sender, MouseEventArgs e)
        {
            dtgResultadoPesquisa.CurrentCell = dtgResultadoPesquisa[0, dtgResultadoPesquisa.CurrentCell.RowIndex];
        }

        private void chkMarcaTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMarcaTodos.Checked)
            {
                for (int i = 0; i < dtgResultadoPesquisa.Rows.Count; i++)
                {
                    dtgResultadoPesquisa.Rows[i].Cells[0].Value = 1;
                }
            }
            else
            {
                for (int i = 0; i < dtgResultadoPesquisa.Rows.Count; i++)
                {
                    dtgResultadoPesquisa.Rows[i].Cells[0].Value = 0;
                }
            }

        }
    }
}
