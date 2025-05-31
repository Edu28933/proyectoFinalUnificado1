using System;
using CAPADATOS; 
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class cd_06Estaciones
    { 
         

        cd_Conexion cd_Conexion = new cd_Conexion();


 
            // Mostrar estaciones
            public DataTable MtdMostrarEstaciones()
            {
                string QryMostrarEstaciones = "usp_estaciones_mostrar";
                SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarEstaciones, cd_Conexion.MtdAbrirConexion());
                DataTable dtMostrarEstaciones = new DataTable();
                adapter.Fill(dtMostrarEstaciones);
                cd_Conexion.MtdCerrarConexion();
                return dtMostrarEstaciones;
            }

            // Agregar estación
            public void MtdAgregarEstaciones(int CodigoRuta, string Nombre, string Ubicacion, string Secuencia, TimeSpan TiempoEspera, string Estado)
            {
                string Usp_Crear = "usp_estaciones_crear";
                SqlCommand cmd = new SqlCommand(Usp_Crear, cd_Conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CodigoRuta", CodigoRuta);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion);
                cmd.Parameters.AddWithValue("@Secuencia", Secuencia);
                cmd.Parameters.AddWithValue("@TiempoEspera", TiempoEspera);
                cmd.Parameters.AddWithValue("@Estado", Estado);

                cmd.ExecuteNonQuery();
                cd_Conexion.MtdCerrarConexion();
            }

            // Editar estación
            public void MtdActualizarEstaciones(int CodigoEstacion, int CodigoRuta, string Nombre, string Ubicacion, string Secuencia, TimeSpan TiempoEspera, string Estado)
            {
                string Usp_Actualizar = "usp_estaciones_editar";
                SqlCommand cmd = new SqlCommand(Usp_Actualizar, cd_Conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CodigoEstacion", CodigoEstacion);
                cmd.Parameters.AddWithValue("@CodigoRuta", CodigoRuta);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion);
                cmd.Parameters.AddWithValue("@Secuencia", Secuencia);
                cmd.Parameters.AddWithValue("@TiempoEspera", TiempoEspera);
                cmd.Parameters.AddWithValue("@Estado", Estado);

                cmd.ExecuteNonQuery();
                cd_Conexion.MtdCerrarConexion();
            }

            // Eliminar estación (elimina lógica o física según tu SP)
            public void MtdEliminarEstaciones(int CodigoEstacion)
            {
                string usp_eliminar = "usp_estaciones_eliminar";
                SqlCommand cmd = new SqlCommand(usp_eliminar, cd_Conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CodigoEstacion", CodigoEstacion);
                cmd.ExecuteNonQuery();
                cd_Conexion.MtdCerrarConexion();
            }


        public DataTable MtdBuscarEstaciones(string buscarParametro)
        {

            string usp_buscar = "usp_Buscar_Estaciones";


            SqlCommand cmdBuscarEstaciones = new SqlCommand(usp_buscar, cd_Conexion.MtdAbrirConexion());
            cmdBuscarEstaciones.CommandType = CommandType.StoredProcedure;


            cmdBuscarEstaciones.Parameters.AddWithValue("@Buscar", buscarParametro);


            SqlDataAdapter adapter = new SqlDataAdapter(cmdBuscarEstaciones);
            DataTable dtEstaciones = new DataTable();
            adapter.Fill(dtEstaciones);


            cd_Conexion.MtdCerrarConexion();

            return dtEstaciones;
        }

        public DataTable ObtenerEstacionesActivos()
        {
            DataTable dt = new DataTable();

            try
            {
                cd_Conexion conexion = new cd_Conexion();

                using (SqlConnection con = conexion.MtdAbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarRutasActivas", con);
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

