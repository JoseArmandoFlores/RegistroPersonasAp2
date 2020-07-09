using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegistroPersonas.BLL;
using RegistroPersonas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrestamosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        // GET: api/prestamos
        [HttpGet]
        public ActionResult<List<Prestamos>> Get()
        {
            return PrestamosBLL.GetList(x => true);
        }

        // GET api/prestamos/5
        [HttpGet("{id}")]
        public ActionResult<Prestamos> Get(int id)
        {
            return PrestamosBLL.Buscar(id);
        }

        // POST api/prestamos
        [HttpPost]
        public void Post([FromBody] Prestamos prestamos)
        {
            PrestamosBLL.Guardar(prestamos);
        }

        // PUT api/prestamos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Prestamos prestamos)
        {
            PrestamosBLL.Modificar(prestamos);
        }

        // DELETE api/prestamos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PrestamosBLL.Eliminar(id);
        }
    }
}
