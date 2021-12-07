namespace DAL.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using EasyEncryption;

    //conexion a la base de datos
    public class SqlUtils : BaseDao
    {
        public const string Key = "aZr2URKx";
        public const string Iv = "HNtgQw0w";

        ////private static log4net.ILog log;
        public SqlUtils()
        {
        }
        //string de conexion encriptado tomando del txt la informacion de la BD encriptandola
        public static SqlConnection Connection(string newDatabaseName = null)
        {
            var path = "C:\\diploma-master\\GIT\\OptimusPrime\\UI\\secret.txt";
            var readText = File.ReadAllText(path); //Leo el archivo
            var connString = DES.Decrypt(readText, Key, Iv); //Desencripto

            var conn = new SqlConnection(connString);

            if (!string.IsNullOrEmpty(newDatabaseName))
            {
                var newEncrypted = DES.Encrypt($"Data Source=.\\SQLEXPRESS;Initial Catalog={newDatabaseName};Integrated Security=True", Key, Iv); //Encripto el nuevo string
                File.WriteAllText(path, newEncrypted);//escribo el archivo
                conn = new SqlConnection(DES.Decrypt(newEncrypted, Key, Iv));
            }

            return conn;
        }

        public static List<string> GetTables()
        {
            using (SqlConnection connection = Connection())
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> tableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    tableNames.Add(row[2].ToString());
                }

                return tableNames;
            }
        }

        public int GenerarId(string campoId, string entidad)
        {
            var ultimoId = CatchException(() => Exec<int>($"SELECT {campoId} FROM {entidad}"));

            if (ultimoId.Count > 0)
            {
                return ultimoId.Last() + 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
