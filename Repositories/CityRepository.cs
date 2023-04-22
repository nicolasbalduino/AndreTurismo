using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using Models;

namespace Repositories
{
    public class CityRepository : ICityRepository
    {
        private string Conn { get; set; }

        public CityRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<City> FindAll()
        {
            throw new NotImplementedException();
        }

        public City FindById(int id)
        {
            throw new NotImplementedException();
        }

        public City FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(City city)
        {
            int result = 0;
            using(var db = new SqlConnection(Conn))
            {
                db.Open();
                result = db.Execute(City.INSERT, city);
                db.Close();
                return result;
            }
        }

        public int UpdateCity(string name, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
