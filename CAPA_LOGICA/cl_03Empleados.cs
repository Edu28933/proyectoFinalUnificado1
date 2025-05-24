using System;
using System.Data;
using System.Data.SqlClient;
using CAPADATOS;

namespace CAPA_LOGICA
{
    public class cl_03Empleados
    {
        private cd_Conexion conexion = new cd_Conexion();

        public DataTable ObtenerUsuariosActivos()
        {
            DataTable dt = new DataTable();

            try
            {
                cd_Conexion conexion = new cd_Conexion();

                using (SqlConnection con = conexion.MtdAbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarUsuariosActivos", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    // Agregar columna combinada: "1 - Usuario1"
                    dt.Columns.Add("Display", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Display"] = row["CodigoUsuario"].ToString() + " - " + row["Nombre"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios activos: " + ex.Message);
            }

            return dt;
        }

    }
}
