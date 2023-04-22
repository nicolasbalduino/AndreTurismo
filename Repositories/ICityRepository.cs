using Models;

namespace Repositories
{
    public interface ICityRepository
    {
        int Insert(City city);

        List<City> FindAll();

        City FindByName(string name);

        City FindById(int id);

        int Update(string name, string newName);

        int Delete(int id);
    }
}
