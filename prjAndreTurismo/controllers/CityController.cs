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
    }
}
