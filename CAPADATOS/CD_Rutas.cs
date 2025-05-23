using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class CD_Rutas
    {
        cd_Conexion db_conexion = new cd_Conexion();

        public DataTable MtdMostrarRutas()
        {
            string QryMostrarRutas = "usp_rutas_mostrar"; // CAMBIAR USP
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarRutas, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarRutas = new DataTable();
            adapter.Fill(dtMostrarRutas);
            db_conexion.MtdCerrarConexion();
            return dtMostrarRutas;
        }

        public void MtdAgregarRutas(int CodigoUsuario, string Nombre, string Origen, string Destino, string Distancia, string TipoRuta, string Estado)
        {
            string Usp_Crear = "usp_rutas_crear"; // CAMBIAR USP
            SqlCommand cmd_InsertarRutas = new SqlCommand(Usp_Crear, db_conexion.MtdAbrirConexion());

            cmd_InsertarRutas.CommandType = CommandType.StoredProcedure;

                cmd_InsertarRutas.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
                cmd_InsertarRutas.Parameters.AddWithValue("@Nombre", Nombre);
                cmd_InsertarRutas.Parameters.AddWithValue("@Origen", Origen);
                cmd_InsertarRutas.Parameters.AddWithValue("@Destino", Destino);
                cmd_InsertarRutas.Parameters.AddWithValue("@Distancia", Distancia);
                cmd_InsertarRutas.Parameters.AddWithValue("@TipoRuta", TipoRuta);
                cmd_InsertarRutas.Parameters.AddWithValue("@Estado", Estado);

                cmd_InsertarRutas.ExecuteNonQuery();
           
            db_conexion.MtdCerrarConexion();

        }

        public void MtdActualizarRutas(int CodigoRuta, int CodigoUsuario, string Nombre, string Origen, string Destino, string Distancia, string TipoRuta, string Estado)

        {
            string usp_actualizar = "usp_rutas_actualizar";  //CAMBIAR USP
             SqlCommand cmdUspActualizar = new SqlCommand(usp_actualizar, db_conexion.MtdAbrirConexion());
             cmdUspActualizar.CommandType = CommandType.StoredProcedure;
             cmdUspActualizar.Parameters.AddWithValue("@CodigoRuta", CodigoRuta);
             cmdUspActualizar.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
             cmdUspActualizar.Parameters.AddWithValue("@Nombre", Nombre);
             cmdUspActualizar.Parameters.AddWithValue("@Origen", Origen);
             cmdUspActualizar.Parameters.AddWithValue("@Destino", Destino);
             cmdUspActualizar.Parameters.AddWithValue("@Distancia", Distancia);
             cmdUspActualizar.Parameters.AddWithValue("@TipoRuta", TipoRuta);
             cmdUspActualizar.Parameters.AddWithValue("@Estado", Estado);
             cmdUspActualizar.ExecuteNonQuery();

             db_conexion.MtdCerrarConexion();

        }

        public void MtdEliminarRutas(int CodigoRuta)
        {
            string usp_eliminar = "usp_rutas_eliminar";  // CAMBIAR USP
            SqlCommand cmdUspEliminar = new SqlCommand(usp_eliminar, db_conexion.MtdAbrirConexion());
            cmdUspEliminar.CommandType = CommandType.StoredProcedure;
            cmdUspEliminar.Parameters.AddWithValue("@CodigoRuta", CodigoRuta);

            cmdUspEliminar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();


        }

    }
}
