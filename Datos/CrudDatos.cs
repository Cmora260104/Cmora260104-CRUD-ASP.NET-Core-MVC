using PracticaMVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace PracticaMVC.Datos
{
    public class CrudDatos
    {
        public List<DatosModels> Listar()
        {

            var oLista = new List<DatosModels>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("p_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new DatosModels()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Salario = Convert.ToDecimal(dr["Salario"]),
                            FechaNacimiento = dr["FechaNacimiento"].ToString()
                        });

                    }
                }
            }

            return oLista;
        }
        public DatosModels Obtener(int Id)
        {

            var datos = new DatosModels();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("p_Obtener", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        datos.Id = Convert.ToInt32(dr["Id"]);
                        datos.Nombre = dr["Nombre"].ToString();
                        datos.Salario = Convert.ToDecimal(dr["Salario"]);
                        datos.FechaNacimiento = dr["FechaNacimiento"].ToString();
                    }
                }
            }

            return datos;
        }

        public bool Insertar(DatosModels odatos)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("p_Insertar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", odatos.Nombre);
                    cmd.Parameters.Add("Salario", SqlDbType.Decimal).Value = odatos.Salario;
                    cmd.Parameters.AddWithValue("FechaNacimiento", odatos.FechaNacimiento);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Actualizar(DatosModels odatos)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Actualizar", conexion);
                    cmd.Parameters.AddWithValue("Id", odatos.Id);
                    cmd.Parameters.AddWithValue("Nombre", odatos.Nombre);
                    cmd.Parameters.Add("Salario", SqlDbType.Decimal).Value = odatos.Salario;
                    cmd.Parameters.AddWithValue("FechaNacimiento", odatos.FechaNacimiento);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int Id)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
