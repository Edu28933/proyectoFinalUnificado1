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


        public DataTable MtdBuscarTarjetastransporte(string buscarParametro)
        {

            string usp_buscar = "usp_Tarjetastransporte_buscar";


            SqlCommand cmdBuscarTarjetastransporte = new SqlCommand(usp_buscar, db_conexion.MtdAbrirConexion());
            cmdBuscarTarjetastransporte.CommandType = CommandType.StoredProcedure;


            cmdBuscarTarjetastransporte.Parameters.AddWithValue("@Buscar", buscarParametro);


            SqlDataAdapter adapter = new SqlDataAdapter(cmdBuscarTarjetastransporte);
            DataTable dtTarjetastransporte = new DataTable();
            adapter.Fill(dtTarjetastransporte);


            db_conexion.MtdCerrarConexion();

            return dtTarjetastransporte;
        }

        public DataTable ObtenerPasajerosActivos()
        {
            DataTable dt = new DataTable();

            try
            {
                cd_Conexion conexion = new cd_Conexion();

                using (SqlConnection con = conexion.MtdAbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("usp_ListarPasajerosActivos", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    // Agregar columna combinada
                    dt.Columns.Add("Display", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Display"] = row["CodigoPasajero"].ToString() + " - " + row["Nombre"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los pasajeros activos: " + ex.Message);
            }

            return dt;
        }
    }
}
