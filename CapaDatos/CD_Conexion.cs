using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class CD_Conexion
    {

        private SqlConnection db_conexion = new SqlConnection("Server=TONY;Database=DB_Banco;Trusted_Connection=True;");

        public SqlConnection MtdAbrirConexion()
        {
            try
            {
                if (db_conexion.State == ConnectionState.Closed)
                    db_conexion.Open();
            }
            catch (SqlException ex)
            {
                // Manejo de la excepción, en caso de error en la conexión
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
            }
            return db_conexion;
        }

        public SqlConnection MtdCerrarConexion()
        {
            try
            {
                if (db_conexion.State == ConnectionState.Open)
                    db_conexion.Close();
            }
            catch (SqlException ex)
            {
                // Manejo de la excepción, en caso de error al cerrar la conexión
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
            return db_conexion;
        }
    }
}
