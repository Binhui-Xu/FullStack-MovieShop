using System;
using System.Collections.Generic;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface IMovieService
    {
        List<MovieCardResponseModel> GetTopRevenueMovies();
    }
}
