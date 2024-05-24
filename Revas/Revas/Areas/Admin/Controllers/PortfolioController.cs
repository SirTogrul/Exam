using Microsoft.AspNetCore.Mvc;
using Revas.DAL;
using Revas.Models;

namespace Revas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        AppDbContext _context;
        public PortfolioController(AppDbContext context)
        {
            _context = context;  
        }
        public IActionResult Index()
        {
            List<Portfolio>portfolio=_context.portfolios.ToList();
            return View(portfolio);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Portfolio portfolio)
        {
            string path = "C:\\Users\\II novbe\\Desktop\\Revas\\Revas\\Revas\\wwwroot\\Upload\\Portfolio\\";
            string filename = portfolio.Photofile.FileName;
            using (FileStream stream=new FileStream(path + filename, FileMode.Create))
            {
               portfolio.Photofile.CopyTo(stream);
            }
            portfolio.ImgUrl = filename;
                if (portfolio == null)
                {
                    return View();
                }
            if(!ModelState.IsValid)
            {
                return View(portfolio);
            }
            _context.portfolios.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
          var portfolio= _context.portfolios.FirstOrDefault(x=>x.Id==id);
          _context.portfolios.Remove(portfolio);
          _context.SaveChanges();
            return RedirectToAction("index");  
        }
        public IActionResult Update(int? id)
        {
            if(ModelState.IsValid)
            {
                return View();
            }
            var portfolio = _context.portfolios.FirstOrDefault(x => x.Id == id);
            return RedirectToActionPermanent("Index");
        }
        [HttpPost]
        public IActionResult Update(Portfolio newPortfolio)
        {
            var oldPortfolio= _context.portfolios.FirstOrDefault(x=>x.Id == newPortfolio.Id);
            oldPortfolio.ImgUrl=newPortfolio.ImgUrl;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
