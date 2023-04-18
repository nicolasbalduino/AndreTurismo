using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            conn.Open();
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

        public bool UpdateAddress(Address address) { return true; }

        public bool DeleteAddress(Address address) { return true; }
    }
}
