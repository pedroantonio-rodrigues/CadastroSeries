using System;
using System.Collections.Generic;
using cadastros.Series.interfaces; 

namespace cadastros.Series.classes
{

    public class SeriesRepositorios : IRepositorios<Series>
    {
        private List<Series> listaSerie = new List<Series>();
        public void Atualiza(int id, Series Objeto)
        {
            listaSerie[id] = Objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Series Objeto)
        {
            listaSerie.Add(Objeto);
        }

        public List<Series> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }
        public Series retornaId(int id)
        {
            return listaSerie[id];
        }

    }
}