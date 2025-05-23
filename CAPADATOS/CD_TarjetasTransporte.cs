using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class CD_TarjetasTransporte
    {

        cd_Conexion db_conexion = new cd_Conexion();

        public DataTable MtdMostrarTarjetasTransporte()
        {
            string QryMostrarTarjetasTransporte = "usp_tarjetastransporte_mostrar"; // CAMBIAR USP
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarTarjetasTransporte, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarTarjetasTransporte = new DataTable();
            adapter.Fill(dtMostrarTarjetasTransporte);
            db_conexion.MtdCerrarConexion();
            return dtMostrarTarjetasTransporte;
        }

        public void MtdAgregarTarjetasTransporte(int CodigoPasajero, DateTime FechaEmision, decimal Saldo, string Moneda, string TipoTarjeta, string Estado)
        {
            string Usp_Crear = "usp_tarjetastransporte_crear"; // CAMBIAR USP
            SqlCommand cmd_InsertarTarjetasTransporte = new SqlCommand(Usp_Crear, db_conexion.MtdAbrirConexion());

            cmd_InsertarTarjetasTransporte.CommandType = CommandType.StoredProcedure;

            cmd_InsertarTarjetasTransporte.Parameters.AddWithValue("@CodigoPasajero", CodigoPasajero);
            cmd_InsertarTarjetasTransporte.Parameters.AddWithValue("@FechaEmision", FechaEmision);
            cmd_InsertarTarjetasTransporte.Parameters.AddWithValue("@Saldo", Saldo);
            cmd_InsertarTarjetasTransporte.Parameters.AddWithValue("@Moneda", Moneda);
            cmd_InsertarTarjetasTransporte.Parameters.AddWithValue("@TipoTarjeta", TipoTarjeta);
            cmd_InsertarTarjetasTransporte.Parameters.AddWithValue("@Estado", Estado);

            cmd_InsertarTarjetasTransporte.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();

        }

        public void MtdActualizarTarjetasTransporte(int CodigoTarjeta, int CodigoPasajero, DateTime FechaEmision, decimal Saldo, string Moneda, string TipoTarjeta, string Estado)

        {
            string usp_actualizar = "usp_tarjetastransporte_actualizar";  //CAMBIAR USP
            SqlCommand cmdUspActualizar = new SqlCommand(usp_actualizar, db_conexion.MtdAbrirConexion());
            cmdUspActualizar.CommandType = CommandType.StoredProcedure;
            cmdUspActualizar.Parameters.AddWithValue("@CodigoTarjeta", CodigoTarjeta);
            cmdUspActualizar.Parameters.AddWithValue("@CodigoPasajero", CodigoPasajero);
            cmdUspActualizar.Parameters.AddWithValue("@FechaEmision", FechaEmision);
            cmdUspActualizar.Parameters.AddWithValue("@Saldo", Saldo);
            cmdUspActualizar.Parameters.AddWithValue("@Moneda", Moneda);
            cmdUspActualizar.Parameters.AddWithValue("@TipoTarjeta", TipoTarjeta);
            cmdUspActualizar.Parameters.AddWithValue("@Estado", Estado);
            cmdUspActualizar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();

        }

        public void MtdEliminarTarjetasTransporte(int CodigoTarjeta)
        {
            string usp_eliminar = "usp_tarjetastransporte_eliminar";  // CAMBIAR USP
            SqlCommand cmdUspEliminar = new SqlCommand(usp_eliminar, db_conexion.MtdAbrirConexion());
            cmdUspEliminar.CommandType = CommandType.StoredProcedure;
            cmdUspEliminar.Parameters.AddWithValue("@CodigoTarjeta", CodigoTarjeta);

            cmdUspEliminar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();


        }

    }
}
