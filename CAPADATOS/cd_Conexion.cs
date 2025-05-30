using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class cd_Conexion
    {

        //private SqlConnection db_conexion = new SqlConnection("Data Source=EDUARDO\\SQLEXPRESS;Initial Catalog=TransporteDB3;Integrated Security=True;Encrypt=False");
        private SqlConnection db_conexion = new SqlConnection("Data Source=PACHECO777\\SQLEXPRESS;Initial Catalog=TransporteDB3;Integrated Security=True;Encrypt=False");

       // private SqlConnection db_conexion = new SqlConnection("Data Source=EDUARDO\\SQLEXPRESS;Initial Catalog=TransporteDB3;Integrated Security=True;Encrypt=False");
        //private SqlConnection db_conexion = new SqlConnection("Data Source=PACHECO777\\SQLEXPRESS;Initial Catalog=TransporteDB3;Integrated Security=True;Encrypt=False");

        //private SqlConnection db_conexion = new SqlConnection("Data Source=ASTRIDCHACON\\SQLEXPRESS;Initial Catalog=TransporteDB3;Integrated Security=True;Encrypt=False");


        public SqlConnection MtdAbrirConexion()
        {
            if (db_conexion.State == ConnectionState.Closed)
                db_conexion.Open();
            return db_conexion;
        }

        public SqlConnection MtdCerrarConexion()
        {
            if (db_conexion.State == ConnectionState.Closed)
                db_conexion.Close();
            return db_conexion;
        }


    }
}
