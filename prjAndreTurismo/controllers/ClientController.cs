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
            return new ClientService().FindAll();
        }

        public List<Client> FindByName(string name)
        {
            return new ClientService().FindByName(name);
        }

        public Client FindById(int id)
        {
            return new ClientService().FindById(id);
        }

        public int Update(int id, Client newClient)
        {
            return new ClientService().Update(id, newClient);
        }

        public int Delete(int id)
        {
            return new ClientService().Delete(id);
        }
    }
}
