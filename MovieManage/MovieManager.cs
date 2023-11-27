using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManage
{
	public class MovieManager
	{
		protected List<Movie> _movies;
		protected List<string> _genres;

		public List<Movie> Movies { get { return _movies; } protected set { _movies = value; } }
		public List<string> Genres { get { return _genres; } protected set { _genres = value; } }

		public MovieManager()
		{
			_movies = new List<Movie>();
			_genres = new List<string>();
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
		public List<Movie> GetFavouriteMovies(IMovieSortingStrategy sortingStrategy)
		{
			var filteredMovies = _movies.Where(m => m.Favourite == true).ToList();
			return sortingStrategy.Sort(filteredMovies);
		}
	}
}
