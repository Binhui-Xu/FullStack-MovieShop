using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface ICastService
    {
        Task<MovieDetailResponseModel.CastResponseModel> GetCastDetails(int id);
    }
}