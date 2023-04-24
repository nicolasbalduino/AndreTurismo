﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IPackageRepository
    {
        int Insert(Package package);
        List<Package> FindAll();
        Package FindById(int id);
        int Update(Package package);
        int Delete(int id);
    }
}
