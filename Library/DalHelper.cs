using iFolhaPonto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iFolhaPonto
{
    public class DalHelper
    {
        public static SQLiteConnection sqliteConnection;

        public DalHelper()
        { }

        public static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=c:\\iFolhaPonto\\iFolhaPonto.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static void CriarBancoSQLite()
        {
            try
            {
                //nome do diretorio onde sera criado o arquivo
                string folder = @"c:\iFolhaPonto";
                //arquivo banco de dados
                string banco = @"c:\iFolhaPonto\iFolhaPonto.sqlite";

                if (!Directory.Exists(folder))
                {
                    //se nao existe cria a pasta
                    Directory.CreateDirectory(folder);
                }

                if (!File.Exists(banco))
                {
                    SQLiteConnection.CreateFile(@"c:\iFolhaPonto\iFolhaPonto.sqlite");
                }

                
            }
            catch
            {
                throw;
            }
        }
        public static void CriarTabelasSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS [Feriados] ([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                        "[Descricao] Varchar(50) NOT NULL," +
                        "[Data] Date NOT NULL," +
                        "[Tipo] Varchar(1) NOT NULL)";
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS [Colaboradores] ([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                        "[Cod] Varchar(10) NOT NULL," +
                        "[Colaborador] Varchar(100) NOT NULL," +
                        "[Depto] Varchar(100) NOT NULL," +
                        "[Funcao] Varchar(100) NOT NULL," +
                        "[CentroCusto] Varchar(120) NOT NULL," +                        
                        "[CPF] Varchar(11) NOT NULL)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static DataTable GetFeriados()
        //{
        //    SQLiteDataAdapter da = null;
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (var cmd = DbConnection().CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT * FROM Feriados";
        //            da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
        //            da.Fill(dt);
        //            return dt;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static DataTable GetFeriado(int id)
        //{
        //    SQLiteDataAdapter da = null;
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (var cmd = DbConnection().CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT * FROM Feriados Where Id=" + id;
        //            da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
        //            da.Fill(dt);
        //            return dt;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static void Add(Feriados feriados)
        //{
        //    int result = -1;
        //    try
        //    {
        //        using (var cmd = DbConnection().CreateCommand())
        //        {
        //            //cmd.CommandText = "INSERT INTO Feriados(ID, Descricao, Data, Tipo ) values (@Id, @Descricao, @Data, @Tipo)";
        //            cmd.CommandText = "INSERT INTO Feriados(Descricao, Data, Tipo ) values (@Descricao, @Data, @Tipo)";
        //            cmd.Prepare();
        //            //cmd.Parameters.AddWithValue("@Id", feriados.ID);
        //            cmd.Parameters.AddWithValue("@Descricao", feriados.Descricao);
        //            cmd.Parameters.AddWithValue("@Data", feriados.Data);
        //            cmd.Parameters.AddWithValue("@Tipo", feriados.Tipo);
        //            result = cmd.ExecuteNonQuery();                    
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static void Update(Feriados feriados)
        //{
        //    try
        //    {
        //        using (var cmd = new SQLiteCommand(DbConnection()))
        //        {
        //            if (feriados.ID != null)
        //            {
        //                cmd.CommandText = "UPDATE Feriados SET Descricao=@Descricao, Data=@Data, Tipo=@Tipo WHERE Id=@Id";
        //                cmd.Parameters.AddWithValue("@Id", feriados.ID);
        //                cmd.Parameters.AddWithValue("@Descricao", feriados.Descricao);
        //                cmd.Parameters.AddWithValue("@Data", feriados.Data);
        //                cmd.Parameters.AddWithValue("@Tipo", feriados.Tipo);
        //                cmd.ExecuteNonQuery();
        //            }
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static void Delete(int Id)
        //{
        //    try
        //    {
        //        using (var cmd = new SQLiteCommand(DbConnection()))
        //        {
        //            cmd.CommandText = "DELETE FROM Feriados Where Id=@Id";
        //            cmd.Parameters.AddWithValue("@Id", Id);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
