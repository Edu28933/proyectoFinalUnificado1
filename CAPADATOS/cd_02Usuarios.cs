using CAPADATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS
{
    public class cd_02Usuarios
    {

        cd_Conexion cd_Conexion = new cd_Conexion();

        public DataTable MtMostrarUsuarios()
        {
            string QryMostrarUsuarios = "usp_usuarios_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarUsuarios, cd_Conexion.MtdAbrirConexion());
            DataTable dtMostrarUsuarios = new DataTable();
            adapter.Fill(dtMostrarUsuarios);
            cd_Conexion.MtdCerrarConexion();
            return dtMostrarUsuarios;
        }

        public void MtdAgregarUsuario(string Nombre, string Contraseña, string Estado)
        {
            string Usp_crear = "usp_Usuarios_crear";
            SqlCommand cmd_InsertarUsuario = new SqlCommand(Usp_crear, cd_Conexion.MtdAbrirConexion());
            cmd_InsertarUsuario.CommandType = CommandType.StoredProcedure;

            cmd_InsertarUsuario.Parameters.AddWithValue("@Nombre", Nombre);
            cmd_InsertarUsuario.Parameters.AddWithValue("@Contraseña", Contraseña);
            cmd_InsertarUsuario.Parameters.AddWithValue("@Estado", Estado);

            cmd_InsertarUsuario.ExecuteNonQuery();
            cd_Conexion.MtdCerrarConexion();
        }

        public void MtdActualizarUsuario( string Nombre, string Contraseña, string Estado)
        {
            string usp_actualizar = "usp_Usuarios_editar3";
            SqlCommand cmdUspActualizar = new SqlCommand(usp_actualizar, cd_Conexion.MtdAbrirConexion());
            cmdUspActualizar.CommandType = CommandType.StoredProcedure;

            cmdUspActualizar.Parameters.AddWithValue("@Nombre", Nombre);
            cmdUspActualizar.Parameters.AddWithValue("@Contraseña", Contraseña); 
            cmdUspActualizar.Parameters.AddWithValue("@Estado", Estado);

            cmdUspActualizar.ExecuteNonQuery();
            cd_Conexion.MtdCerrarConexion();
        }

        public void MtdEliminarUsuario(int CodigoUsuario)
        {
            string usp_eliminar = "usp_Usuarios_eliminar";
            SqlCommand cmdUsEliminar = new SqlCommand(usp_eliminar, cd_Conexion.MtdAbrirConexion());
            cmdUsEliminar.CommandType = CommandType.StoredProcedure;

            cmdUsEliminar.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            cmdUsEliminar.ExecuteNonQuery();

            cd_Conexion.MtdCerrarConexion();
        }

        public DataTable MtdBuscarUsuario(string buscarParametro)
        {
            
            string usp_buscar = "usp_usuarios_buscar";

            
            SqlCommand cmdBuscarUsuario = new SqlCommand(usp_buscar, cd_Conexion.MtdAbrirConexion());
            cmdBuscarUsuario.CommandType = CommandType.StoredProcedure;

            
            cmdBuscarUsuario.Parameters.AddWithValue("@Buscar", buscarParametro);

            
            SqlDataAdapter adapter = new SqlDataAdapter(cmdBuscarUsuario);
            DataTable dtUsuarios = new DataTable();
            adapter.Fill(dtUsuarios);

            
            cd_Conexion.MtdCerrarConexion();

            return dtUsuarios;
        }


    }

}

    
