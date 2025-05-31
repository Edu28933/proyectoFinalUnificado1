using CAPADATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class cd_04Estadisticas
    {
        cd_Conexion cd_Conexion = new cd_Conexion();

        public DataTable MtMostrarEstadisticas()
        {
            string QryMostrarEstadisticas = "usp_estadisticas_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarEstadisticas, cd_Conexion.MtdAbrirConexion());
            DataTable dtMostrarEstadisticas = new DataTable();
            adapter.Fill(dtMostrarEstadisticas);
            cd_Conexion.MtdCerrarConexion();
            return dtMostrarEstadisticas;
        }

        public DataTable MtdObtenerEstadisticas(int codigoTransporte, DateTime fecha)
        {
            SqlCommand cmd = new SqlCommand("SELECT " +
                "dbo.fn_TotalIngresos(@CodigoTransporte, @Fecha) AS TotalIngresos, " +
                "dbo.fn_TotalIncidentes(@CodigoTransporte, @Fecha) AS TotalIncidentes, " +
                "dbo.fn_MonedaMasUtilizada(@CodigoTransporte, @Fecha) AS MonedaMasUsada, " +
                "dbo.fn_TotalPasajeros(@CodigoTransporte, @Fecha) AS TotalPasajeros", cd_Conexion.MtdAbrirConexion());

            cmd.Parameters.AddWithValue("@CodigoTransporte", codigoTransporte);
            cmd.Parameters.AddWithValue("@Fecha", fecha);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cd_Conexion.MtdCerrarConexion();
            return dt;
        }

    }
}
