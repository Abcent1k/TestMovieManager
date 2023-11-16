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
		public bool Favoriete { get; set; }

		private Movie() { }

		public Movie(string title, string genre, string director, bool favoriete) : this()
		{
			Title = title;
			Genre = genre;
			Director = director;
			Favoriete = favoriete;
		}
		public Movie(string title, string genre, string director) : this()
		{
			Title = title;
			Genre = genre;
			Director = director;
			Favoriete = false;
		}
	}
}
