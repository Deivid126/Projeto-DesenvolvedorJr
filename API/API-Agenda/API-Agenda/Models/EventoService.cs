namespace API_Agenda.Models
{
    public class EventoService
    {
        private EntityDB _context;

        public EventoService(EntityDB context)
        {
            _context = context;
        }

        public IEnumerable<Evento> listarTodos()
        {
            return _context.Eventos.ToList();
        }

        public  Evento Incluir(Evento dadosEvento)
        {
            _context.Eventos.Add(dadosEvento);
            _context.SaveChanges();
            return dadosEvento;
        }
    }
}
