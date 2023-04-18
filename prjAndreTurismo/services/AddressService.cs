using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.controllers;
using prjAndreTurismo.models;

namespace prjAndreTurismo.services
{
    public class AddressService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public AddressService()
        {
            conn = new SqlConnection(strConn);
            //conn.Open();
        }

        public int Insert(Address address) 
        {
            string strInsert = "INSERT INTO Address (Street, Number, Neighborhood, PostalCode, Complement, IdCity) " +
                                "VALUES(@Street, @Number, @Neighborhood, @PostalCode, @Complement, @IdCity);" +
                                "SELECT CAST(scope_identity() as INT);";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
            commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
            commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
            commandInsert.Parameters.Add(new SqlParameter("@PostalCode", address.CEP));
            commandInsert.Parameters.Add(new SqlParameter("@Complement", address.Complement));
            commandInsert.Parameters.Add(new SqlParameter("@IdCity", address.City.Id));
            return (int)commandInsert.ExecuteScalar();
        }

        public bool FindAll(Address address) { return true; }

        public Address FindById(int id)
        {
            conn.Open();
            string strSelect = $"SELECT a.Id, a.Street, a.Number, a.Complement, a.Neighborhood, a.IdCity, a.PostalCode " +
                                $"FROM Address a WHERE a.Id = {id};";
            SqlCommand commandSelect = new(strSelect, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();
            dr.Read();

            Address address = new();
            address.Id = (int)dr["Id"];
            address.Street = (string)dr["Street"];
            address.Number = (int)dr["Number"];
            address.Complement = (string)dr["Complement"];
            address.Neighborhood = (string)dr["Neighborhood"];
            address.City = new CityController().FindById((int)dr["IdCity"]);
            address.CEP = (string)dr["PostalCode"];

            conn.Close();

            return address;
        }

        public int Update(int id, Address newAddress) 
        {
            Address oldAddress = FindById(id);

            conn.Open();

            string strUpdate = "UPDATE Address SET " +
                "Street = @Street, Number = @Number, Neighborhood = @Neighborhood, " +
                "Complement = @Complement, PostalCode = @PostalCode, IdCity = @IdCity " +
                "WHERE Id = @Id;";
            SqlCommand commandUpdate = new SqlCommand(strUpdate, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@Street", newAddress.Street));
            commandUpdate.Parameters.Add(new SqlParameter("@Number", newAddress.Number));
            commandUpdate.Parameters.Add(new SqlParameter("@Neighborhood", newAddress.Neighborhood));
            commandUpdate.Parameters.Add(new SqlParameter("@Complement", newAddress.Complement));
            commandUpdate.Parameters.Add(new SqlParameter("@PostalCode", newAddress.CEP));
            commandUpdate.Parameters.Add(new SqlParameter("@IdCity", newAddress.City.Id));
            commandUpdate.Parameters.Add(new SqlParameter("@Id", id));

            int rowsAffect = (int)commandUpdate.ExecuteNonQuery();

            conn.Close();
            
            return rowsAffect;

        }

        public int Delete(int id) 
        {
            string strDelete = "DELETE FROM Address WHERE Id = @Id";
            SqlCommand commandDelete = new SqlCommand(strDelete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@Id", id));
            return (int)commandDelete.ExecuteNonQuery();
        }
    }
}
