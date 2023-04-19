using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;

namespace prjAndreTurismo.services
{
    public class ClientService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public int Insert(Client client)
        {
            string strInsert = "INSERT INTO Client (Name, Phone, AddressId) " +
                                "VALUES(@Name, @Phone, @IdAddress);" +
                                "SELECT CAST(scope_identity() as INT);";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Phone", client.Phone));
            commandInsert.Parameters.Add(new SqlParameter("@IdAddress", client.Address.Id));
            return (int)commandInsert.ExecuteScalar();
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

        public Client FindByName(string name)
        {
            // nao usar ainda
            string strSelect = $"SELECT c.Id, c.Name, c.Phone, c.AddressId " +
                                $"FROM Client c WHERE c.Description = '{name}';";
            SqlCommand commandSelect = new(strSelect, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            dr.Read();
            Client client = new();
            client.Id = (int)dr["Id"];

            conn.Close();
            return client;
        }

        public Client FindById(int id)
        {
            // nao usar ainda
            string strSelect = $"SELECT c.Id, c.Name, c.Phone, c.AddressId " +
                                $"FROM Client c WHERE c.Id = '{id}';";
            SqlCommand commandSelect = new(strSelect, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            dr.Read();
            Client client = new();
            client.Id = (int)dr["Id"];

            conn.Close();
            return client;
        }

        public bool Update(Client client)
        {
            return false;
        }

        public bool Delete(Client client)
        {
            return false;
        }
    }
}
