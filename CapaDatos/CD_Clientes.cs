using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Clientes
    {
    
        CD_Conexion db_conexion = new CD_Conexion();

        public DataTable MtMostrarClientes()
        {
            string QryMostrarClientes = "usp_clientes_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarClientes,db_conexion.MtdAbrirConexion());
            DataTable dtMostrarClientes = new DataTable();
            adapter.Fill(dtMostrarClientes);
            db_conexion.MtdCerrarConexion();
            return dtMostrarClientes;
        }
        public void MtdAgregarClientes(string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        {
            string QryCrearClientes = "usp_clientes_crear";
            SqlCommand cmd_InsertarClientes = new SqlCommand(QryCrearClientes, db_conexion.MtdAbrirConexion());
            cmd_InsertarClientes.CommandType = CommandType.StoredProcedure;
            cmd_InsertarClientes.Parameters.AddWithValue("@Nombre",Nombre);
            cmd_InsertarClientes.Parameters.AddWithValue("@Direccion",Direccion);
            cmd_InsertarClientes.Parameters.AddWithValue("@Departamento",Departamento);
            cmd_InsertarClientes.Parameters.AddWithValue("@Pais",Pais);
            cmd_InsertarClientes.Parameters.AddWithValue("@Categoria",Categoria);
            cmd_InsertarClientes.Parameters.AddWithValue("@Estado",Estado);
            cmd_InsertarClientes.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();
        }


    }
}
