﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;
using prjAndreTurismo.services;

namespace prjAndreTurismo.controllers
{
    public class AddressController
    {
        public int Insert(Address address)
        {
            return new AddressService().Insert(address);
        }
    }
}