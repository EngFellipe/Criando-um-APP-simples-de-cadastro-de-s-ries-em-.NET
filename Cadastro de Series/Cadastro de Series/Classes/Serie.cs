using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        //Atributos
        private Dio.Series.Genero Genero { get; set; }
        private String Titulo { get; set; }
        private String Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido { get; set; }

        //Métodos

        public Serie(Dio.Series.Genero genero, string titulo, String descricao, int ano)
        {
            //this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicío: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }
    }
        
}
