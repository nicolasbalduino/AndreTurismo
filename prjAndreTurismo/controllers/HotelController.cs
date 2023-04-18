using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;
using prjAndreTurismo.services;

namespace prjAndreTurismo.controllers
{
    public class HotelController
    {
        public int Insert(Hotel hotel)
        {
            return new HotelService().Insert(hotel);
        }
    }
}
