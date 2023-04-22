using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace Controllers
{
    public class AddressController
    {
        public int Insert(Address address)
        {
            return new AddressService().Insert(address);
        }

        public List<Address> FindAll()
        {
            return new AddressService().FindAll();
        }

        public Address FindById(int id)
        {
            return new AddressService().FindById(id);
        }

        public int Update(int id, Address newAddress)
        {
            return new AddressService().Update(id, newAddress);
        }

        public int Delete(int id)
        {
            return new AddressService().Delete(id);
        }
    }
}
