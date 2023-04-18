using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;
using prjAndreTurismo.services;

namespace prjAndreTurismo.controllers
{
    public class CityController
    {
        public int Insert(string description)
        {
            return new CityService().Insert(description);
        }

        public List<City> FindAll()
        {
            return new CityService().FindAll();
        }

        public City FindByName(string name)
        {
            return new CityService().FindByName(name);
        }

        public City FindById(int id)
        {
            return new CityService().FindById(id);
        }

        public int Delete(int id)
        {
            return new CityService().Delete(id);
        }
    }
}
