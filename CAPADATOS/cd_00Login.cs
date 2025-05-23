using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS
{
    public class cd_00Login
    {
        private SqlConnection conn;

        public cd_00Login()
        {
            conn = new SqlConnection("server=EDUARDO\\SQLEXPRESS; database=TransporteB; integrated security=true");
        }
        //Metodo que me sirve para validar ususario mediante usuario y clave
        public string AutenticarUsuario(string usuario, string contraseña)
        {
            return CAPA_SEGURIDAD.cs_00Login.UsuarioAutenticacion.mtdValidacion(usuario, contraseña);
        }
    }
}
