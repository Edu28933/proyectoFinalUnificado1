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

        public void MtdAgregarEmpleado(int CodigoUsuario, string Nombre, string Licencia, int Telefono, DateTime FechaContratacion, string Direccion, string Estado, string TipoEmpleado, decimal Salario)
        {
            string spCrear = "usp_Empleados_Crear";
            SqlCommand cmdCrear = new SqlCommand(spCrear, cd_Conexion.MtdAbrirConexion());
            cmdCrear.CommandType = CommandType.StoredProcedure;

            cmdCrear.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            cmdCrear.Parameters.AddWithValue("@Nombre", Nombre);
            cmdCrear.Parameters.AddWithValue("@Licencia", Licencia);
            cmdCrear.Parameters.AddWithValue("@Telefono", Telefono);
            cmdCrear.Parameters.AddWithValue("@FechaContratacion", FechaContratacion);
            cmdCrear.Parameters.AddWithValue("@Direccion", Direccion);
            cmdCrear.Parameters.AddWithValue("@Estado", Estado);
            cmdCrear.Parameters.AddWithValue("@TipoEmpleado", TipoEmpleado);
            cmdCrear.Parameters.AddWithValue("@Salario", Salario);

            cmdCrear.ExecuteNonQuery();
            cd_Conexion.MtdCerrarConexion();
        }

        public void MtdActualizarEmpleado(int CodigoEmpleado, int CodigoUsuario, string Nombre, string Licencia, int Telefono, DateTime FechaContratacion, string Direccion, string Estado, string TipoEmpleado, decimal Salario)
        {
            string spActualizar = "usp_Empleados_Editar";
            SqlCommand cmdActualizar = new SqlCommand(spActualizar, cd_Conexion.MtdAbrirConexion());
            cmdActualizar.CommandType = CommandType.StoredProcedure;

            cmdActualizar.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado); // Se agrega este parámetro
            cmdActualizar.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            cmdActualizar.Parameters.AddWithValue("@Nombre", Nombre);
            cmdActualizar.Parameters.AddWithValue("@Licencia", Licencia);
            cmdActualizar.Parameters.AddWithValue("@Telefono", Telefono);
            cmdActualizar.Parameters.AddWithValue("@FechaContratacion", FechaContratacion);
            cmdActualizar.Parameters.AddWithValue("@Direccion", Direccion);
            cmdActualizar.Parameters.AddWithValue("@Estado", Estado);
            cmdActualizar.Parameters.AddWithValue("@TipoEmpleado", TipoEmpleado);
            cmdActualizar.Parameters.AddWithValue("@Salario", Salario);

            cmdActualizar.ExecuteNonQuery();
            cd_Conexion.MtdCerrarConexion();
        }

        public void MtdEliminarEmpleado(int CodigoEmpleado)
        {
            string spEliminar = "usp_Empleados_Eliminar";
            SqlCommand cmdEliminar = new SqlCommand(spEliminar, cd_Conexion.MtdAbrirConexion());
            cmdEliminar.CommandType = CommandType.StoredProcedure;

            cmdEliminar.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            cmdEliminar.ExecuteNonQuery();

            cd_Conexion.MtdCerrarConexion();
        }

        public DataTable MtdBuscarEmpleado(string buscarParametro)
        {
            string spBuscar = "usp_Empleados_Buscar";
            SqlCommand cmdBuscar = new SqlCommand(spBuscar, cd_Conexion.MtdAbrirConexion());
            cmdBuscar.CommandType = CommandType.StoredProcedure;

            cmdBuscar.Parameters.AddWithValue("@Buscar", buscarParametro);

            SqlDataAdapter adapter = new SqlDataAdapter(cmdBuscar);
            DataTable dtEmpleados = new DataTable();
            adapter.Fill(dtEmpleados);

            cd_Conexion.MtdCerrarConexion();
            return dtEmpleados;
        }

        public decimal MtdObtenerSalario(string tipoEmpleado)
        {
            string spObtenerSalario = "usp_ObtenerSalario";
            SqlCommand cmd = new SqlCommand(spObtenerSalario, cd_Conexion.MtdAbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TipoEmpleado", tipoEmpleado);

            object result = cmd.ExecuteScalar();
            cd_Conexion.MtdCerrarConexion();

            return result != null ? Convert.ToDecimal(result) : 0; // Devuelve 0 si no hay salario definido
        }

    }
}
