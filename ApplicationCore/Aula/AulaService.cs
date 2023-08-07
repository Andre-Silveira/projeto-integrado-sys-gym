using ApplicationCore.Models;

namespace ApplicationCore;

public class AulaService : IAulaService
{
    private readonly IAulaRepositorio _aulaRepositorio;

    public AulaService(IAulaRepositorio aulaRepositorio)
    {
        _aulaRepositorio = aulaRepositorio;
    }

    public List<Aula> BuscarAulas()
    {
        return _aulaRepositorio.BuscarAulas();
    }

    public void CadastrarAula(Aula aula)
    {
        _aulaRepositorio.CadastrarAula(aula);
    }

}
