using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class CD_Transportes
    {

        cd_Conexion db_conexion = new cd_Conexion();

        public DataTable MtdMostrarTransportes()
        {
            string QryMostrarTransportes = "usp_transportes_mostrar"; // CAMBIAR USP
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarTransportes, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarTransportes = new DataTable();
            adapter.Fill(dtMostrarTransportes);
            db_conexion.MtdCerrarConexion();
            return dtMostrarTransportes;
        }

        public void MtdAgregarTransportes(int CodigoEmpleado, string Placa, string Marca, string Modelo, DateTime Año, decimal Capacidad, string TipoTransporte, string Estado)
        {
            string Usp_Crear = "usp_transportes_crear"; // CAMBIAR USP
            SqlCommand cmd_InsertarTransportes = new SqlCommand(Usp_Crear, db_conexion.MtdAbrirConexion());

            cmd_InsertarTransportes.CommandType = CommandType.StoredProcedure;

            cmd_InsertarTransportes.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            cmd_InsertarTransportes.Parameters.AddWithValue("@Placa", Placa);
            cmd_InsertarTransportes.Parameters.AddWithValue("@Marca", Marca);
            cmd_InsertarTransportes.Parameters.AddWithValue("@Modelo", Modelo);
            cmd_InsertarTransportes.Parameters.AddWithValue("@Año", Año);
            cmd_InsertarTransportes.Parameters.AddWithValue("@Capacidad", Capacidad);
            cmd_InsertarTransportes.Parameters.AddWithValue("@TipoTransporte", TipoTransporte);
            cmd_InsertarTransportes.Parameters.AddWithValue("@Estado", Estado);

            cmd_InsertarTransportes.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();

        }

        public void MtdActualizarTransportes(int CodigoTransporte, int CodigoEmpleado, string Placa, string Marca, string Modelo, DateTime Año, decimal Capacidad, string TipoTransporte, string Estado)

        {
            string usp_actualizar = "usp_transportes_actualizar";  //CAMBIAR USP
            SqlCommand cmdUspActualizar = new SqlCommand(usp_actualizar, db_conexion.MtdAbrirConexion());
            cmdUspActualizar.CommandType = CommandType.StoredProcedure;
            cmdUspActualizar.Parameters.AddWithValue("@CodigoTransporte", CodigoTransporte);
            cmdUspActualizar.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            cmdUspActualizar.Parameters.AddWithValue("@Placa", Placa);
            cmdUspActualizar.Parameters.AddWithValue("@Marca", Marca);
            cmdUspActualizar.Parameters.AddWithValue("@Modelo", Modelo);
            cmdUspActualizar.Parameters.AddWithValue("@Año", Año);
            cmdUspActualizar.Parameters.AddWithValue("@Capacidad", Capacidad);
            cmdUspActualizar.Parameters.AddWithValue("@TipoTransporte", TipoTransporte);
            cmdUspActualizar.Parameters.AddWithValue("@Estado", Estado);
            cmdUspActualizar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();

        }

        public void MtdEliminarTransportes(int CodigoTransporte)
        {
            string usp_eliminar = "usp_transportes_eliminar";  // CAMBIAR USP
            SqlCommand cmdUspEliminar = new SqlCommand(usp_eliminar, db_conexion.MtdAbrirConexion());
            cmdUspEliminar.CommandType = CommandType.StoredProcedure;
            cmdUspEliminar.Parameters.AddWithValue("@CodigoTransporte", CodigoTransporte);

            cmdUspEliminar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();


        }
    }
}
