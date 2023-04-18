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

        public bool FindAll(Client client)
        {
            return false;
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

        public bool UpdateClient(Client client)
        {
            return false;
        }

        public bool DeleteClient(Client client)
        {
            return false;
        }
    }
}
