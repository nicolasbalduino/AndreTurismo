using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;

namespace API.Services
{
    public class CityService
    {

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            //conn.Open();
        }

        public int Insert(string description)
        {
            conn.Open();
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
            conn.Open ();
            List<City> cities = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT c.Id, c.Description, c.Created");
            sb.Append(" FROM City c");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                City showCity = new();

                showCity.Id = (int)dr["Id"];
                showCity.Description = (string)dr["Description"];
                showCity.DtCreated = (DateTime)dr["Created"];


                cities.Add(showCity);
            }
            conn.Close();
            return cities;
        }

        public City FindByName(string name)
        {
            conn.Open();
            string strSelect = $"SELECT c.Id, c.Description, c.Created FROM City c WHERE c.Description = '{name}';";
            SqlCommand commandSelect = new(strSelect, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            dr.Read();
            City city = new();
            city.Id = (int)dr["Id"];
            city.Description = (string)dr["Description"];
            city.DtCreated = (DateTime)dr["Created"];

            conn.Close();
            return city;
        }

        public City FindById(int id)
        {
            conn.Open();
            string strSelect = $"SELECT c.Id, c.Description FROM City c WHERE c.Id = {id};";
            SqlCommand commandSelect = new(strSelect, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();
            dr.Read();

            City city = new();
            city.Id = (int)dr["Id"];
            city.Description = (string)dr["Description"];

            conn.Close();
            return city;
        }

        public int UpdateCity(string name, string newName)
        {
            City cityToEdit = FindByName(name);
            if (cityToEdit == null)
                return 0;

            string strUpdate = $"UPDATE City SET Description = '{newName}' WHERE Id = {cityToEdit.Id};";
            SqlCommand commandUpdate = new(strUpdate, conn);
            return commandUpdate.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            // funciona se não estiver relacionado
            string strDelete = $"DELETE FROM City WHERE Id = {id};";
            SqlCommand commandDelete = new(strDelete, conn);
            return commandDelete.ExecuteNonQuery();
        }
    }
}
