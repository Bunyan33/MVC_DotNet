using MVC_DotNet.DAL;
using MVC_DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace MVC_DotNet.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL productDAL = new ProductDAL();

        // GET: Product
        public ActionResult Index()
        {
            var products = productDAL.GetAllProducts();
            if(products.Count== 0)
            {
                TempData["InfoMessage"] = "Currently Product not Available in Database";
            }
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    bool response = productDAL.InsertProduct(product);

                    if (response)
                    {
                        TempData["SuccessMessage"] = "product created succesfully.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "product not created succesfully.";
                    }

                    return RedirectToAction("Index");

                }
                return View();
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
