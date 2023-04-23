using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IHotel
    {
        int Insert(Hotel hotel);

        List<Hotel> FindAll();

        Hotel FindById(int id);

        Hotel FindByName(string name);

        int Update(int id, Hotel newData);

        int Delete(int id);
    }
}
