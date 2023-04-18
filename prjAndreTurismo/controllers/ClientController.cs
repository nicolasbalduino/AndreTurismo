using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;
using prjAndreTurismo.services;

namespace prjAndreTurismo.controllers
{
    public class ClientController
    {
        public int Isert(Client client)
        {
            return new ClientService().Insert(client);
        }
    }
}
