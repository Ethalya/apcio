using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLab7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static List<Students> lista;
        public StudentsController()
        {
            lista = new List<Students>()
            {
                new Students() { Id = 1, FName = "Piernik", LName = "Piernikowy", Album = "11111", Plec = "Ciasto"},
                new Students() { Id = 2, FName = "Janusz", LName = "Korwin Mikke", Album = "666", Plec = "Raper"},
                new Students() { Id = 3, FName = "Tak", LName = "Było", Album = "12345", Plec = "Tak"},
            };
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<Students> Get()
        {
            return lista;
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public Students Get(int id)
        {
            return lista.FirstOrDefault(x => x.Id == id);
        }

        // POST: api/Students
        [HttpPost]
        public void Post([FromBody] Students item)
        {
            lista.Add(item);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Students value)
        {
            var item = lista.FirstOrDefault(x => x.Id == id);

            item.FName = value.FName;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = lista.FirstOrDefault(x => x.Id == id);
            lista.Remove(item);
        }
    }
}
