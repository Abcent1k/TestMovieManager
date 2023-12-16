using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManage
{
	public class Movie
    {
		public string Title { get; }
		public string Genre { get; }
		public string Director { get; }
		public bool Favourite { get; set; }

		private Movie() { }

		public Movie(string title, string genre, string director, bool favourite) : this()
		{
			Title = title;
			Genre = genre;
			Director = director;
			Favourite = favourite;
		}
		public Movie(string title, string genre, string director) : this()
		{
			Title = title;
			Genre = genre;
			Director = director;
			Favourite = false;
		}
	}
}
