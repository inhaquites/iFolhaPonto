using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFolhaPonto.Models
{
    public class Feriados
    {
        private int _iD;
        private string _descricao;
        private DateTime _data;
        private string _tipo;


        public int ID { get => _iD; set => _iD = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }
        public DateTime Data { get => _data; set => _data = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }


        public static DataTable GetFeriados()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DalHelper.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Feriados";
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
        public static DataTable GetFeriado(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DalHelper.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Feriados Where Id=" + id;
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
        public static void Add(Feriados feriados)
        {
            int result = -1;
            try
            {
                using (var cmd = DalHelper.DbConnection().CreateCommand())
                {                    
                    cmd.CommandText = "INSERT INTO Feriados(Descricao, Data, Tipo ) values (@Descricao, @Data, @Tipo)";
                    cmd.Prepare();                    
                    cmd.Parameters.AddWithValue("@Descricao", feriados.Descricao);
                    cmd.Parameters.AddWithValue("@Data", feriados.Data);
                    cmd.Parameters.AddWithValue("@Tipo", feriados.Tipo);
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Update(Feriados feriados)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DalHelper.DbConnection()))
                {
                    if (feriados.ID != null)
                    {
                        cmd.CommandText = "UPDATE Feriados SET Descricao=@Descricao, Data=@Data, Tipo=@Tipo WHERE Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", feriados.ID);
                        cmd.Parameters.AddWithValue("@Descricao", feriados.Descricao);
                        cmd.Parameters.AddWithValue("@Data", feriados.Data);
                        cmd.Parameters.AddWithValue("@Tipo", feriados.Tipo);
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
                    cmd.CommandText = "DELETE FROM Feriados Where Id=@Id";
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
