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

    }
}
