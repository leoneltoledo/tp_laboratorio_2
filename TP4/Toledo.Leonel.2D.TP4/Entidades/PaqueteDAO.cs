using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Fields
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Methods
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }

        public static bool Insertar(Paquete p)
        {
            try
            {
                string alumno = "Leonel Toledo";
                string sql = String.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES('{0}','{1}','{2}');", p.DireccionEntrega, p.TrackingID, alumno);
                PaqueteDAO.comando.CommandText = sql;
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                PaqueteDAO.conexion.Close();
            }
            return true;
        }
        #endregion
    }
}
