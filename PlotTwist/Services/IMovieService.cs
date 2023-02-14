﻿using Models;

namespace Services
{
    // necessary for dependency injection
    public interface IMovieService
    {
        public IEnumerable<Movie> GetMovies();
    }
}
