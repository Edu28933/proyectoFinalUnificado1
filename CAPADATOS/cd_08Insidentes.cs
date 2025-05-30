using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class cd_08Insidentes
    {

        cd_Conexion conexion = new cd_Conexion();

        public DataTable MtdMostrarIncidentes()
        {
            string consulta = "usp_incidentes_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion.MtdAbrirConexion());
            DataTable tabla = new DataTable();
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(tabla);
            conexion.MtdCerrarConexion();
            return tabla;
        }

        public void MtdAgregarIncidente(int codigoTransporte, int codigoEmpleado, string descripcion, DateTime fecha, TimeSpan hora, string estado)
        {
            SqlCommand cmd = new SqlCommand("usp_incidentes_crear", conexion.MtdAbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodigoTransporte", codigoTransporte);
            cmd.Parameters.AddWithValue("@CodigoEmpleado", codigoEmpleado);
            cmd.Parameters.AddWithValue("@Descripcion", descripcion);
            cmd.Parameters.AddWithValue("@Fecha", fecha.Date);
            cmd.Parameters.AddWithValue("@Hora", hora);
            cmd.Parameters.AddWithValue("@Estado", estado);

            cmd.ExecuteNonQuery();
            conexion.MtdCerrarConexion();
        }

        public void MtdEditarIncidente(int codigoIncidente, int codigoTransporte, int codigoEmpleado, string descripcion, DateTime fecha, TimeSpan hora, string estado)
        {
            SqlCommand cmd = new SqlCommand("usp_incidentes_editar", conexion.MtdAbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodigoIncidente", codigoIncidente);
            cmd.Parameters.AddWithValue("@CodigoTransporte", codigoTransporte);
            cmd.Parameters.AddWithValue("@CodigoEmpleado", codigoEmpleado);
            cmd.Parameters.AddWithValue("@Descripcion", descripcion);
            cmd.Parameters.AddWithValue("@Fecha", fecha.Date);
            cmd.Parameters.AddWithValue("@Hora", hora);
            cmd.Parameters.AddWithValue("@Estado", estado);

            cmd.ExecuteNonQuery();
            conexion.MtdCerrarConexion();
        }

        public void MtdEliminarIncidente(int codigoIncidente)
        {
            SqlCommand cmd = new SqlCommand("usp_incidentes_eliminar", conexion.MtdAbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoIncidente", codigoIncidente);
            cmd.ExecuteNonQuery();
            conexion.MtdCerrarConexion();
        }



        public DataTable MtdBuscarIncidentes(string buscarParametro)
        {
            SqlCommand cmd = new SqlCommand("usp_Incidentes_Buscar", conexion.MtdAbrirConexion());
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
                    SqlCommand cmd = new SqlCommand("sp_ListarTransportesActivos", con);
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

        public DataTable ObtenerEmpleados()
        {
            DataTable dt = new DataTable();

            try
            {
                cd_Conexion conexion = new cd_Conexion();

                using (SqlConnection con = conexion.MtdAbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarEmpleadosActivos", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    // Agregar columna combinada
                    dt.Columns.Add("Display", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Display"] = row["CodigoEmpleado"].ToString() + " - " + row["Nombre"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los Empleados: " + ex.Message);
            }

            return dt;
        }
    }
}


