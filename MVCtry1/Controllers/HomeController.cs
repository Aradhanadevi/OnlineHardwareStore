using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCtry1.Models;
using Newtonsoft.Json;

namespace MVCtry1.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Products()
        {
            var filePath = Server.MapPath("~/App_Data/products.json");
            var jsonData = System.IO.File.ReadAllText(filePath);
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
            return View(products);
        }
        public ActionResult Details(string id)
        {
            var jsonData = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/products.json"));
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonData);

            var product = products.FirstOrDefault(p => p.Name == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
        public ActionResult Cart()
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
            return View(cart);
        }
        public ActionResult AddToCart(string productName)
        {
            var jsonData = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/products.json"));
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
            var product = products.FirstOrDefault(p => p.Name == productName);

            if (product != null)
            {
                var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
                var cartItem = cart.FirstOrDefault(ci => ci.Name == product.Name);
                if (cartItem != null)
                {
                    cartItem.Quantity++; 
                }
                else
                {
                    cart.Add(new CartItem
                    {
                        Name = product.Name,
                        Price = product.Price,
                        ImageUrl = product.ImageUrl,
                        Quantity = 1
                    });
                }

                Session["Cart"] = cart;
            }

            return RedirectToAction("Cart"); 
        }


    }
}