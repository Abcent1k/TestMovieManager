using System;
using System.Linq;
using Xunit;

namespace UnitTest56
{
    public class MovieManagerTests
    {
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
            Assert.True(movie.Favoriete);
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
            Assert.False(movie.Favoriete);
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
    }
}