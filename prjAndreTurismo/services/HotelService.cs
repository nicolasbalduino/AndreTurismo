using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using prjAndreTurismo.models;

namespace prjAndreTurismo.services
{
    public class HotelService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            //conn.Open();
        }

        public int Insert(Hotel hotel)
        {
            conn.Open();
            string strInsert = "INSERT INTO Hotel (Name, IdAddress, Price) " +
                                "VALUES(@Name, @IdAddress, @Price);" +
                                "SELECT CAST(scope_identity() as INT);";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Name", hotel.Name));
            commandInsert.Parameters.Add(new SqlParameter("@IdAddress", new AddressService().Insert(hotel.Address)));
            commandInsert.Parameters.Add(new SqlParameter("@Price", hotel.Price));
            var result = (int)commandInsert.ExecuteScalar();

            conn.Close();
            return result;
        }

        public List<Hotel> FindAll()
        {
            string strSelect = "SELECT h.Id, h.Name, h.Price, a.Id idAddress, a.Street, a.Number, a.Complement, " +
                                "a.Neighborhood, c.Id as idCity, c.Description, a.PostalCode " +
                                "FROM Hotel h " +
                                "join Address a on h.IdAddress = a.Id " +
                                "join City c on a.IdCity = c.Id;";
            SqlCommand commandFindAll = new SqlCommand(strSelect, conn);
            var resultsHotel = commandFindAll.ExecuteReader();

            List<Hotel> hotels = new();
            while (resultsHotel.Read())
            {
                Hotel hotel = new Hotel();
                hotel.Id = (int)resultsHotel["Id"];
                hotel.Name = (string)resultsHotel["Name"];
                hotel.Price = (double)(decimal)resultsHotel["Price"];
                hotel.Address = new() { Id = (int)resultsHotel["IdAddress"] };
                hotel.Address.Street = (string)resultsHotel["Street"];
                hotel.Address.Number = (int)resultsHotel["Number"];
                hotel.Address.Complement = (string)resultsHotel["Complement"];
                hotel.Address.Neighborhood = (string)resultsHotel["Neighborhood"];
                hotel.Address.CEP = (string)resultsHotel["PostalCode"];
                hotel.Address.City = new() { Id = (int)resultsHotel["idCity"] };
                hotel.Address.City.Description = (string)resultsHotel["Description"];

                hotels.Add(hotel);
            }
            return hotels;
        }

        public Hotel FindById(int id)
        {
            string strSelect = "SELECT h.Id, h.Name, h.Price, a.Id idAddress, a.Street, a.Number, a.Complement, " +
                                "a.Neighborhood, c.Id as idCity, c.Description, a.PostalCode " +
                                "FROM Hotel h " +
                                "JOIN Address a on h.IdAddress = a.Id " +
                                "JOIN City c on a.IdCity = c.Id " +
                                "WHERE h.Id = @Id";
            SqlCommand commandSelect = new SqlCommand(strSelect, conn);
            commandSelect.Parameters.Add(new SqlParameter("@Id", id));
            var resultsHotel = commandSelect.ExecuteReader();
            resultsHotel.Read();
            
                Hotel hotel = new Hotel();
                hotel.Id = (int)resultsHotel["Id"];
                hotel.Name = (string)resultsHotel["Name"];
                hotel.Price = (double)(decimal)resultsHotel["Price"];
                hotel.Address = new() { Id = (int)resultsHotel["IdAddress"] };
                hotel.Address.Street = (string)resultsHotel["Street"];
                hotel.Address.Number = (int)resultsHotel["Number"];
                hotel.Address.Complement = (string)resultsHotel["Complement"];
                hotel.Address.Neighborhood = (string)resultsHotel["Neighborhood"];
                hotel.Address.CEP = (string)resultsHotel["PostalCode"];
                hotel.Address.City = new() { Id = (int)resultsHotel["idCity"] };
                hotel.Address.City.Description = (string)resultsHotel["Description"];
            return hotel;
        }

        public Hotel FindByName(string name)
        {
            string strSelect = "SELECT h.Id, h.Name, h.Price, a.Id idAddress, a.Street, a.Number, a.Complement, " +
                                "a.Neighborhood, c.Id as idCity, c.Description, a.PostalCode " +
                                "FROM Hotel h " +
                                "JOIN Address a on h.IdAddress = a.Id " +
                                "JOIN City c on a.IdCity = c.Id " +
                                "WHERE h.Name = @Name";
            SqlCommand commandSelect = new SqlCommand(strSelect, conn);
            commandSelect.Parameters.Add(new SqlParameter("@Name", name));
            var resultsHotel = commandSelect.ExecuteReader();
            resultsHotel.Read();

            Hotel hotel = new Hotel();
            hotel.Id = (int)resultsHotel["Id"];
            hotel.Name = (string)resultsHotel["Name"];
            hotel.Price = (double)(decimal)resultsHotel["Price"];
            hotel.Address = new() { Id = (int)resultsHotel["IdAddress"] };
            hotel.Address.Street = (string)resultsHotel["Street"];
            hotel.Address.Number = (int)resultsHotel["Number"];
            hotel.Address.Complement = (string)resultsHotel["Complement"];
            hotel.Address.Neighborhood = (string)resultsHotel["Neighborhood"];
            hotel.Address.CEP = (string)resultsHotel["PostalCode"];
            hotel.Address.City = new() { Id = (int)resultsHotel["idCity"] };
            hotel.Address.City.Description = (string)resultsHotel["Description"];
            return hotel;
        }

        public int Update(int id, Hotel newData)
        {
            //var toEdit = FindById(id);

            string strSelect = "UPDATE Hotel " +
                                "SET Name = @Name, IdAddress = @IdAddress, Price = @Price " +
                                "WHERE Id = @Id";
            SqlCommand commandSelect = new SqlCommand(strSelect, conn);
            commandSelect.Parameters.Add(new SqlParameter("@Name", newData.Name));
            commandSelect.Parameters.Add(new SqlParameter("@IdAddress", newData.Address.Id));
            commandSelect.Parameters.Add(new SqlParameter("@Price", newData.Price));
            commandSelect.Parameters.Add(new SqlParameter("@Id", id));
            return commandSelect.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            string strSelect = "DELETE FROM Hotel WHERE Id = @Id";
            SqlCommand commandSelect = new SqlCommand(strSelect, conn);
            commandSelect.Parameters.Add(new SqlParameter("@Id", id));
            return commandSelect.ExecuteNonQuery();
        }
    }
}
