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
}
