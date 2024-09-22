using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            // Read the JSON file from the App_Data folder
            var filePath = Server.MapPath("~/App_Data/products.json");
            var jsonData = System.IO.File.ReadAllText(filePath);

            // Deserialize the JSON data into a list of Product objects
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonData);

            // Pass the list of products to the view
            return View(products);
        }
        public ActionResult Details(string id)
        {
            ViewBag.ProductName = id; // Placeholder for product data
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }


    }
}