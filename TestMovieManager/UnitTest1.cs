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
	}
}