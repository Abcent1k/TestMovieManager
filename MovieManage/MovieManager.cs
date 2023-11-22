using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManage
{
	public class MovieManager
	{
		public List<Movie> Movies { get; }

		public List<string> Genres { get; }

		public MovieManager()
		{
			Movies = new List<Movie>();
			Genres = new List<string>();
		}

		public void AddNewGenre(string genre)
		{
			if (string.IsNullOrEmpty(genre))
				throw new ArgumentException(genre);
			if (Genres.Contains(genre))
				throw new InvalidOperationException("That genre already exists!");

			Genres.Add(genre);
		}

		public void RemoveGenre(string genre)
		{
			if (string.IsNullOrEmpty(genre))
				throw new ArgumentException(genre);
			 if (!Genres.Remove(genre))
				throw new InvalidOperationException("There is no such genre!");
		}
		public List<Movie> GetMoviesByGenre(string genre, IMovieSortingStrategy sortingStrategy)
		{
			var filteredMovies = Movies.Where(m => m.Genre == genre).ToList();
			return sortingStrategy.Sort(filteredMovies);
		}
		public List<Movie> GetFavorieteMovies(IMovieSortingStrategy sortingStrategy)
		{
			var filteredMovies = Movies.Where(m => m.Favoriete == true).ToList();
			return sortingStrategy.Sort(filteredMovies);
		}
	}
}
