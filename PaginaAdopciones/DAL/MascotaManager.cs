using PaginaAdopciones.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PaginaAdopciones.DAL
{
    public class MascotaManager
    {
        private SqlConnection con;

        private void Connection()
        {
            string cnn = ConfigurationManager.ConnectionStrings["MascotasCnn"].ToString();
            con = new SqlConnection(cnn);
        }

        public bool AgregarMascota(Mascota mascota)
        {
            Connection();
            var cmd = new SqlCommand("pAgregarMascota", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nombre", mascota.Nombre);
            cmd.Parameters.AddWithValue("@Edad", mascota.Edad);
            cmd.Parameters.AddWithValue("@Descrip", mascota.Descrip);
            cmd.Parameters.AddWithValue("@Correo", mascota.Correo);
            cmd.Parameters.AddWithValue("@Adoptado", 0);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;            
            else
                return false;
        }

        public List<Mascota> ObtenerMascotas()
        {
            Connection();
            var mascotas = new List<Mascota>();
            var cmd = new SqlCommand("pGetMascotas", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                mascotas.Add(new Mascota
                {
                    Nombre = Convert.ToString(dr["Nombre"]),
                    Edad = Convert.ToInt32(dr["Edad"]),
                    Descrip = Convert.ToString(dr["Descrip"]),
                    Correo = Convert.ToString(dr["Correo"]),
                    Adoptado = Convert.ToBoolean(dr["Adoptado"])
                });
            }

            return mascotas;
        }
    }   
}