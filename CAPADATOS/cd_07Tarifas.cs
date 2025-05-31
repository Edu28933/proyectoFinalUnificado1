using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class cd_07Tarifas
    {
        cd_Conexion cd_Conexion = new cd_Conexion();

        // Mostrar todas las tarifas hola
        public DataTable MtdMostrarTarifas()
        {
            string consulta = "usp_tarifas_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, cd_Conexion.MtdAbrirConexion());
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            cd_Conexion.MtdCerrarConexion();
            return tabla;
        }

        // Agregar nueva tarifa
        public void MtdAgregarTarifa(int codigoRuta, decimal monto, string moneda, DateTime fechaVigencia, DateTime fechaVencimiento, string estado)
        {
            string procedimiento = "usp_tarifas_crear";
            SqlCommand cmd = new SqlCommand(procedimiento, cd_Conexion.MtdAbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodigoRuta", codigoRuta);
            cmd.Parameters.AddWithValue("@Monto", monto);
            cmd.Parameters.AddWithValue("@Moneda", moneda);
            cmd.Parameters.AddWithValue("@FechaVigencia", fechaVigencia);
            cmd.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);
            cmd.Parameters.AddWithValue("@Estado", estado);

            cmd.ExecuteNonQuery();
            cd_Conexion.MtdCerrarConexion();
        }

        // Actualizar tarifa
        public void MtdActualizarTarifa(int codigoTarifa, int codigoRuta, decimal monto, string moneda, DateTime fechaVigencia, DateTime fechaVencimiento, string estado)
        {
            string procedimiento = "usp_tarifas_editar";
            SqlCommand cmd = new SqlCommand(procedimiento, cd_Conexion.MtdAbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodigoTarifa", codigoTarifa);
            cmd.Parameters.AddWithValue("@CodigoRuta", codigoRuta);
            cmd.Parameters.AddWithValue("@Monto", monto);
            cmd.Parameters.AddWithValue("@Moneda", moneda);
            cmd.Parameters.AddWithValue("@FechaVigencia", fechaVigencia);
            cmd.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);
            cmd.Parameters.AddWithValue("@Estado", estado);

            cmd.ExecuteNonQuery();
            cd_Conexion.MtdCerrarConexion();
        }

        // Eliminar tarifa (puede ser lógica o física según SP)
        public void MtdEliminarTarifa(int codigoTarifa)
        {
            string procedimiento = "usp_tarifas_eliminar";
            using (SqlCommand cmd = new SqlCommand(procedimiento, cd_Conexion.MtdAbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoTarifa", codigoTarifa);
                cmd.ExecuteNonQuery();
                cd_Conexion.MtdCerrarConexion();
            }
        }


        // Buscar tarifas por ruta o estado (ejemplo)
        public DataTable MtdBuscarTarifas(string buscarParametro)
        {

            string usp_buscar = "usp_Buscar_Tarifas";


            SqlCommand cmdBuscarTarifas = new SqlCommand(usp_buscar, cd_Conexion.MtdAbrirConexion());
            cmdBuscarTarifas.CommandType = CommandType.StoredProcedure;


            cmdBuscarTarifas.Parameters.AddWithValue("@Buscar", buscarParametro);


            SqlDataAdapter adapter = new SqlDataAdapter(cmdBuscarTarifas);
            DataTable dtTarifas = new DataTable();
            adapter.Fill(dtTarifas);


            cd_Conexion.MtdCerrarConexion();

            return dtTarifas;
        }

        public DataTable ObtenerTarifasActivas()
        {
            DataTable dt = new DataTable();

            try
            {
                cd_Conexion conexion = new cd_Conexion();

                using (SqlConnection con = conexion.MtdAbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarRutasActivas2", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    // Agregar columna combinada
                    dt.Columns.Add("Display", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Display"] = row["CodigoRuta"].ToString() + " - " + row["Nombre"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las rutas activas: " + ex.Message);
            }

            return dt;
        }

    }
}
