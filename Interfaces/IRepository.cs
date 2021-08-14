// ### COMENTANDO O APRENDIZADO ###
// Uma interface para trazer alguns métodos ao nosso programa
using System.Collections.Generic;

namespace DIO.SportMovies.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReturnByID(int id);
        void Insert(T entidade);
        void Delete(int id);
        void Update(int id, T entidade);
        int NextId();
    }
}