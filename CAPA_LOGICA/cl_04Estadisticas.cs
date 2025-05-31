using CAPADATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_LOGICA
{
    public class cl_04Estadisticas
    {
        cd_Conexion cd_Conexion = new cd_Conexion();


        cd_04Estadisticas datos = new cd_04Estadisticas();

        public DataTable MtdObtenerEstadisticas(int codigoTransporte, DateTime fecha)
        {
            return datos.MtdObtenerEstadisticas(codigoTransporte, fecha);
        }

    }
}
