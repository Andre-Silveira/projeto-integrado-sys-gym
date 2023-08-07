using ApplicationCore.Models;

namespace ApplicationCore;

public interface IAulaRepositorio
{
    List<Aula> BuscarAulas();
    void CadastrarAula(Aula aula);
}
