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
        }

        public int Update(int id, Address newAddress) 
        {
            return addressRepository.Update(id, newAddress);
        }

        public int Delete(int id) 
        {
            return addressRepository.Delete(id);
        }
    }
}
