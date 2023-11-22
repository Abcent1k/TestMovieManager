using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManage
{
	public interface IMovieSortingStrategy
	{
		List<Movie> Sort(List<Movie> movies);
	}
	public class SortByTitleAlphabetically : IMovieSortingStrategy
	{
		public List<Movie> Sort(List<Movie> movies)
		{
			return movies.OrderBy(m => m.Title).ToList();
		}
	}
	public class SortByTitleDescending : IMovieSortingStrategy
	{
		public List<Movie> Sort(List<Movie> movies)
		{
			return movies.OrderByDescending(m => m.Title).ToList();
		}
	}
	public class SortByDirectorAlphabetically : IMovieSortingStrategy
	{
		public List<Movie> Sort(List<Movie> movies)
		{
			return movies.OrderBy(m => m.Director).ToList();
		}
	}
	public class SortByDirectorDescending : IMovieSortingStrategy
	{
		public List<Movie> Sort(List<Movie> movies)
		{
			return movies.OrderByDescending(m => m.Director).ToList();
		}
	}

}
