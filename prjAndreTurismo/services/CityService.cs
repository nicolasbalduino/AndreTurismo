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
            string strInsert = "INSERT INTO City (Description) VALUES(@Description);" +
                                "SELECT CAST(scope_identity() as INT);";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", description));
            return (int)commandInsert.ExecuteScalar();
        }

        public List<City> FindAll()
        {
            List<City> cities = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT c.Description");
            sb.Append(" FROM City c");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                City showCity = new();

                showCity.Description = (string)dr["Description"];


                cities.Add(showCity);
            }
            return cities;
        }

        public City FindByName(string name)
        {
            string strSelect = $"SELECT c.Id, c.Description FROM City c WHERE c.Description = '{name}';";
            SqlCommand commandSelect = new(strSelect, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            dr.Read();
            City city = new();
            city.Id = (int)dr["Id"];
            city.Description = (string)dr["Description"];

            return city;
        }

        public City FindById(int id)
        {
            string strSelect = $"SELECT c.Id, c.Description FROM City c WHERE c.Id = {id};";
            SqlCommand commandSelect = new(strSelect, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();
            dr.Read();

            City city = new();
            city.Id = (int)dr["Id"];
            city.Description = (string)dr["Description"];

            return city;
        }

        public bool UpdateCity(City city)
        {
            return true;
        }

        public int Delete(int id)
        {
            // nao funciona
            string strDelete = $"DELETE FROM City WHERE Id = {id};";
            SqlCommand commandDelete = new(strDelete, conn);
            return commandDelete.ExecuteNonQuery();
        }
    }
}
