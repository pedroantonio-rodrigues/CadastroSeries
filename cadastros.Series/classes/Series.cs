using System;

namespace cadastros.Series
{
    public class Series : entidadeBase
    {
       private genero Genero { get; set; }
       private string Titulo { get; set; }
       private string Descricao { get; set; }
       private int Ano { get; set; }

       private bool Excluido { get; set; }
        public int Id { get; private set; }

        public Series(int id, genero genero, string titulo, string descricao, int ano)
        {
            this.id = id;
           this.Genero = genero;
           this.Titulo = titulo;
           this.Descricao = descricao;
           this.Ano =  ano;
           this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de inicio: " + this.Ano;


            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;            
        }
        public void Excluir(){
            this.Excluido = true;
        }

        internal object retornaExcluido()
        {
            throw new NotImplementedException();
        }
    }
}