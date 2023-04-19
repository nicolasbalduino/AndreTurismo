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

        public List<Client> FindAll()
        {
            return new List<Client>();
        }

        public List<Client> FindByName(string name)
        {
            return new List<Client>();
        }

        public List<Client> FindById(int id)
        {
            return new List<Client>();
        }

        public int Update(int id, Client newClient)
        {
            return 0;
        }

        public int Delete(int id)
        {
            return 0;
        }
    }
}
