using System.Xml.Linq;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet(Name = "Get")]
        public List<City> GetAll()
        {
            return new CityService().FindAll();
        }

        [HttpGet("Id/{id}", Name = "GetById")]
        public City GetById(int id)
        {
            return new CityService().FindById(id);
        }

        [HttpGet("Nome/{name}", Name = "GetByName")]
        public City GetByName(string name)
        {
            return new CityService().FindByName(name);
        }
    }
}
