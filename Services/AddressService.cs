using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Services
{
    public class AddressService
    {
        private IAddressRepository addressRepository;

        public AddressService()
        {
            addressRepository = new AddressRepository();
        }

        public int Insert(Address address) 
        {
            return addressRepository.Insert(address);
        }

        public List<Address> FindAll()
        {
            return addressRepository.FindAll();
        }

        public Address FindById(int id)
        {
            return addressRepository.FindById(id);
            //string strSelect = $"SELECT a.Id, a.Street, a.Number, a.Complement, a.Neighborhood, a.IdCity, a.PostalCode " +
            //                    $"FROM Address a WHERE a.Id = {id};";
            //SqlCommand commandSelect = new(strSelect, conn);
            //SqlDataReader dr = commandSelect.ExecuteReader();

            //Address address = new();
            //if (dr.Read())
            //{
            //    address.Id = (int)dr["Id"];
            //    address.Street = (string)dr["Street"];
            //    address.Number = (int)dr["Number"];
            //    address.Complement = (string)dr["Complement"];
            //    address.Neighborhood = (string)dr["Neighborhood"];
            //    address.City = new CityService().FindById((int)dr["IdCity"]);
            //    address.CEP = (string)dr["PostalCode"];
            //}

            //return address;
            return new();
        }

        public int Update(int id, Address newAddress) 
        {
            return addressRepository.Update(id, newAddress);
            //Address oldAddress = new AddressService().FindById(id);

            //string strUpdate = "UPDATE Address SET " +
            //    "Street = @Street, Number = @Number, Neighborhood = @Neighborhood, " +
            //    "Complement = @Complement, PostalCode = @PostalCode, IdCity = @IdCity " +
            //    "WHERE Id = @Id;";
            //SqlCommand commandUpdate = new SqlCommand(strUpdate, conn);
            //commandUpdate.Parameters.Add(new SqlParameter("@Street", newAddress.Street));
            //commandUpdate.Parameters.Add(new SqlParameter("@Number", newAddress.Number));
            //commandUpdate.Parameters.Add(new SqlParameter("@Neighborhood", newAddress.Neighborhood));
            //commandUpdate.Parameters.Add(new SqlParameter("@Complement", newAddress.Complement));
            //commandUpdate.Parameters.Add(new SqlParameter("@PostalCode", newAddress.CEP));
            //commandUpdate.Parameters.Add(new SqlParameter("@IdCity", new CityService().Insert(newAddress.City)));
            //commandUpdate.Parameters.Add(new SqlParameter("@Id", id));

            //int rowsAffect = (int)commandUpdate.ExecuteNonQuery();

            //return rowsAffect;
            return 0;

        }

        public int Delete(int id) 
        {
            return addressRepository.Delete(id);
            //string strDelete = "DELETE FROM Address WHERE Id = @Id";
            //SqlCommand commandDelete = new SqlCommand(strDelete, conn);
            //commandDelete.Parameters.Add(new SqlParameter("@Id", id));
            //var result = commandDelete.ExecuteNonQuery();
            //return result;
            return 0;
        }
    }
}
