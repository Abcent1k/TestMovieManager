namespace TestMovieManager
{
	public class UnitTest1
	{
		//AddNewGenre

		[Fact]
		public void AddNewGenre_CorrectString_GenreAdded()
		{
			//arrange
			string genre = "Horror";
			var sut = new MovieManager();
			//act
			sut.AddNewGenre(genre);
			//assert
			Assert.Contains<string>(genre, sut.Genres);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void AddNewGenre_InvalidArgument_ThrowArgumentExeption(string genre)
		{
			var sut = new MovieManager();
			//act and assert
			Assert.Throws<ArgumentException>(() => sut.AddNewGenre(genre));
		}

		[Fact]
		public void AddNewGenre_TwoSimilarString_ThrowInvalidOperationException()
		{
			//arrange
			string genre = "Horror";
			var sut = new MovieManager();
			//act
			sut.AddNewGenre(genre);
			//act and assert
			Assert.Throws<InvalidOperationException>(() => sut.AddNewGenre(genre));
		}

		//RemoveGenre

		[Fact]
		public void RemoveGenre_CorrectString_GenreRemoved()
		{
			//arrange
			string genre = "Horror";
			var sut = new MovieManager();
			sut.AddNewGenre(genre);
			//act
			sut.RemoveGenre(genre);
			//assert
			Assert.DoesNotContain<string>(genre, sut.Genres);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void RemoveGenre_InvalidArgument_ThrowArgumentExeption(string genre)
		{
			var sut = new MovieManager();
			//act and assert
			Assert.Throws<ArgumentException>(() => sut.RemoveGenre(genre));
		}

		[Fact]
		public void RemoveGenre_NonExistentGenreAndEmptyList_ThrowInvalidOperationException()
		{
			//arrange
			string genre = "Horror";
			var sut = new MovieManager();
			//act and assert
			Assert.Throws<InvalidOperationException>(() => sut.RemoveGenre(genre));
		}

		[Fact]
		public void RemoveGenre_NonExistentGenreAndFilledList_ThrowInvalidOperationException()
		{
			//arrange
			string[] genres = { "Anime", "Thriller", "Comedy" };
			string genre_horror = "Horror";
			var sut = new MovieManager();
			foreach (var genre in genres)
			{
				sut.AddNewGenre(genre);
			}
			//act and assert
			Assert.Throws<InvalidOperationException>(() => sut.RemoveGenre(genre_horror));
		}

		// AddMovie

		[Fact]
		public void AddMovie_CorrectParameters_MovieAdded()
		{
			// arrange
			string title = "The Shawshank Redemption";
			string director = "Frank Darabont";
			string genre = "Drama";

			var sut = new MovieManager();

			// act
			sut.AddMovie(title, genre, director);

			// assert
			Assert.Contains(sut.Movies, movie =>
				movie.Title == title &&
				movie.Genre == genre &&
				movie.Director == director);
		}

		[Theory]
		[InlineData(null, "Director", "Genre")]
		[InlineData("Title", null, "Genre")]
		[InlineData("Title", "Director", null)]
		public void AddMovie_InvalidArgument_ThrowArgumentException(string title, string director, string genre)
		{
			var sut = new MovieManager();

			// act and assert
			Assert.Throws<ArgumentException>(() => sut.AddMovie(title, director, genre));
		}

		[Fact]
		public void AddMovie_DuplicateMovie_ThrowInvalidOperationException()
		{
			// arrange
			string title = "The Shawshank Redemption";
			string director = "Frank Darabont";
			string genre = "Drama";

			var sut = new MovieManager();

			// act
			sut.AddMovie(title, genre, director);

			// act and assert
			Assert.Throws<InvalidOperationException>(() => sut.AddMovie(title, genre, director));
		}

		// RemoveMovie

		[Fact]
		public void RemoveMovie_ExistingMovie_MovieRemoved()
		{
			// arrange
			string title = "The Shawshank Redemption";
			string director = "Frank Darabont";
			string genre = "Drama";

			var sut = new MovieManager();
			sut.AddMovie(title, director, genre);

			// act
			sut.RemoveMovie(title);

			// assert
			Assert.DoesNotContain<Movie>(new Movie(title, director, genre), sut.Movies);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void RemoveMovie_InvalidArgument_ThrowArgumentException(string title)
		{
			var sut = new MovieManager();

			// act and assert
			Assert.Throws<ArgumentException>(() => sut.RemoveMovie(title));
		}

		[Fact]
		public void RemoveMovie_NonExistentMovie_ThrowInvalidOperationException()
		{
			// arrange
			string title = "The Shawshank Redemption";
			var sut = new MovieManager();

			// act and assert
			Assert.Throws<InvalidOperationException>(() => sut.RemoveMovie(title));
		}

		[Fact]
		public void RemoveMovie_NonExistentMovieInFilledList_ThrowInvalidOperationException()
		{
			// arrange
			string[] titles = { "The Shawshank Redemption", "The Godfather", "Pulp Fiction" };
			string titleToRemove = "Inception";
			var sut = new MovieManager();

			foreach (var title in titles)
			{
				sut.AddMovie(title, "Director", "Genre");
			}

			// act and assert
			Assert.Throws<InvalidOperationException>(() => sut.RemoveMovie(titleToRemove));
		}

		[Fact]
		public void AddMovieToFavorites_ShouldSetFavorieteToTrue()
		{
			// Arrange
			var movieManager = new MovieManager();
			var movieTitle = "Inception";
			movieManager.Movies.Add(new Movie(movieTitle, "Sci-Fi", "Christopher Nolan", false));

			// Act
			movieManager.AddMovieToFavorites(movieTitle);

			// Assert
			var movie = movieManager.Movies.FirstOrDefault(m => m.Title == movieTitle);
			Assert.NotNull(movie);
			Assert.True(movie.Favourite);
		}

		[Fact]
		public void RemoveMovieFromFavorites_ShouldSetFavorieteToFalse()
		{
			// Arrange
			var movieManager = new MovieManager();
			var movieTitle = "The Shawshank Redemption";
			movieManager.Movies.Add(new Movie(movieTitle, "Drama", "Frank Darabont", true));

			// Act
			movieManager.RemoveMovieFromFavorites(movieTitle);

			// Assert
			var movie = movieManager.Movies.FirstOrDefault(m => m.Title == movieTitle);
			Assert.NotNull(movie);
			Assert.False(movie.Favourite);
		}

		[Fact]
		public void AddMovieToFavorites_ShouldThrowExceptionIfMovieNotFound()
		{
			// Arrange
			var movieManager = new MovieManager();
			var nonExistingMovieTitle = "Non-Existing Movie";

			// Act and Assert
			Assert.Throws<InvalidOperationException>(() => movieManager.AddMovieToFavorites(nonExistingMovieTitle));
		}

		[Fact]
		public void RemoveMovieFromFavorites_ShouldThrowExceptionIfMovieNotFound()
		{
			// Arrange
			var movieManager = new MovieManager();
			var nonExistingMovieTitle = "Non-Existing Movie";

			// Act and Assert
			Assert.Throws<InvalidOperationException>(() => movieManager.RemoveMovieFromFavorites(nonExistingMovieTitle));
		}

		[Fact]
		public void GetMoviesByGenre_ShouldSortByTitleAlphabetically()
		{

			// Arrange
			var genre = "Action";
			var sortingStrategy = new SortByTitleAlphabetically();
			var MovieManager = new MovieManager();

			MovieManager.Genres.Add(genre);

			List<Movie> testList = new List<Movie>{ new Movie("B", genre, "Director3"),
			new Movie("D", genre, "Director2"),
			new Movie("A", genre, "Director1"),
			new Movie("C","Drama", "Director4")//
        };

			MovieManager.Movies.AddRange(testList);
			List<Movie> expectedList = testList.Where(m => m.Genre == genre).OrderBy(m => m.Title).ToList();

			// Act
			var result = MovieManager.GetMoviesByGenre(genre, sortingStrategy);

			// Assert
			Assert.Equal(expectedList, result);

		}

		[Fact]
		public void GetMoviesByGenre_ShouldSortByTitleDescending()
		{
			// Arrange
			var genre = "Action";
			var sortingStrategy = new SortByTitleDescending();
			var MovieManager = new MovieManager();

			MovieManager.Genres.Add(genre);

			List<Movie> testList = new List<Movie>{ new Movie("B", genre, "Director3"),
			new Movie("D", genre, "Director2"),
			new Movie("A", genre, "Director1"),
			new Movie("C","Drama", "Director4")//
        };

			MovieManager.Movies.AddRange(testList);
			List<Movie> expectedList = testList.Where(m => m.Genre == genre).OrderByDescending(m => m.Title).ToList();

			// Act
			var result = MovieManager.GetMoviesByGenre(genre, sortingStrategy);

			// Assert
			Assert.Equal(expectedList, result);
		}

		[Fact]
		public void GetMoviesByGenre_ShouldSortByDirectorAlphabetically()
		{
			// Arrange
			var genre = "Action";
			var sortingStrategy = new SortByDirectorAlphabetically();
			var MovieManager = new MovieManager();

			MovieManager.Genres.Add(genre);

			List<Movie> testList = new List<Movie>{ new Movie("B", genre, "Director3"),
			new Movie("D", genre, "Director2"),
			new Movie("A", genre, "Director1"),
			new Movie("C","Drama", "Director4")//
        };

			MovieManager.Movies.AddRange(testList);
			List<Movie> expectedList = testList.Where(m => m.Genre == genre).OrderBy(m => m.Director).ToList();

			// Act
			var result = MovieManager.GetMoviesByGenre(genre, sortingStrategy);

			// Assert
			Assert.Equal(expectedList, result);
		}

		[Fact]
		public void GetMoviesByGenre_ShouldSortByDirectorDescending()
		{
			// Arrange
			var genre = "Action";
			var sortingStrategy = new SortByDirectorDescending();
			var MovieManager = new MovieManager();

			MovieManager.Genres.Add(genre);

			List<Movie> testList = new List<Movie>{ new Movie("B", genre, "Director3"),
			new Movie("D", genre, "Director2"),
			new Movie("A", genre, "Director1"),
			new Movie("C","Drama", "Director4")//
        };

			MovieManager.Movies.AddRange(testList);
			List<Movie> expectedList = testList.Where(m => m.Genre == genre).OrderByDescending(m => m.Director).ToList();

			// Act
			var result = MovieManager.GetMoviesByGenre(genre, sortingStrategy);

			// Assert
			Assert.Equal(expectedList, result);


		}

		[Fact]
		public void SortByTitleAlphabetically_ShouldSortMoviesByTitleInAscendingOrder()
		{
			// Arrange
			var sortingStrategy = new SortByTitleAlphabetically();
			var movies = new List<Movie>
			{
				new Movie("The Shawshank Redemption", "Drama", "Frank Darabont"),
				new Movie("Inception", "Sci-Fi", "Christopher Nolan"),
				new Movie("The Dark Knight", "Action", "Christopher Nolan")
			};

			// Act
			var result = sortingStrategy.Sort(movies);

			// Assert
			Assert.NotNull(result);
			Assert.Equal("Inception", result[0].Title);
			Assert.Equal("The Dark Knight", result[1].Title);
			Assert.Equal("The Shawshank Redemption", result[2].Title);
		}

		[Fact]
		public void SortByTitleDescending_ShouldSortMoviesByTitleInDescendingOrder()
		{
			// Arrange
			var sortingStrategy = new SortByTitleDescending();
			var movies = new List<Movie>
			{
				new Movie("The Shawshank Redemption", "Drama", "Frank Darabont"),
				new Movie("Inception", "Sci-Fi", "Christopher Nolan"),
				new Movie("The Dark Knight", "Action", "Christopher Nolan")
			};

			// Act
			var result = sortingStrategy.Sort(movies);

			// Assert
			Assert.NotNull(result);
			Assert.Equal("The Shawshank Redemption", result[0].Title);
			Assert.Equal("The Dark Knight", result[1].Title);
			Assert.Equal("Inception", result[2].Title);
		}

		[Fact]
		public void SortByDirectorAlphabetically_ShouldSortMoviesByDirectorInAscendingOrder()
		{
			// Arrange
			var sortingStrategy = new SortByDirectorAlphabetically();
			var movies = new List<Movie>
			{
				new Movie("The Shawshank Redemption", "Drama", "Frank Darabont"),
				new Movie("Inception", "Sci-Fi", "Christopher Nolan",false),
				new Movie("The Dark Knight", "Action", "Christopher Nolan")
			};

			// Act
			var result = sortingStrategy.Sort(movies);

			// Assert
			Assert.NotNull(result);
			Assert.Equal("Christopher Nolan", result[0].Director);
			Assert.Equal("Frank Darabont", result[2].Director);
		}

		[Fact]
		public void SortByDirectorDescending_ShouldSortMoviesByDirectorInDescendingOrder()
		{
			// Arrange
			var sortingStrategy = new SortByDirectorDescending();
			var movies = new List<Movie>
			{
				new Movie("The Shawshank Redemption", "Drama", "Frank Darabont"),
				new Movie("Inception", "Sci-Fi", "Christopher Nolan",false),
				new Movie("The Dark Knight", "Action", "Christopher Nolan")
			};

			// Act
			var result = sortingStrategy.Sort(movies);

			// Assert
			Assert.NotNull(result);
			Assert.Equal("Frank Darabont", result[0].Director);
			Assert.Equal("Christopher Nolan", result[2].Director);
		}
		[Fact]
		public void GetFavouriteMovies_NoMoviesAreFavourite_ShouldReturnEmptyList()
		{
			// Arrange
			var movieManager = new MovieManager();
			var sortingStrategy = new SortByTitleAlphabetically();

			var moviesToAdd = new List<Movie>
			{
				new Movie("Inception", "Sci-Fi", "Christopher Nolan", false),
				new Movie("The Dark Knight", "Action", "Christopher Nolan", false),
				new Movie("The Shawshank Redemption", "Drama", "Frank Darabont", false)
			};

			movieManager.Movies.AddRange(moviesToAdd);

			// Act
			var result = movieManager.GetFavouriteMovies(sortingStrategy);

			// Assert
			Assert.NotNull(result);
			Assert.Empty(result);
		}
	}
}