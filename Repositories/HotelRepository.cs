﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace Repositories
{
    public class HotelRepository : IHotel
    {
        private string Conn { get; set; }

        public HotelRepository() 
        { 
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public int Insert(Hotel hotel)
        {
            int result = 0;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                hotel.Address.Id = (int)db.ExecuteScalar(Address.INSERT, new
                {
                    hotel.Address.Street,
                    hotel.Address.Number,
                    hotel.Address.Neighborhood,
                    hotel.Address.PostalCode,
                    hotel.Address.Complement,
                    IdCity = hotel.Address.City.Id
                });
                result = db.Execute(Hotel.INSERT, new
                {
                    hotel.Name,
                    hotel.Price,
                    IdAddress = hotel.Address.Id
                });
                db.Close();
            }
            return result;
        }

        public List<Hotel> FindAll()
        {
            var results = new List<Hotel>();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                results = db.Query<Hotel, Address, City, Hotel>(Hotel.SELECTALL,
                    (hotel, address, city) => { hotel.Address = address; address.City = city; return hotel; },
                    splitOn: "idAddress, idCity").ToList();
                db.Close();
            }
            return results;
        }

        public Hotel FindById(int id)
        {
            var results = new Hotel();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                results = db.Query<Hotel, Address, City, Hotel>(Hotel.SELECTID,
                    (hotel, address, city) => { hotel.Address = address; address.City = city; return hotel; }, new { id },
                    splitOn: "idAddress, idCity").FirstOrDefault();
                db.Close();
            }
            return results;
        }

        public Hotel FindByName(string name)
        {
            var results = new Hotel();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                results = db.Query<Hotel, Address, City, Hotel>(Hotel.SELECTNAME,
                    (hotel, address, city) => { hotel.Address = address; address.City = city; return hotel; }, new { name },
                    splitOn: "idAddress, idCity").FirstOrDefault();
                db.Close();
            }
            return results;
        }

        public int Update(int id, Hotel newData)
        {
            int result = 0;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                newData.Id = id;
                result = db.Execute(Hotel.UPDATE, new
                {
                    newData.Id,
                    newData.Name,
                    newData.Price,
                    IdAddress = newData.Address.Id
                });
                db.Close();
            }
            return result;
        }

        public int Delete(int id)
        {
            int result = 0;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                result = db.Execute(Hotel.DELETE, new { id });
                db.Close();
            }
            return result;
        }
    }
}