﻿using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductController : Controller
    {
        private ProductHelper productHelper;
        private CategoryHelper categoryHelper;
        private SupplierHelper supplierHelper;

        public ProductController()
        {
            productHelper = new ProductHelper();
            categoryHelper = new CategoryHelper();
            supplierHelper = new SupplierHelper();
        }


        // GET: ProductController
        public ActionResult Index()
        {
            List<ProductViewModel> products = productHelper.GetAll();

            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            ProductViewModel product = productHelper.Get(id);

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ProductViewModel product = new ProductViewModel();

            product.Suppliers = supplierHelper.GetAll();
            product.Categories = categoryHelper.GetAll();

            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            try
            {
                productHelper.Create(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductViewModel product = productHelper.Get(id);

            product.Suppliers = supplierHelper.GetAll();
            product.Categories = categoryHelper.GetAll();

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            try
            {
                productHelper.Update(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductViewModel product = productHelper.Get(id);

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductViewModel product)
        {
            try
            {
                productHelper.Delete(product.ProductId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
