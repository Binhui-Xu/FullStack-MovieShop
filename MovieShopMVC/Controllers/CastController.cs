using System.Threading.Tasks;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {
        // GET
        private ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }
        public async Task<IActionResult> Details(int id)
        {
            var cast =await _castService.GetCastDetails(id);
            return View(cast);
        }
    }
}