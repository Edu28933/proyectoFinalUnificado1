using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class cd_09Mantenimientos
    {
        cd_Conexion conexion = new cd_Conexion();

        // Mostrar mantenimientos
        public DataTable MtdMostrarMantenimientos()
        {
            string consulta = "usp_mantenimiento_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion.MtdAbrirConexion());
            DataTable tabla = new DataTable();
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(tabla);
            conexion.MtdCerrarConexion();
            return tabla;
        }



  

        // Agregar mantenimiento
        public void MtdAgregarMantenimiento(int codigoTransporte, DateTime fechaIngreso, DateTime fechaSalida, decimal costo, string moneda, string estado, string tipoServicio)
        {
            SqlCommand cmd = new SqlCommand("usp_mantenimiento_crear", conexion.MtdAbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodigoTransporte", codigoTransporte);
            cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
            cmd.Parameters.AddWithValue("@FechaSalida", (object)fechaSalida ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Costo", costo);
            cmd.Parameters.AddWithValue("@Moneda", moneda);
            cmd.Parameters.AddWithValue("@Estado", estado);
            cmd.Parameters.AddWithValue("@TipoServicio", tipoServicio);
       

            cmd.ExecuteNonQuery();
            conexion.MtdCerrarConexion();
        }

        // Editar mantenimiento
        public void MtdEditarMantenimiento(int codigoMantenimiento, int codigoTransporte, DateTime fechaIngreso, DateTime fechaSalida, decimal costo, string moneda, string estado, string tipoServicio)
        {
            SqlCommand cmd = new SqlCommand("usp_mantenimiento_editar", conexion.MtdAbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodigoMantenimiento", codigoMantenimiento);
            cmd.Parameters.AddWithValue("@CodigoTransporte", codigoTransporte);
            cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
            cmd.Parameters.AddWithValue("@FechaSalida", (object)fechaSalida ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Costo", costo);
            cmd.Parameters.AddWithValue("@Moneda", moneda);
            cmd.Parameters.AddWithValue("@Estado", estado);
            cmd.Parameters.AddWithValue("@TipoServicio", tipoServicio);
       

            cmd.ExecuteNonQuery();
            conexion.MtdCerrarConexion();
        }

        // Eliminar mantenimiento (lógico o físico según tu diseño)
        public void MtdEliminarMantenimiento(int codigoMantenimiento)
        {
            SqlCommand cmd = new SqlCommand("usp_mantenimiento_eliminar", conexion.MtdAbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoMantenimiento", codigoMantenimiento);
            cmd.ExecuteNonQuery();
            conexion.MtdCerrarConexion();
        }

        // Buscar mantenimientos
        public DataTable MtdBuscarMantenimientos(string buscarParametro)
        {
            SqlCommand cmd = new SqlCommand("usp_mantenimientos_buscar", conexion.MtdAbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Buscar", buscarParametro);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            conexion.MtdCerrarConexion();
            return dt;
        }



        public DataTable ObtenerTransportes()
        {
            DataTable dt = new DataTable();

            try
            {
                cd_Conexion conexion = new cd_Conexion();

                using (SqlConnection con = conexion.MtdAbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("usp_ListarTransportesActivos2", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    // Agregar columna combinada
                    dt.Columns.Add("Display", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Display"] = row["CodigoTransporte"].ToString() + " - " + row["Placa"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los Transportes activos: " + ex.Message);
            }

            return dt;
        }

    }
}
