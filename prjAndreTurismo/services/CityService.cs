using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;

namespace prjAndreTurismo.services
{
    public class CityService
    {

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public int Insert(string description)
        {
            //conn.Open();
            string strInsert = "INSERT INTO City (Description) VALUES(@Description);" +
                                "SELECT CAST(scope_identity() as INT);";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", description));
            var result = (int)commandInsert.ExecuteScalar();

            conn.Close();
            return result;
        }

        public List<City> FindAll()
        {
            List<City> cities = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT c.Description");
            sb.Append(" FROM City c");

            //conn.Open();
            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                City showCity = new();

                showCity.Description = (string)dr["Description"];


                cities.Add(showCity);
            }
            conn.Close();
            return cities;
        }

        public City FindByName(string name)
        {
            //conn.Open();
            string strSelect = $"SELECT c.Id, c.Description FROM City c WHERE c.Description = '{name}';";
            SqlCommand commandSelect = new(strSelect, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            City city = new();
            
            if (dr.Read())
            {
                city.Id = (int)dr["Id"];
                city.Description = (string)dr["Description"];
            }

            conn.Close();
            return city;
        }

        public City FindById(int id)
        {
            //conn.Open();
            string strSelect = $"SELECT c.Id, c.Description FROM City c WHERE c.Id = {id};";
            SqlCommand commandSelect = new(strSelect, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            City city = new();
            if (dr.Read())
            {
                city.Id = (int)dr["Id"];
                city.Description = (string)dr["Description"];
            }

            conn.Close();
            return city;
        }

        public int UpdateCity(string name, string newName)
        {
            City cityToEdit = new CityService().FindByName(name);
            if (cityToEdit == null)
                return 0;

            //conn.Open();
            string strUpdate = $"UPDATE City SET Description = '{newName}' WHERE Id = {cityToEdit.Id};";
            SqlCommand commandUpdate = new(strUpdate, conn);
            var result = commandUpdate.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public int Delete(int id)
        {
            // funciona se não estiver relacionado
            //conn.Open();
            string strDelete = $"DELETE FROM City WHERE Id = {id};";
            SqlCommand commandDelete = new(strDelete, conn);
            var result = commandDelete.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
