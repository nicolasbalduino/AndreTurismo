using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

        public List<Hotel> FindAll()
        {
            return new HotelService().FindAll();
        }
        public Hotel FindById(int id)
        {
            return new HotelService().FindById(id);
        }

        public Hotel FindByName(string name)
        {
            return new HotelService().FindByName(name);
        }

        public int Update(int id, Hotel newData)
        {
            return new HotelService().Update(id, newData);
        }

        public int Delete(int id)
        {
            return new HotelService().Delete(id);
        }
    }
}
