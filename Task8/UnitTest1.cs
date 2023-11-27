using System;
using System.Collections.Generic;
using System.Linq;
using MovieManage;
using Xunit;

public class MovieManagerTests
{
    [Fact]
    public void GetMoviesByGenre_ShouldSortByTitleAlphabetically()
    {
        // Arrange
        var genre = "Action";
        var sortingStrategy = new SortByTitleAlphabetically();
        var MovieManager = new MovieManager();

        MovieManager.Genres.Add(genre);

        MovieManager.Movies.AddRange(new List<Movie>{ new Movie("B", genre, "Director3"),
            new Movie("D", genre, "Director2"),
            new Movie("A", genre, "Director1"),
            new Movie("C","Drama", "Director4")}
          );

        
        // Act
        var result = MovieManager.GetMoviesByGenre(genre, sortingStrategy);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("A", result[0].Title);
        Assert.Equal("B", result[1].Title);
        Assert.Equal("D", result[2].Title);

    }

    [Fact]
    public void GetMoviesByGenre_ShouldSortByTitleDescending()
    {
        // Arrange
        var genre = "Action";
        var sortingStrategy = new SortByTitleDescending();
        var MovieManager = new MovieManager();

        MovieManager.Genres.Add(genre);

        MovieManager.Movies.AddRange(new List<Movie>{ new Movie("B", genre, "Director3"),
            new Movie("D", genre, "Director2"),
            new Movie("A", genre, "Director1"),
            new Movie("C","Drama", "Director4")}
          );


        // Act
        var result = MovieManager.GetMoviesByGenre(genre, sortingStrategy);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("D", result[0].Title);
        Assert.Equal("B", result[1].Title);
        Assert.Equal("A", result[2].Title);
    }

    [Fact]
    public void GetMoviesByGenre_ShouldSortByDirectorAlphabetically()
    {
        // Arrange
        var genre = "Action";
        var sortingStrategy = new SortByDirectorAlphabetically();
        var MovieManager = new MovieManager();

        MovieManager.Genres.Add(genre);

        MovieManager.Movies.AddRange(new List<Movie>{ new Movie("B", genre, "Director3"),
            new Movie("D", genre, "Director2"),
            new Movie("A", genre, "Director1"),
            new Movie("C","Drama", "Director4")}
          );


        // Act
        var result = MovieManager.GetMoviesByGenre(genre, sortingStrategy);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Director1", result[0].Director);
        Assert.Equal("Director2", result[1].Director);
        Assert.Equal("Director3", result[2].Director);
    }

    [Fact]
    public void GetMoviesByGenre_ShouldSortByDirectorDescending()
    {
        // Arrange
        var genre = "Action";
        var sortingStrategy = new SortByDirectorDescending();
        var MovieManager = new MovieManager();

        MovieManager.Genres.Add(genre);

        MovieManager.Movies.AddRange(new List<Movie>{ new Movie("B", genre, "Director3"),
            new Movie("D", genre, "Director2"),
            new Movie("A", genre, "Director1"),
            new Movie("C","Drama", "Director4")}
          );


        // Act
        var result = MovieManager.GetMoviesByGenre(genre, sortingStrategy);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Director3", result[0].Director);
        Assert.Equal("Director2", result[1].Director);
        Assert.Equal("Director1", result[2].Director);
    }
}
