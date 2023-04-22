using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private string Conn { get; set; }

        public AddressRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public int Insert(Address address)
        {
            int result = 0;
            using(var db = new SqlConnection(Conn))
            {
                db.Open();
                address.City.Id = (int)db.ExecuteScalar(City.INSERT, address.City);
                result = db.Execute(Address.INSERT, new
                {
                    address.Street,
                    address.Number,
                    address.Neighborhood,
                    address.CEP,
                    address.Complement,
                    IdCity = address.City.Id
                });
                db.Close();
            }
            return result;
        }

        public List<Address> FindAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Close();
            }
            return new();
        }

        public Address FindById(int id)
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Close();
            }
            return new();
        }

        public int Update(int id, Address newAddress)
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Close();
            }
            return 0;
        }

        public int Delete(int id)
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Close();
            }
            return 0;
        }
    }
}
