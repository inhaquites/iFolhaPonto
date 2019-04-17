using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFolhaPonto.Models
{
    public class Colaboradores
    {
        private int _iD;
        private string _cod;
        private string _colaborador;
        private string _centrocusto;
        private string _depto;
        private string _cPF;

        public int ID { get => _iD; set => _iD = value; }
        public string Cod { get => _cod; set => _cod = value; }
        public string Colaborador { get => _colaborador; set => _colaborador = value; }
        public string CentroCusto { get => _centrocusto; set => _centrocusto = value; }
        public string Depto { get => _depto; set => _depto = value; }
        public string CPF { get => _cPF; set => _cPF = value; }

        public static DataTable GetColaboradores()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DalHelper.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Colaboradores";
                    da = new SQLiteDataAdapter(cmd.CommandText, DalHelper.DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetColaboradoresPorCentroCusto(string pCentroCusto)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DalHelper.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT 0 AS [$OPCAO], COLABORADOR, CENTROCUSTO, DEPTO FROM Colaboradores where centrocusto ='" + pCentroCusto + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DalHelper.DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetColaborador(int pID)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DalHelper.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Colaboradores Where Id=" + pID;
                    da = new SQLiteDataAdapter(cmd.CommandText, DalHelper.DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetColaboradorPorCPF(string pCPF)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DalHelper.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Colaboradores Where CPF='" + pCPF + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DalHelper.DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCentroCustos()
        {          SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DalHelper.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT DISTINCT CENTROCUSTO FROM Colaboradores";
                    da = new SQLiteDataAdapter(cmd.CommandText, DalHelper.DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Add(Colaboradores colaboradores)
        {
            int result = -1;
            try
            {
                using (var cmd = DalHelper.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Colaboradores(Cod, Colaborador, CentroCusto, Depto, CPF ) values (@Cod, @Colaborador, @CentroCusto, @Depto, @CPF)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Cod", colaboradores.Cod);
                    cmd.Parameters.AddWithValue("@Colaborador", colaboradores.Colaborador);
                    cmd.Parameters.AddWithValue("@CentroCusto", colaboradores.CentroCusto);
                    cmd.Parameters.AddWithValue("@Depto", colaboradores.Depto);
                    cmd.Parameters.AddWithValue("@CPF", colaboradores.CPF);
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(Colaboradores colaboradores)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DalHelper.DbConnection()))
                {
                    if (colaboradores.ID != null)
                    {
                        cmd.CommandText = "UPDATE Colaboradores SET Cod=@Cod, Colaborador=@Colaborador, CentroCusto=@CentroCusto, , Depto=@Depto, CPF=@CPF  WHERE Id=@Id";
                        //cmd.Parameters.AddWithValue("@Id", feriados.ID);
                        cmd.Parameters.AddWithValue("@Cod", colaboradores.Cod);
                        cmd.Parameters.AddWithValue("@Colaborador", colaboradores.Colaborador);
                        cmd.Parameters.AddWithValue("@CentroCusto", colaboradores.CentroCusto);
                        cmd.Parameters.AddWithValue("@Depto", colaboradores.Depto);
                        cmd.Parameters.AddWithValue("@CPF", colaboradores.CPF);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(int Id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DalHelper.DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Colaboradores Where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
