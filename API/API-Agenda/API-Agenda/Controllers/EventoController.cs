using API_Agenda.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Agenda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private EventoService _service;

        public EventoController(EventoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _service.listarTodos();
        }

        [HttpPost]
        public Evento Post([FromBody] Evento eventos)
        {
            return _service.Incluir(eventos);
        }

    }
}