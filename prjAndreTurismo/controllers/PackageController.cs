using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;
using prjAndreTurismo.services;

namespace prjAndreTurismo.controllers
{
    public class PackageController
    {
        public int Insert(Package package)
        {
            return new PackageService().Insert(package);
        }

        public List<Package> FindAll()
        {
            return new PackageService().FindAll();
        }

        public Package FindById(int id)
        {
            return new PackageService().FindById(id);
        }

        public int Delete(int id)
        {
            return new PackageService().Delete(id);
        }
    }
}
