using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_SEGURIDAD
{
    public class cs_00Login
    {
        public static class UsuarioAutenticacion
        {
            public static string mtdValidacion(string nombre, string Contraseña)
            {
                string Nombre = null;
                string conexionString = "server=EDUARDO\\SQLEXPRESS; database=TransporteDB3; integrated security=true";

                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string query = "SELECT Nombre FROM tbl_Usuarios WHERE Nombre=@Nombre AND Contraseña=@Contraseña AND Estado='Activo'";
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Contraseña", Contraseña);

                        conexion.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            Nombre = reader["Nombre"].ToString();
                        }
                    }
                }

                return Nombre;
            }
        }
    }
}
