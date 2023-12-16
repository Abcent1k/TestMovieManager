using MovieManage;

var movieManager = new MovieManager();

movieManager.AddNewGenre("Comedy");
movieManager.AddNewGenre("Horror");

movieManager.AddMovie("Creep", "Horror", "Patrick Brice");
movieManager.AddMovie("The Fly", "Horror", "David Cronenberg");
movieManager.AddMovie("The Idiots", "Comedy", "Lars von Trier");
movieManager.AddMovie("The Great Dictator", "Comedy", "Charlie Chaplin");

movieManager.AddMovieToFavorites("The Fly");
movieManager.AddMovieToFavorites("The Idiots");


Console.WriteLine("List of favourite movies:");
foreach (var movie in movieManager.GetFavouriteMovies(new SortByTitleAlphabetically()))
{
	Console.WriteLine($"Title - {movie.Title} | Genre - {movie.Genre} | Directory - {movie.Director}");
}

Console.WriteLine("List of Comedy movies:");
foreach (var movie in movieManager.GetMoviesByGenre("Comedy", new SortByDirectorDescending()))
{
	Console.WriteLine($"Title - {movie.Title} | Genre - {movie.Genre} | Directory - {movie.Director}");
}