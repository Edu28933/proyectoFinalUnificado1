using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class CD_Pasajeros
    {

        cd_Conexion db_conexion = new cd_Conexion();

        public DataTable MtdMostrarPasajeros()
        {
            string QryMostrarPasajeros = "usp_pasajeros_mostrar"; 
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarPasajeros, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarPasajeros = new DataTable();
            adapter.Fill(dtMostrarPasajeros);
            db_conexion.MtdCerrarConexion();
            return dtMostrarPasajeros;
        }

        public void MtdAgregarPasajeros(string Nombre, int Dpi, int Nit, DateTime FechaAlta, int Telefono, string Estado)
        {
            string Usp_Crear = "usp_pasajeros_crear"; // CAMBIAR USP
            SqlCommand cmd_InsertarPasajeros = new SqlCommand(Usp_Crear, db_conexion.MtdAbrirConexion());

            cmd_InsertarPasajeros.CommandType = CommandType.StoredProcedure;

            cmd_InsertarPasajeros.Parameters.AddWithValue("@Nombre", Nombre);
            cmd_InsertarPasajeros.Parameters.AddWithValue("@Dpi", Dpi);
            cmd_InsertarPasajeros.Parameters.AddWithValue("@Nit", Nit);
            cmd_InsertarPasajeros.Parameters.AddWithValue("@FechaAlta", FechaAlta);
            cmd_InsertarPasajeros.Parameters.AddWithValue("@Telefono", Telefono);
            cmd_InsertarPasajeros.Parameters.AddWithValue("@Estado", Estado);

            cmd_InsertarPasajeros.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();

        }

        public void MtdActualizarPasajeros(int CodigoPasajero, string Nombre, int Dpi, int Nit, DateTime FechaAlta, int Telefono, string Estado)

        {
            string usp_actualizar = "usp_pasajeros_actualizar";  //CAMBIAR USP
            SqlCommand cmdUspActualizar = new SqlCommand(usp_actualizar, db_conexion.MtdAbrirConexion());
            cmdUspActualizar.CommandType = CommandType.StoredProcedure;
            cmdUspActualizar.Parameters.AddWithValue("@CodigoPasajero", CodigoPasajero);
            cmdUspActualizar.Parameters.AddWithValue("@Nombre", Nombre);
            cmdUspActualizar.Parameters.AddWithValue("@Dpi", Dpi);
            cmdUspActualizar.Parameters.AddWithValue("@Nit", Nit);
            cmdUspActualizar.Parameters.AddWithValue("@FechaAlta", FechaAlta);
            cmdUspActualizar.Parameters.AddWithValue("@Telefono", Telefono);
            cmdUspActualizar.Parameters.AddWithValue("@Estado", Estado);
            cmdUspActualizar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();

        }

        public void MtdEliminarPasajeros(int CodigoPasajero)
        {
            string usp_eliminar = "usp_pasajeros_eliminar";  // CAMBIAR USP
            SqlCommand cmdUspEliminar = new SqlCommand(usp_eliminar, db_conexion.MtdAbrirConexion());
            cmdUspEliminar.CommandType = CommandType.StoredProcedure;
            cmdUspEliminar.Parameters.AddWithValue("@CodigoPasajero", CodigoPasajero);

            cmdUspEliminar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();


        }

        public DataTable MtdBuscarPasajeros(string buscarParametro)
        {

            string usp_pasajeros = "usp_Pasajeros_buscar";


            SqlCommand cmdBuscarPasajeros = new SqlCommand(usp_pasajeros, db_conexion.MtdAbrirConexion());
            cmdBuscarPasajeros.CommandType = CommandType.StoredProcedure;


            cmdBuscarPasajeros.Parameters.AddWithValue("@Buscar", buscarParametro);


            SqlDataAdapter adapter = new SqlDataAdapter(cmdBuscarPasajeros);
            DataTable dtPasajeros = new DataTable();
            adapter.Fill(dtPasajeros);


            db_conexion.MtdCerrarConexion();

            return dtPasajeros;
        }



    }
}
