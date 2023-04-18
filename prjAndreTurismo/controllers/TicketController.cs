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
    }
}
