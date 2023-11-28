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

    }
}