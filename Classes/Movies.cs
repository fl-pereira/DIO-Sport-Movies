// ### COMENTANDO O APRENDIZADO ###
// Mesmo tentando deixar o código em ENG, algumas expressões deixei em PT-BR, pois em inglês seriam palavras reservadas.
// Nesses casos mantive o PT-BR para não complicar o aprendizado
using System;

namespace DIO.SportsMovies
{
    public class Movies : BaseEntity
    {
        // Atributos
        private Genre Genre {get; set; }
        private string Title {get; set; }
        private string Description {get; set; }
        private int Year {get; set; }
        private bool Deleted {get; set; }

        // Metodos

        public Movies(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            // Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Genre: " + this.Genre + Environment.NewLine;
            retorno += "Title: " + this.Title + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Year: " + this.Year + Environment.NewLine;
            retorno += "Deleted: " + this.Deleted;

            return retorno;

        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnDeleted()
        {
            return this.Deleted;
        }

        public void Delete()
        {
            this.Deleted = true;
        }

    }
}