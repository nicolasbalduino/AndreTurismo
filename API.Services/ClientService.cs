using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using API.Models;

namespace API.Services
{
    public class ClientService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            //conn.Open();
        }

        public int Insert(Client client)
        {
            conn.Open();
            string strInsert = "INSERT INTO Client (Name, Phone, AddressId) " +
                                "VALUES(@Name, @Phone, @IdAddress);" +
                                "SELECT CAST(scope_identity() as INT);";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Phone", client.Phone));
            commandInsert.Parameters.Add(new SqlParameter("@IdAddress", new AddressService().Insert(client.Address)));
            var result = (int)commandInsert.ExecuteScalar();

            conn.Close();
            return result;
        }

        public List<Client> FindAll()
        {
            string strSelect = "SELECT c.Id, c.Name, c.Phone, a.Id IdAddress, a.Street, a.Number, a.Complement, " +
                "a.Neighborhood, cl.Id IdCity, cl.Description City, a.PostalCode " +
                "FROM Client c " +
                "LEFT JOIN Address a on c.AddressId = a.Id " +
                "LEFT JOIN City cl on a.IdCity = cl.Id";
            SqlCommand commandSelect = new SqlCommand(strSelect, conn);
            SqlDataReader results = commandSelect.ExecuteReader();

            List<Client> clients = new List<Client>();
            while (results.Read())
            {
                Client client = new();
                client.Id = (int)results["Id"];
                client.Name = (string)results["Name"];
                client.Phone = (string)results["Phone"];
                client.Address = new();
                client.Address.Id = (int)results["IdAddress"];
                client.Address.Street = (string)results["Street"];
                client.Address.Number = (int)results["Number"];
                client.Address.Complement = (string)results["Complement"];
                client.Address.Neighborhood = (string)results["Neighborhood"];
                client.Address.CEP = (string)results["PostalCode"];               
                if (results["IdCity"] != DBNull.Value)
                {
                    client.Address.City = new();
                    client.Address.City.Id = (int)results["IdCity"];
                    client.Address.City.Description = (string)results["City"];
                }
                                
                clients.Add(client);
            }
            return clients;
        }

        public List<Client> FindByName(string name)
        {
            string strSelect = "SELECT c.Id, c.Name, c.Phone, a.Id IdAddress, a.Street, a.Number, a.Complement, " +
                "a.Neighborhood, cl.Id IdCity, cl.Description City, a.PostalCode " +
                "FROM Client c " +
                "LEFT JOIN Address a on c.AddressId = a.Id " +
                "LEFT JOIN City cl on a.IdCity = cl.Id " +
                "WHERE c.Name = @Name";
            SqlCommand commandSelect = new SqlCommand(strSelect, conn);
            commandSelect.Parameters.Add(new SqlParameter("@Name", name));
            SqlDataReader results = commandSelect.ExecuteReader();

            List<Client> clients = new List<Client>();
            while (results.Read())
            {
                Client client = new();
                client.Id = (int)results["Id"];
                client.Name = (string)results["Name"];
                client.Phone = (string)results["Phone"];
                client.Address = new();
                client.Address.Id = (int)results["IdAddress"];
                client.Address.Street = (string)results["Street"];
                client.Address.Number = (int)results["Number"];
                client.Address.Complement = (string)results["Complement"];
                client.Address.Neighborhood = (string)results["Neighborhood"];
                client.Address.CEP = (string)results["PostalCode"];
                if (results["IdCity"] != DBNull.Value)
                {
                    client.Address.City = new();
                    client.Address.City.Id = (int)results["IdCity"];
                    client.Address.City.Description = (string)results["City"];
                }

                clients.Add(client);
            }
            return clients;
        }

        public Client FindById(int id)
        {
            string strSelect = "SELECT c.Id, c.Name, c.Phone, a.Id IdAddress, a.Street, a.Number, a.Complement, " +
                "a.Neighborhood, cl.Id IdCity, cl.Description City, a.PostalCode " +
                "FROM Client c " +
                "LEFT JOIN Address a on c.AddressId = a.Id " +
                "LEFT JOIN City cl on a.IdCity = cl.Id " +
                "WHERE c.Id = @Id";
            SqlCommand commandSelect = new SqlCommand(strSelect, conn);
            commandSelect.Parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader results = commandSelect.ExecuteReader();

            Client client = new();
            if (results.Read())
            {
                client.Id = (int)results["Id"];
                client.Name = (string)results["Name"];
                client.Phone = (string)results["Phone"];
                client.Address = new();
                client.Address.Id = (int)results["IdAddress"];
                client.Address.Street = (string)results["Street"];
                client.Address.Number = (int)results["Number"];
                client.Address.Complement = (string)results["Complement"];
                client.Address.Neighborhood = (string)results["Neighborhood"];
                client.Address.CEP = (string)results["PostalCode"];
                if (results["IdCity"] != DBNull.Value)
                {
                    client.Address.City = new();
                    client.Address.City.Id = (int)results["IdCity"];
                    client.Address.City.Description = (string)results["City"];
                }
            }
            return client;
        }

        public int Update(int id, Client newClient)
        {
            //conn.Open();

            string strUpdate = "UPDATE Client SET Name = @Name, Phone = @Phone " +
                                "WHERE Id = @Id;";
            SqlCommand commandUpdate = new SqlCommand(strUpdate, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@Name", newClient.Name));
            commandUpdate.Parameters.Add(new SqlParameter("@Phone", newClient.Phone));
            commandUpdate.Parameters.Add(new SqlParameter("@Id", id));

            int rowsAffect = (int)commandUpdate.ExecuteNonQuery();

            //conn.Close();

            return rowsAffect;
        }

        public int Delete(int id)
        {
            string strUpdate = "DELETE FROM Client WHERE Id = @Id;";
            SqlCommand commandDelete = new SqlCommand(strUpdate, conn);
            commandDelete.Parameters.Add(new SqlParameter("@Id", id));

            int rowsAffect = (int)commandDelete.ExecuteNonQuery();

            return rowsAffect;
        }
    }
}
