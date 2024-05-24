using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revas.DAL;
using Revas.Models;
using System.Diagnostics;

namespace Revas.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Portfolio> portfolios = _context.portfolios.ToList(); 
            return View(portfolios);
        }  
    }
}
