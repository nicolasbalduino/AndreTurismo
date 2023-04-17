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

        public int Insert( City city)
        {
            string strInsert = "INSERT INTO City (Description) VALUES(@Description);";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
            return commandInsert.ExecuteNonQuery();
        }

        public bool FindAll(City city)
        {
            return true;
        }

        public bool UpdateCity(City city)
        {
            return true;
        }

        public bool DeleteCity(City city)
        {
            return true;
        }
    }
}
