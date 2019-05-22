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

        private void GeraDadosExcelDe01a30()
        {
            for (int i = 0; i < dtgResultadoPesquisa.Rows.Count; i++)
            {
                if (dtgResultadoPesquisa[0, i].Value.ToString() == "1")
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
                    xlWorkSheet.Cells[1, 1] = "COD: " + dtgResultadoPesquisa[1, i].Value;
                    xlWorkSheet.Cells[2, 1] = "COLABORADOR: " + dtgResultadoPesquisa[2, i].Value;
                    xlWorkSheet.Cells[3, 1] = "CC: " + dtgResultadoPesquisa[3, i].Value;
                    xlWorkSheet.Cells[4, 1] = "DEPTO: " + dtgResultadoPesquisa[4, i].Value;
                    xlWorkSheet.Cells[5, 1] = "FUNÇÃO: " + dtgResultadoPesquisa[6, i].Value;
                    xlWorkSheet.Cells[6, 1] = "CPF: " + dtgResultadoPesquisa[5, i].Value;

                    xlWorkSheet.Cells[8, 1] = "Dias";
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[9, 2]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[9, 2]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[9, 2]].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    xlWorkSheet.Cells[8, 3] = "Entrada";                    
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 3], xlWorkSheet.Cells[9, 3]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 3], xlWorkSheet.Cells[9, 3]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 3], xlWorkSheet.Cells[9, 3]].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    xlWorkSheet.Cells[8, 4] = "Almoço";
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 4], xlWorkSheet.Cells[8, 5]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 4], xlWorkSheet.Cells[8, 5]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    xlWorkSheet.Cells[9, 4] = "Saída";
                    xlWorkSheet.Cells[9, 4].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.Cells[9, 5] = "Retorno";
                    xlWorkSheet.Cells[9, 5].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    xlWorkSheet.Cells[8, 6] = "Saída";
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 6], xlWorkSheet.Cells[9, 6]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 6], xlWorkSheet.Cells[9, 6]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 6], xlWorkSheet.Cells[9, 6]].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    xlWorkSheet.Cells[8, 7] = "Observações";
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 7], xlWorkSheet.Cells[9, 7]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 7], xlWorkSheet.Cells[9, 7]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 7], xlWorkSheet.Cells[9, 7]].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    

                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[9, 7]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                    
                    //Seleciona Range para por bordas
                    Excel.Range tRange = xlWorkSheet.Range[xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[9, 7]];
                    tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    tRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                    int DiasDoMes = DateTime.DaysInMonth(Convert.ToInt16(txtAnoCompetencia.Text), Convert.ToInt16(cmbMesCompetencia.SelectedValue));
                    DateTime dtInicio = Convert.ToDateTime("01/"+ Convert.ToInt16(cmbMesCompetencia.SelectedValue)+"/"+ Convert.ToInt16(txtAnoCompetencia.Text));
                    int linhaInicio = 10;
                    for (int j = 0; j < DiasDoMes; j++)
                    {
                        //dtInicio.Date.ToShortDateString()
                        //"01/04/2019"
                        //? dtInicio.DayOfWeek
                        //Monday
                        xlWorkSheet.Cells[linhaInicio + j, 1] = retornaDiaDaSemana(dtInicio.AddDays(j));
                        if (retornaDiaDaSemana(dtInicio.AddDays(j)) == "SAB")
                        {
                            xlWorkSheet.Cells[linhaInicio + j, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 6].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 7].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                        }
                        else if (retornaDiaDaSemana(dtInicio.AddDays(j)) == "DOM")
                        {
                            xlWorkSheet.Cells[linhaInicio + j, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 3].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 4].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 6].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 7].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                        }
                        else
                        {
                            DateTime data = dtInicio.AddDays(j);
                            System.Data.DataTable dt = Feriados.GetFeriadosPorData(data);

                            if(dt.Rows.Count>0)
                            {
                                //xlWorkSheet.Cells[linhaInicio + j, 3] = dt.Rows[0].ItemArray[1].ToString(); nome do feriado
                                xlWorkSheet.Cells[linhaInicio + j, 3] = "FERIADO";
                                xlWorkSheet.Range[xlWorkSheet.Cells[linhaInicio + j, 3], xlWorkSheet.Cells[linhaInicio + j, 7]].Merge();
                                xlWorkSheet.Range[xlWorkSheet.Cells[linhaInicio + j, 3], xlWorkSheet.Cells[linhaInicio + j, 7]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                                xlWorkSheet.Range[xlWorkSheet.Cells[linhaInicio + j, 3], xlWorkSheet.Cells[linhaInicio + j, 7]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            }
                        }

                        xlWorkSheet.Cells[linhaInicio + j, 2] = " "+dtInicio.AddDays(j).ToShortDateString();
                    }

                    Excel.Range tRange2 = xlWorkSheet.Range[xlWorkSheet.Cells[linhaInicio, 1], xlWorkSheet.Cells[(linhaInicio + DiasDoMes)-1, 7]];
                    tRange2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    tRange2.Borders.Weight = Excel.XlBorderWeight.xlThin;

                    //tamanho das colunas
                    xlWorkSheet.Columns[1].ColumnWidth = 4.9;
                    xlWorkSheet.Columns[2].ColumnWidth = 10.2;
                    xlWorkSheet.Columns[3].ColumnWidth = 8.5;
                    xlWorkSheet.Columns[4].ColumnWidth = 8.5;
                    xlWorkSheet.Columns[5].ColumnWidth = 8.5;
                    xlWorkSheet.Columns[6].ColumnWidth = 8.5;
                    xlWorkSheet.Columns[7].ColumnWidth = 32;

                    //pinta a celula
                    //xlWorkSheet.Cells[2, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                    //Mesclar celulas ok
                    //xlWorkSheet.Range[xlWorkSheet.Cells[1, 2], xlWorkSheet.Cells[1, 3]].Merge();

                    //Seleciona Range para por bordas
                    //Excel.Range tRange = xlWorkSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[2, 4]];
                    //tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    //tRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                    //borda em tudo
                    //Excel.Range tRange = xlWorkSheet.UsedRange;
                    //tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    //tRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                    //o arquivo foi salvo na pasta Meus Documentos.
                    //string caminho = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    string caminho = lblcaminho.Text;
                    string nomeArquivoExcel = dtgResultadoPesquisa[3, i].Value + "-" + dtgResultadoPesquisa[2, i].Value + ".xls";
                    //string nomeArquivoPDF = dtgResultadoPesquisa[3, i].Value + "-" + dtgResultadoPesquisa[2, i].Value + ".pdf";

                    //Salva o arquivo de acordo com a documentação do Excel.
                    xlWorkBook.SaveAs(caminho + @"\" + nomeArquivoExcel, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                    Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                }
            }

            System.Diagnostics.Process.Start("taskkill", "/f /im EXCEL.exe");            

            MessageBox.Show("Arquivos Gerados.");
        }

        private void GeraDadosExcelDe21a20()
        {
            int ultimaLinhaGerada = 0;
            for (int i = 0; i < dtgResultadoPesquisa.Rows.Count; i++)
            {
                if (dtgResultadoPesquisa[0, i].Value.ToString() == "1")
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

                    #region CABEÇALHO
                    //incluindo dados
                    xlWorkSheet.Cells[1, 1] = "COD: " + dtgResultadoPesquisa[1, i].Value;
                    xlWorkSheet.Cells[2, 1] = "COLABORADOR: " + dtgResultadoPesquisa[2, i].Value;
                    xlWorkSheet.Cells[3, 1] = "CC: " + dtgResultadoPesquisa[3, i].Value;
                    xlWorkSheet.Cells[4, 1] = "DEPTO: " + dtgResultadoPesquisa[4, i].Value;
                    xlWorkSheet.Cells[5, 1] = "FUNÇÃO: " + dtgResultadoPesquisa[6, i].Value;
                    xlWorkSheet.Cells[6, 1] = "CPF: " + dtgResultadoPesquisa[5, i].Value;

                    xlWorkSheet.Cells[8, 1] = "Dias";
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[9, 2]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[9, 2]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[9, 2]].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    xlWorkSheet.Cells[8, 3] = "Entrada";
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 3], xlWorkSheet.Cells[9, 3]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 3], xlWorkSheet.Cells[9, 3]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 3], xlWorkSheet.Cells[9, 3]].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    xlWorkSheet.Cells[8, 4] = "Almoço";
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 4], xlWorkSheet.Cells[8, 5]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 4], xlWorkSheet.Cells[8, 5]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    xlWorkSheet.Cells[9, 4] = "Saída";
                    xlWorkSheet.Cells[9, 4].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.Cells[9, 5] = "Retorno";
                    xlWorkSheet.Cells[9, 5].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    xlWorkSheet.Cells[8, 6] = "Saída";
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 6], xlWorkSheet.Cells[9, 6]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 6], xlWorkSheet.Cells[9, 6]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 6], xlWorkSheet.Cells[9, 6]].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    xlWorkSheet.Cells[8, 7] = "Observações";
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 7], xlWorkSheet.Cells[9, 7]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 7], xlWorkSheet.Cells[9, 7]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 7], xlWorkSheet.Cells[9, 7]].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                    xlWorkSheet.Range[xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[9, 7]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);

                    //Seleciona Range para por bordas
                    Excel.Range tRange = xlWorkSheet.Range[xlWorkSheet.Cells[8, 1], xlWorkSheet.Cells[9, 7]];
                    tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    tRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                    #endregion CABEÇALHO

                    //int DiasDoMes = DateTime.DaysInMonth(Convert.ToInt16(txtAnoCompetencia.Text), Convert.ToInt16(cmbMesCompetencia.SelectedValue));                    
                    //DateTime dtInicio = Convert.ToDateTime("01/" + Convert.ToInt16(cmbMesCompetencia.SelectedValue) + "/" + Convert.ToInt16(txtAnoCompetencia.Text));
                    DateTime dtInicio = Convert.ToDateTime("21/" + (Convert.ToInt16(cmbMesCompetencia.SelectedValue) - 1) + "/" + Convert.ToInt16(txtAnoCompetencia.Text));
                    DateTime dtFim = Convert.ToDateTime("20/" + Convert.ToInt16(cmbMesCompetencia.SelectedValue)  + "/" + Convert.ToInt16(txtAnoCompetencia.Text));
                    int DiasDoMes = (dtFim - dtInicio).Days + 1;
                    int linhaInicio = 10;
                    
                    //for (int j = 0; j < DiasDoMes; j++)
                    for (int j = 0; j < DiasDoMes; j++)
                    {
                        //dtInicio.Date.ToShortDateString()
                        //"01/04/2019"
                        //? dtInicio.DayOfWeek
                        //Monday
                        xlWorkSheet.Cells[linhaInicio + j, 1] = retornaDiaDaSemana(dtInicio.AddDays(j));
                        if (retornaDiaDaSemana(dtInicio.AddDays(j)) == "SAB")
                        {
                            xlWorkSheet.Cells[linhaInicio + j, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 6].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 7].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                        }
                        else if (retornaDiaDaSemana(dtInicio.AddDays(j)) == "DOM")
                        {
                            xlWorkSheet.Cells[linhaInicio + j, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 3].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 4].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 5].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 6].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                            xlWorkSheet.Cells[linhaInicio + j, 7].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                        }
                        else
                        {
                            DateTime data = dtInicio.AddDays(j);
                            System.Data.DataTable dt = Feriados.GetFeriadosPorData(data);

                            if (dt.Rows.Count > 0)
                            {
                                //xlWorkSheet.Cells[linhaInicio + j, 3] = dt.Rows[0].ItemArray[1].ToString(); nome do feriado
                                xlWorkSheet.Cells[linhaInicio + j, 3] = "FERIADO";
                                xlWorkSheet.Range[xlWorkSheet.Cells[linhaInicio + j, 3], xlWorkSheet.Cells[linhaInicio + j, 7]].Merge();
                                xlWorkSheet.Range[xlWorkSheet.Cells[linhaInicio + j, 3], xlWorkSheet.Cells[linhaInicio + j, 7]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan);
                                xlWorkSheet.Range[xlWorkSheet.Cells[linhaInicio + j, 3], xlWorkSheet.Cells[linhaInicio + j, 7]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            }
                        }

                        xlWorkSheet.Cells[linhaInicio + j, 2] = " " + dtInicio.AddDays(j).ToShortDateString();
                        ultimaLinhaGerada = linhaInicio + j;
                    }

                    xlWorkSheet.Cells[ultimaLinhaGerada+3, 1] = "Declaro que as informações acima são verídicas. ASSINATURA DO COLABORADOR:";
                    xlWorkSheet.Range[xlWorkSheet.Cells[ultimaLinhaGerada + 3, 1], xlWorkSheet.Cells[ultimaLinhaGerada + 3, 7]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[ultimaLinhaGerada + 3, 1], xlWorkSheet.Cells[ultimaLinhaGerada + 3, 7]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    xlWorkSheet.Cells[ultimaLinhaGerada + 5, 1] = "EU DIRETOR(A) CONFIRMO AS INFORMAÇÕES PRESTADAS ACIMA.";
                    xlWorkSheet.Range[xlWorkSheet.Cells[ultimaLinhaGerada + 5, 1], xlWorkSheet.Cells[ultimaLinhaGerada + 5, 7]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[ultimaLinhaGerada + 5, 1], xlWorkSheet.Cells[ultimaLinhaGerada + 5, 7]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    Excel.Range tRange2 = xlWorkSheet.Range[xlWorkSheet.Cells[linhaInicio, 1], xlWorkSheet.Cells[(linhaInicio + DiasDoMes) - 1, 7]];
                    tRange2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    tRange2.Borders.Weight = Excel.XlBorderWeight.xlThin;

                    //tamanho das colunas
                    xlWorkSheet.Columns[1].ColumnWidth = 4.9;
                    xlWorkSheet.Columns[2].ColumnWidth = 10.2;
                    xlWorkSheet.Columns[3].ColumnWidth = 8.5;
                    xlWorkSheet.Columns[4].ColumnWidth = 8.5;
                    xlWorkSheet.Columns[5].ColumnWidth = 8.5;
                    xlWorkSheet.Columns[6].ColumnWidth = 8.5;
                    xlWorkSheet.Columns[7].ColumnWidth = 32;

                    //pinta a celula
                    //xlWorkSheet.Cells[2, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

                    //Mesclar celulas ok
                    //xlWorkSheet.Range[xlWorkSheet.Cells[1, 2], xlWorkSheet.Cells[1, 3]].Merge();

                    //Seleciona Range para por bordas
                    //Excel.Range tRange = xlWorkSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[2, 4]];
                    //tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    //tRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                    //borda em tudo
                    //Excel.Range tRange = xlWorkSheet.UsedRange;
                    //tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    //tRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                    //o arquivo foi salvo na pasta Meus Documentos.
                    //string caminho = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    string caminho = lblcaminho.Text;
                    string nomeArquivoExcel = dtgResultadoPesquisa[3, i].Value + "-" + dtgResultadoPesquisa[2, i].Value + ".xls";
                    //string nomeArquivoPDF = dtgResultadoPesquisa[3, i].Value + "-" + dtgResultadoPesquisa[2, i].Value + ".pdf";

                    //Salva o arquivo de acordo com a documentação do Excel.
                    xlWorkBook.SaveAs(caminho + @"\" + nomeArquivoExcel, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                    Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                }
            }

            System.Diagnostics.Process.Start("taskkill", "/f /im EXCEL.exe");

            MessageBox.Show("Arquivos Gerados.");
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            GeraDadosExcelDe21a20();
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

            cmbMesCompetencia.SelectedIndex = DateTime.Now.Month;
            txtAnoCompetencia.Text = DateTime.Now.Year.ToString();
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
                    //0 - opcao
                    //1 - cod
                    //2 - colaborador
                    //3 - centrocusto
                    //4 - depto
                    //5 - cpf
                    //5 - funcao
                    Utils.populaDataGridView(ref dtgResultadoPesquisa, Colaboradores.GetColaboradoresPorCentroCusto(cmbCentroCusto.SelectedValue.ToString()));
                    dtgResultadoPesquisa.Columns[0].Width = 25;
                    dtgResultadoPesquisa.Columns[0].HeaderText = "";
                    dtgResultadoPesquisa.Columns[0].ReadOnly = false;
                    dtgResultadoPesquisa.Columns[0].Frozen = true;
                    dtgResultadoPesquisa.Columns[1].Visible = false;                    
                    dtgResultadoPesquisa.Columns[2].Width = 200;
                    dtgResultadoPesquisa.Columns[3].Width = 200;
                    dtgResultadoPesquisa.Columns[4].Width = 200;
                    dtgResultadoPesquisa.Columns[5].Visible = false;
                    dtgResultadoPesquisa.Columns[6].Visible = false;
                   
                    if (dtgResultadoPesquisa.Rows.Count > 0)
                    {
                        if (lblcaminho.Text != "")
                            btnGerar.Enabled = true;
                        lblRegistros.Text = dtgResultadoPesquisa.Rows.Count + "Registros encontrados.";
                        chkMarcaTodos.Enabled = true;
                    }
                    else
                    {
                        btnGerar.Enabled = false;
                        lblRegistros.Text = "0 Registros encontrados.";
                        chkMarcaTodos.Enabled = false;
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
            lblRegistros.Focus();
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
            lblRegistros.Focus();
        }

        private string retornaDiaDaSemana(DateTime dt)
        {
            string retorno = "";
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    retorno = "DOM";
                    break;
                case DayOfWeek.Monday:
                    retorno = "SEG";
                    break;
                case DayOfWeek.Tuesday:
                    retorno = "TER";
                    break;
                case DayOfWeek.Wednesday:
                    retorno = "QUA";
                    break;
                case DayOfWeek.Thursday:
                    retorno = "QUI";
                    break;
                case DayOfWeek.Friday:
                    retorno = "SEX";
                    break;
                case DayOfWeek.Saturday:
                    retorno = "SAB";
                    break;                
            }
            return retorno;
        }

        private void btnCaminho_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                lblcaminho.Text = folderBrowserDialog1.SelectedPath;
                btnGerar.Enabled = true;
            }
        }
    }
}
