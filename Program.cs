    // ### COMENTANDO O APRENDIZADO ###
    // Classe PRINCIPAL
    // Trying to translate to ENG without "googling". Sorry for mistakes.
    
using System;

namespace DIO.SportsMovies
{
    class Program
    {
        static SportMovies.Repositories.MovieRepository repository = new SportMovies.Repositories.MovieRepository();
        static void Main(string[] args)
        {
            string userOption = ObtainUserOption();
            // Enquanto as condições forem diferentes de "X", o programa realizará algumas tarefas, sendo que "X" fecha o console.
            while (userOption.ToUpper() != "x")
            {
                switch (userOption)
                {
                    case "1":
                        ListMovies();
                        break;
                    case "2":
                        InsertMovie();
                        break;
                    case "3":
                        UpdateMovie();
                        break;
                    case "4":
                       DeleteMovie();
                       break;
                    case "5":
                       WatchMovie();
                       break;
                    case "C":
                       Console.Clear();
                       break;

                    default:
                        throw new ArgumentOutOfRangeException();          
                    
                }

                userOption = ObtainUserOption();
            }
            Console.WriteLine("Thanks for the support. We appreciate.");
            Console.ReadLine();
        }
        
        // Aqui recuperamos a lista de filmes cadastrados com a condição de retornar um texto caso não tenha nenhum.
        private static void ListMovies()
        {
            Console.WriteLine("List movies");
            var list = repository.List();

            if (list.Count == 0){
                Console.WriteLine("None movie available.");
                return;
            }
        // O foreach() faz uma varredura de filmes inseridos e retorna para para nós. Neste caso adicionamos o atributo 'deleted' para que saibamos qual foi excluído
        // Remover/reaproveitar o ID do registro não é uma boa prática para banco de dados
            foreach (var movie in list)
            {
                var deleted = movie.returnDeleted(); 
                Console.WriteLine("#ID {0}: - {1} {2}", movie.returnId(), movie.returnTitle(), (deleted ? "Deleted" : ""));
            }
        }
        
        private static void InsertMovie()
        {
            Console.WriteLine("Insert new movie...");
            // Essa ainda é uma das partes que ainda estou tentando compreender melhor, sobre o uso da variável "i". Vou pesquisar mais sobre Enum.
            foreach (int i in Enum.GetValues(typeof(Genre))){
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            
            Console.WriteLine("Select GENRE: ");
            int enterGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("What´s the movie titile: ");
            string enterTitle = Console.ReadLine();

            Console.WriteLine("What's the movie's year: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Describe the movie: ");
            string enterDescription = Console.ReadLine();

            SportsMovies.Movies newMovie = new SportsMovies.Movies(id: repository.NextId(),
                                        genre: (Genre)enterGenre,
                                        title: enterTitle,
                                        year: enterYear,
                                        description: enterDescription);
            
            repository.Insert(newMovie);

        }

        private static void UpdateMovie(){
            Console.WriteLine("Insert movie ID: ");
            int indMovie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre))){
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.WriteLine("Select GENRE: ");
            int enterGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter movie title: ");
            string enterTitle = Console.ReadLine();

            Console.WriteLine("Enter movie year of release: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter movie description: ");
            string enterDescription = Console.ReadLine();

            SportsMovies.Movies updateMovies = new SportsMovies.Movies(id: indMovie,
                                                    genre: (Genre)enterGenre,
                                                    title: enterTitle,
                                                    year: enterYear,
                                                    description: enterDescription);

            repository.Update(indMovie, updateMovies);

        }
        // Um dos trechos que estou entendendo bem, devido as práticas. Sei que é simples, mas um bom começo
        private static void DeleteMovie(){
            Console.WriteLine("Insert movie ID: ");
            int indMovie = int.Parse(Console.ReadLine());

            repository.Delete(indMovie);
        }

        private static void WatchMovie(){
            Console.WriteLine("Watch movie ID: ");
            int indMovie = int.Parse(Console.ReadLine());

            var movie = repository.ReturnByID(indMovie);
            Console.WriteLine(movie);
        }

        private static string ObtainUserOption()
        {
            Console.WriteLine("DevFlix Sports Movies - Keep Shredding!");
            Console.WriteLine("Choose your option:");

            Console.WriteLine("1 - LIST MOVIES");
            Console.WriteLine("2 - INSERT NEW MOVIES");
            Console.WriteLine("3 - UPDATE EXISTING MOVIE");
            Console.WriteLine("4 - DELETE MOVIE");
            Console.WriteLine("5 - WATCH MOVIE");
            Console.WriteLine("C - SCREEN CLEANER");
            Console.WriteLine("X - EXIT");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
