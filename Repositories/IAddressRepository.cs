using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IAddressRepository
    {
        int Insert(Address address);

        List<Address> FindAll();

        Address FindById(int id);

        int Update(int id, Address newAddress);

        int Delete(int id);
    }
}
