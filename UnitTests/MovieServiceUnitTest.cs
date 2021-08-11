using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterface;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq; //to set up mock objects and mock classes

namespace UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        private MovieService _sut; //injection
        private static List<Movie> _movies;
        private Mock<IMovieRepository> _mockMovieRepository;
        
        [TestInitialize]
        //[OnetimeSetUp] in nUnit
        public void OneTimeSetUp()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            //whenever who call GetHighest30GrossingMovies(), please return _movies object
            
            //SUT [System under Test]  MovieService => GetTopRevenueMovies
            _sut = new MovieService(_mockMovieRepository.Object);
            _mockMovieRepository.Setup(m => m.GetHighest30GrossingMovies()).ReturnsAsync(_movies);
        }

        [ClassInitialize]
        public static void SetUp(TestContext context) 
        {
            _movies = new List<Movie>
            {
                new Movie{Id = 1,Title = "Avengers: Infinity War",Budget = 12000000},
                new Movie{Id = 2,Title = "Avatar",Budget = 12000000},
                new Movie{Id = 3,Title = "Titanic",Budget = 12000000},
            };
            
        }

        [TestMethod]
        public async void TestListOfHighestGrossingMoviesFakeData()//test method name should description
        {
            
            //every unit test follow AAA [Arrange, Act, Assert]
            
            //Arrange - Initializes objects, creates mocks with arguments that passed to the mothod under test and adds exceptions
            // _sut = new MovieService(new MockMovieRepository());
            
            
            //Act - invokes the method or property under test with the arranged parameters
            var movies =await _sut.GetTopRevenueMovies();
            
            //check the actual output with expected data
            //Assert - verifies that the action of the method under test behavior as expected
            Assert.IsNotNull(movies);
            Assert.IsInstanceOfType(movies,typeof(IEnumerable<MovieCardResponseModel>));
            Assert.AreEqual(16,_movies.Count);
        }
    }

    // public class MockMovieRepository : IMovieRepository
    // {
    //     public async Task<Movie> GetByIdAsync(int id)
    //     {
    //         throw new NotImplementedException();
    //     }
    //
    //     public async Task<IEnumerable<Movie>> ListAllAsync()
    //     {
    //         throw new NotImplementedException();
    //     }
    //
    //     public async Task<IEnumerable<Movie>> ListAsync(Expression<Func<Movie, bool>> filter)
    //     {
    //         throw new NotImplementedException();
    //     }
    //
    //     public async Task<Movie> AddAsync(Movie entity)
    //     {
    //         throw new NotImplementedException();
    //     }
    //
    //     public async Task<Movie> UpdateAsync(Movie entity)
    //     {
    //         throw new NotImplementedException();
    //     }
    //
    //     public async Task<Movie> DeleteAsync(Movie entity)
    //     {
    //         throw new NotImplementedException();
    //     }
    //
    //     public async Task<int> GetCountAsync(Expression<Func<Movie, bool>> filter = null)
    //     {
    //         throw new NotImplementedException();
    //     }
    //
    //     public async Task<bool> GetExistsAsync(Expression<Func<Movie, bool>> filter = null)
    //     {
    //         throw new NotImplementedException();
    //     }
    //
    //     public async Task<List<Movie>> GetHighest30GrossingMovies()
    //     {
    //         var _movies = new List<Movie>
    //         {
    //             new Movie{Id = 1,Title = "Avengers: Infinity War",Budget = 12000000},
    //             new Movie{Id = 2,Title = "Avatar",Budget = 12000000},
    //             new Movie{Id = 3,Title = "Titanic",Budget = 12000000},
    //         };
    //         return _movies;
    //     }
    //
    //     public async Task<List<Movie>> GetHighest30RatedMovies()
    //     {
    //         throw new NotImplementedException();
    //     }
    // }
}