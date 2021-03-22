using SportStore.Domain.Entities;
using SportStore.Domain.Repository;
using SportStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcessor orderRepo;

        public CartController(IProductRepository repo, IOrderProcessor order)
        {
            repository = repo;
            orderRepo = order;
        }


        public ViewResult Index(Cart cart, string returnURL)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                returnUrl = returnURL

            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShoppingDetail());
        }


        [HttpPost]
        public ViewResult Checkout(Cart cart, ShoppingDetail detail)
        {
            if (cart.cartLine.Count() == 0)
            {
                ModelState.AddModelError("", "카드가 비었습니다.");
            }
            if (ModelState.IsValid)
            {
                orderRepo.ProcessOrder(cart, detail);
                cart.Clear();
                return View("Completed");

            }
            else
            {
                return View(detail);
            }

        }



    }
}