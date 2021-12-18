using Microsoft.AspNetCore.Mvc;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productRepository;
        

        public HomeController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;            
        }

        public IActionResult Index()
        {            
            var products = productRepository.GetAll();                        
            return View(products);
        }      
    }
}
