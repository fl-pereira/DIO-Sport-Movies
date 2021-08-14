    // ### COMENTANDO O APRENDIZADO ###
    // Esta classe cria um ID para todos que a herdarem, sendo uma classe abstrata
namespace DIO.SportsMovies
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
    }
}