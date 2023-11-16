using Proyect_web_def.Data;
using Proyect_web_def.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Proyect_web_def.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Proyect_web_def.Logica
{
    public class LO_Usuario
    {
        public Usuario EncontrarUsuario(string correo, string clave)
        {

            Usuario objeto = new Usuario();


            using (SqlConnection conexion = new SqlConnection("Server=LAPTOP-CLS61AKL\\SQLEXPRESS;Database=Proyect_web_def.Data;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {

                string query = "select UsuarioID,Nombres,Correo,Clave,IdRol from Usuario where Correo = @pcorreo and Clave = @pclave";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pcorreo", correo);
                cmd.Parameters.AddWithValue("@pclave", clave);
                cmd.CommandType = CommandType.Text;


                conexion.Open();


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        objeto = new Usuario()
                        {
                           // UsuarioID = (int)dr["UsuarioID"],
                            Nombres = dr["Nombres"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            //RolEnumClase.IdRolEnum = (RolEnumClase.RolEnum)dr["IdRol"],

                        };
                    }

                }
            }
            return objeto;

        }

    }
}
