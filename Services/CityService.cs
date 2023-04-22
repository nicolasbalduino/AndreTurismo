using Models;
using Repositories;

namespace Services
{
    public class CityService
    {

        private ICityRepository cityRepository;

        public CityService()
        {
            cityRepository = new CityRepository();
        }

        public int Insert(City city)
        {
            return cityRepository.Insert(city);
        }

        public List<City> FindAll()
        {
            //List<City> cities = new();

            //StringBuilder sb = new StringBuilder();
            //sb.Append("SELECT c.Description");
            //sb.Append(" FROM City c");

            //SqlCommand commandSelect = new(sb.ToString(), conn);
            //SqlDataReader dr = commandSelect.ExecuteReader();

            //while (dr.Read())
            //{
            //    City showCity = new();

            //    showCity.Description = (string)dr["Description"];


            //    cities.Add(showCity);
            //}
            return new(); // cities;
        }

        public City FindByName(string name)
        {
            //string strSelect = $"SELECT c.Id, c.Description FROM City c WHERE c.Description = '{name}';";
            //SqlCommand commandSelect = new(strSelect, conn);
            //SqlDataReader dr = commandSelect.ExecuteReader();

            //City city = new();

            //if (dr.Read())
            //{
            //    city.Id = (int)dr["Id"];
            //    city.Description = (string)dr["Description"];
            //}

            return new();// city;
        }

        public City FindById(int id)
        {
            //string strSelect = $"SELECT c.Id, c.Description FROM City c WHERE c.Id = {id};";
            //SqlCommand commandSelect = new(strSelect, conn);
            //SqlDataReader dr = commandSelect.ExecuteReader();

            //City city = new();
            //if (dr.Read())
            //{
            //    city.Id = (int)dr["Id"];
            //    city.Description = (string)dr["Description"];
            //}

            return new(); // city;
        }

        public int UpdateCity(string name, string newName)
        {
            //City cityToEdit = new CityService().FindByName(name);
            //if (cityToEdit == null)
            //    return 0;

            //string strUpdate = $"UPDATE City SET Description = '{newName}' WHERE Id = {cityToEdit.Id};";
            //SqlCommand commandUpdate = new(strUpdate, conn);
            //var result = commandUpdate.ExecuteNonQuery();
            return 0; // result;
        }

        public int Delete(int id)
        {
            //string strDelete = $"DELETE FROM City WHERE Id = {id};";
            //SqlCommand commandDelete = new(strDelete, conn);
            //var result = commandDelete.ExecuteNonQuery();
            return 0; // result;
        }
    }
}
