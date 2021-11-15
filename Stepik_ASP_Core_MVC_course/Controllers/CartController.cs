using Microsoft.AspNetCore.Mvc;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartsRepository;
        
        public CartController(IProductsRepository productRepository, ICartsRepository cartsRepository)
        {
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
        }
        
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);            
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetById(productId);
            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmount(int productId)
        {
            cartsRepository.DecreaseAmount(productId, Constants.UserId);
            return RedirectToAction("Index");
        }
        
        public IActionResult DelItem(int productId)
        {
            cartsRepository.DelItem(productId, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            cartsRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
