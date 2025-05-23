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
    public class cd_03Empleados
    {
        cd_Conexion cd_Conexion = new cd_Conexion();

        public DataTable MtMostrarEmpleados()
        {
            string QryMostrarEmpleados = "usp_empleados_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarEmpleados, cd_Conexion.MtdAbrirConexion());
            DataTable dtMostrarEmpleados = new DataTable();
            adapter.Fill(dtMostrarEmpleados);
            cd_Conexion.MtdCerrarConexion();
            return dtMostrarEmpleados;
        }

    }
}
