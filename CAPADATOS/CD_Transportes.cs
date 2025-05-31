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

        public void MtdAgregarTransportes(int CodigoEmpleado, string Placa, string Marca, string Modelo, int Año, decimal Capacidad, string TipoTransporte, string Estado)
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

        public void MtdActualizarTransportes(int CodigoTransporte, int CodigoEmpleado, string Placa, string Marca, string Modelo, int Año, decimal Capacidad, string TipoTransporte, string Estado)

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


        public DataTable MtdBuscarTransportes(string buscarParametro)
        {

            string usp_buscar = "usp_Transportes_buscar";


            SqlCommand cmdBuscarTransportes = new SqlCommand(usp_buscar, db_conexion.MtdAbrirConexion());
            cmdBuscarTransportes.CommandType = CommandType.StoredProcedure;


            cmdBuscarTransportes.Parameters.AddWithValue("@Buscar", buscarParametro);


            SqlDataAdapter adapter = new SqlDataAdapter(cmdBuscarTransportes);
            DataTable dtTransportes = new DataTable();
            adapter.Fill(dtTransportes);


            db_conexion.MtdCerrarConexion();

            return dtTransportes;
        }

        public DataTable ObtenerEmpleadosActivos()
        {
            DataTable dt = new DataTable();

            try
            {
                cd_Conexion conexion = new cd_Conexion();

                using (SqlConnection con = conexion.MtdAbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("usp_ListarEmpleadosActivos", con);
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
                throw new Exception("Error al obtener los empleados activos: " + ex.Message);
            }

            return dt;
        }

    }
}
