using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class CD_Horarios
    {
        cd_Conexion db_conexion = new cd_Conexion();

        public DataTable MtdMostrarHorarios()
        {
            string QryMostrarHorarios = "usp_horarios_mostrar"; 
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarHorarios, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarHorarios = new DataTable();
            adapter.Fill(dtMostrarHorarios);
            db_conexion.MtdCerrarConexion();
            return dtMostrarHorarios;
        }

        public void MtdAgregarHorarios(int CodigoEstacion, TimeSpan HoraSalida, TimeSpan HoraLlegada, DateTime FechaInicio, DateTime FechaFin, string Estado)
        {
            string Usp_Crear = "usp_horarios_crear"; 
            SqlCommand cmd_InsertarHorarios = new SqlCommand(Usp_Crear, db_conexion.MtdAbrirConexion());

            cmd_InsertarHorarios.CommandType = CommandType.StoredProcedure;

            cmd_InsertarHorarios.Parameters.AddWithValue("@CodigoEstacion", CodigoEstacion);
            cmd_InsertarHorarios.Parameters.AddWithValue("@HoraSalida", HoraSalida);
            cmd_InsertarHorarios.Parameters.AddWithValue("@HoraLlegada", HoraLlegada);
            cmd_InsertarHorarios.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            cmd_InsertarHorarios.Parameters.AddWithValue("@FechaFin", FechaFin);
            cmd_InsertarHorarios.Parameters.AddWithValue("@Estado", Estado);

            cmd_InsertarHorarios.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();

        }

        public void MtdActualizarHorarios(int CodigoHorario, int CodigoEstacion, TimeSpan HoraSalida, TimeSpan HoraLlegada, DateTime FechaInicio, DateTime FechaFin, string Estado)

        {
            string usp_actualizar = "usp_horarios_actualizar";  
            SqlCommand cmdUspActualizar = new SqlCommand(usp_actualizar, db_conexion.MtdAbrirConexion());
            cmdUspActualizar.CommandType = CommandType.StoredProcedure;
            cmdUspActualizar.Parameters.AddWithValue("@CodigoHorario", CodigoHorario);
            cmdUspActualizar.Parameters.AddWithValue("@CodigoEstacion", CodigoEstacion);
            cmdUspActualizar.Parameters.AddWithValue("@HoraSalida", HoraSalida);
            cmdUspActualizar.Parameters.AddWithValue("@HoraLlegada", HoraLlegada);
            cmdUspActualizar.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            cmdUspActualizar.Parameters.AddWithValue("@FechaFin", FechaFin);
            cmdUspActualizar.Parameters.AddWithValue("@Estado", Estado);
            cmdUspActualizar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();

        }

        public void MtdEliminarHorarios(int CodigoHorario)
        {
            string usp_eliminar = "usp_horarios_eliminar";  // CAMBIAR USP
            SqlCommand cmdUspEliminar = new SqlCommand(usp_eliminar, db_conexion.MtdAbrirConexion());
            cmdUspEliminar.CommandType = CommandType.StoredProcedure;
            cmdUspEliminar.Parameters.AddWithValue("@CodigoHorario", CodigoHorario);

            cmdUspEliminar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();


        }


        public DataTable MtdBuscarHorarios(string buscarParametro)
        {

            string usp_buscar = "usp_Horarios_buscar";


            SqlCommand cmdBuscarHorarios = new SqlCommand(usp_buscar, db_conexion.MtdAbrirConexion());
            cmdBuscarHorarios.CommandType = CommandType.StoredProcedure;


            cmdBuscarHorarios.Parameters.AddWithValue("@Buscar", buscarParametro);


            SqlDataAdapter adapter = new SqlDataAdapter(cmdBuscarHorarios);
            DataTable dtHorarios = new DataTable();
            adapter.Fill(dtHorarios);


            db_conexion.MtdCerrarConexion();

            return dtHorarios;
        }

        public DataTable ObtenerEstacionesActivas()
        {
            DataTable dt = new DataTable();

            try
            {
                cd_Conexion conexion = new cd_Conexion();

                using (SqlConnection con = conexion.MtdAbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("usp_ListarEstacionesActivas", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    // Agregar columna combinada
                    dt.Columns.Add("Display", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Display"] = row["CodigoEstacion"].ToString() + " - " + row["Nombre"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las estaciones activas: " + ex.Message);
            }

            return dt;
        }

    }

}
