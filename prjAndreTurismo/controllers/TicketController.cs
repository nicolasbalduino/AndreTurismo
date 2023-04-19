using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjAndreTurismo.models;
using prjAndreTurismo.services;

namespace prjAndreTurismo.controllers
{
    public class TicketController
    {
        public int Insert(Ticket ticket)
        {
            return new TicketService().Insert(ticket);
        }

        public List<Ticket> FindAll()
        {
            return new TicketService().FindAll();
        }

        public Ticket FindById(int id)
        {
            return new TicketService().FindById(id);
        }

        public int Delete()
        {
            return 0;
        }
    }
}
