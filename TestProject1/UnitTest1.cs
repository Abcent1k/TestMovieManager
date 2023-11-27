using MovieManage;

namespace TestProject1
{
    public class UnitTest1
    {
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
    }
}