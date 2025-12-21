using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserRepository _repo;

        public UsersController(IConfiguration config)
        {
            _repo = new UserRepository(config);
        }

        public IActionResult Index()
        {
            var users = _repo.GetAllUsers();
            return View(users);
        }
    }
}
