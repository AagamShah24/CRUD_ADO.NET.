using BusinessLayer.Entities;
using BusinessLayer.Services;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OopsConceptAspDotNetMvc.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductService _productService = new ProductService();

        public ActionResult search()
        {
            return View();
        }
        public JsonResult AutoCompleteSearch(string term)
        {
            var products = _productService.GetAllProducts()
                                          .Where(p => p.Name.ToLower().Contains(term.ToLower()))
                                          .Select(p => new { label = p.Name, value = p.Id })
                                          .ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        
        }

        [HttpPost]
        public ActionResult Search(string SearchTerm)
        {
            var products = _productService.GetAllProducts()
                                          .Where(p => p.Name.ToLower().Contains(SearchTerm.ToLower()))
                                          .ToList();
            if (products.Any())
            {
                return View("SearchResults", products);
            }
            // If no product is found, return to the index with an empty list or an appropriate message
            ViewBag.Message = "No products found";
            return View("SearchResults", new List<Product>());
        }

        public ActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }
        public ActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public ActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public ActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}

