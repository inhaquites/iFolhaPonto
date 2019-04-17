using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iFolhaPonto
{
    public class Utils
    {
        public enum tipodedados
        {
            Inteiro,
            Dinheiro,
            Duplo,
            Texto,
            Data,
            VerdadeiroFalso
        }

        public static tipodedados pegaTipoCampo(string datatype)
        {
            switch (datatype)
            {
                case "System.Int32":
                case "System.Int16":
                case "System.Int64":
                case "System.UInt32":
                case "System.UInt16":
                case "System.UInt64":
                    return tipodedados.Inteiro;
                case "System.String":
                case "System.Char":
                case "System.SByte":
                    return tipodedados.Texto;
                case "System.Boolean":
                case "System.Byte":
                    return tipodedados.VerdadeiroFalso;
                case "System.TimeSpan":
                case "System.DateTime":
                    return tipodedados.Data;
                case "System.Decimal":
                    return tipodedados.Dinheiro;
                case "System.Duplo":
                case "System.Single":
                    return tipodedados.Duplo;
                default:
                    return tipodedados.Texto;
            }
        }

        public static void abrirForm(bool formunico, Form formabrir, Form formpai)
        {
            if(formunico)
            {
                foreach(Form formitem in formpai.MdiChildren)
                {
                    if(formitem.Name == formabrir.Name)
                    {
                        formitem.BringToFront();
                        break;
                    }
                }
            }
            formabrir.MdiParent = formpai;
            formabrir.Show();
        }

        public static void populaDataGridView(ref DataGridView dgv, DataTable _dt)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            DataTable dt = _dt;

            #region Gera as Colunas

            dgv.AutoGenerateColumns = false;

            bool geracolunadrop = false;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                geracolunadrop = false;
                if (dt.Columns[i].ColumnName.Length >= 3)
                {
                    if ((dt.Columns[i].ColumnName.Substring(0, 3) == "_ID"))
                        geracolunadrop = true;
                }
                if (geracolunadrop)
                {
                   
                }
                else
                {
                    if ((dt.Columns[i].ColumnName.Substring(0, 1) == "$"))
                    {
                        //CHECK BOX
                        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                        chk.HeaderText = dt.Columns[i].ColumnName.Substring(1);
                        chk.DataPropertyName = dt.Columns[i].ColumnName;
                        chk.ReadOnly = true;
                        chk.TrueValue = "1";
                        chk.FalseValue = "0";
                        chk.ValueType = typeof(String);
                        dgv.Columns.Add(chk);
                    }
                    else
                    {
                        //TEXT BOX
                        DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                        txt.HeaderText = dt.Columns[i].ColumnName;
                        txt.DataPropertyName = dt.Columns[i].ColumnName;

                        tipodedados tipo = pegaTipoCampo(dt.Columns[i].DataType.ToString());
                        switch (tipo)
                        {
                            case tipodedados.Data:
                                txt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                txt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                txt.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                                txt.SortMode = DataGridViewColumnSortMode.NotSortable;
                                break;
                            case tipodedados.Dinheiro:
                            case tipodedados.Duplo:
                                txt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                txt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                txt.DefaultCellStyle.Format = "#.##0,00";
                                txt.SortMode = DataGridViewColumnSortMode.NotSortable;
                                break;
                            case tipodedados.Inteiro:
                                txt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                txt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                txt.DefaultCellStyle.Format = "";
                                txt.SortMode = DataGridViewColumnSortMode.NotSortable;
                                break;
                            default:
                                txt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                txt.DefaultCellStyle.Format = "";
                                break;
                        }
                        txt.ReadOnly = true;
                        dgv.Columns.Add(txt);
                    }
                }
            }
            #endregion

            #region Gera as Linhas

            if (dt.Rows.Count == 0)
                return;
            string[] linha = new string[dt.Columns.Count];
            int ctg = 0;
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                ctg = 0;
                for (int y = 0; y < dt.Columns.Count; y++)
                {
                    linha[ctg] = dt.Rows[x].ItemArray[y].ToString();
                    ctg++;
                }
                dgv.Rows.Add(linha);
            }
            #endregion

            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            //ds = null;
        }
    }
}
