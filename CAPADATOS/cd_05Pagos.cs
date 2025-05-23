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
    public class cd_05Pagos
    {

        cd_Conexion cd_Conexion = new cd_Conexion();

        public DataTable MtMostrarPagos()
        {
            string QryMostrarPagos = "usp_pagos_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarPagos, cd_Conexion.MtdAbrirConexion());
            DataTable dtMostrarPagos = new DataTable();
            adapter.Fill(dtMostrarPagos);
            cd_Conexion.MtdCerrarConexion();
            return dtMostrarPagos;
        }
    }
}
