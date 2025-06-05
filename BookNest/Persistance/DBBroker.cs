using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Persistance
{
    internal class DBBroker
    {
        private static DBBroker _instancia;
        private static MySqlConnection conexion;
        private static string cadenaConexion;

        // Carga la cadena de conexión desde appsettings.json al cargar la clase
        static DBBroker()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();
            cadenaConexion = config.GetConnectionString("DefaultConnection");
        }

        private DBBroker()
        {
            conexion = new MySqlConnection(cadenaConexion);
        }

        public static DBBroker obtenerAgente()
        {
            if (_instancia == null)
            {
                _instancia = new DBBroker();
            }
            return _instancia;
        }

        public List<object> leer(string sql)
        {
            List<object> resultado = new List<object>();
            List<object> fila;
            int i;
            MySqlDataReader reader;
            MySqlCommand com = new MySqlCommand(sql, conexion);

            conectar();
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                fila = new List<object>();
                for (i = 0; i < reader.FieldCount; i++)
                {
                    fila.Add(reader.GetValue(i).ToString());
                }
                resultado.Add(fila);
            }
            desconectar();
            return resultado;
        }

        public int modificar(string sql)
        {
            MySqlCommand com = new MySqlCommand(sql, conexion);
            int resultado;
            conectar();
            resultado = com.ExecuteNonQuery();
            desconectar();
            return resultado;
        }

        private void conectar()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        private void desconectar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
