﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;

namespace prjAndreTurismo.services
{
    public class CityService
    {

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\user\source\repos\prjAndreTurismo\AndreTurismo.mdf;";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool CreateCity( City city)
        {
            return true;
        }

        public bool FindAll(City city)
        {
            return true;
        }

        public bool UpdateCity(City city)
        {
            return true;
        }

        public bool DeleteCity(City city)
        {
            return true;
        }
    }
}
