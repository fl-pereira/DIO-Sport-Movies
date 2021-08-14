// ### COMENTANDO O APRENDIZADO ###
// Este é um repositório para os filmes cadastrados e utilizamos a interface IRepository para complementar
using System.Collections.Generic;
using DIO.SportMovies.Interfaces;

namespace DIO.SportMovies.Repositories
{
    public class MovieRepository : IRepository<SportsMovies.Movies>
    {
        private List<SportsMovies.Movies> listMovies = new List<SportsMovies.Movies>(); 
        public void Delete(int id)
        {
            listMovies[id].Delete();
        }

        public void Insert(SportsMovies.Movies entidade)
        {
            listMovies.Add(entidade);
        }

        public List<SportsMovies.Movies> List()
        {
            return listMovies;
        }

        public int NextId()
        {
            return listMovies.Count;
        }

        public SportsMovies.Movies ReturnByID(int id)
        {
            return listMovies[id];
        }

        public void Update(int id, SportsMovies.Movies entidade)
        {
            listMovies[id] = entidade;
        }
    }
}