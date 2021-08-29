using System.Collections.Generic;

namespace cadastros.Series.interfaces
{
    public interface IRepositorios<T>
    {
        List<T> Lista();
        T retornaId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}