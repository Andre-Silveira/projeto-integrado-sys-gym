using ApplicationCore.Models;

namespace ApplicationCore;

public interface IAulaService
{
    List<Aula> BuscarAulas();
    void CadastrarAula(Aula aula);
}
