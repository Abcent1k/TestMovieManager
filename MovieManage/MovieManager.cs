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
			if (genre == null || genre.Length == 0)
				throw new ArgumentException(genre);
			if (Genres.Contains(genre))
				throw new InvalidOperationException("That genre already exists!");

			Genres.Add(genre);
		}

		public void RemoveGenre(string genre)
		{
			if (genre == null || genre.Length == 0)
				throw new ArgumentException(genre);
			 if (!Genres.Remove(genre))
				throw new InvalidOperationException("There is no such genre!");
		}
	}
}
