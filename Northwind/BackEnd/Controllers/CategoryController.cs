﻿using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryDAL categoryDAL;

        private CategoryModel Convertir(Category category)
        {
            return new CategoryModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }

        private Category Convertir(CategoryModel category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }


        #region Constructores

        public CategoryController()
        {
            categoryDAL = new CategoryDALImpl();
        }

        #endregion


        #region Consultas

        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Category> categories = categoryDAL.GetAll();
            List<CategoryModel> models = new List<CategoryModel>();

            foreach (var category in categories) 
            {
                models.Add(Convertir(category));
            }

            return new JsonResult(models);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Category category = categoryDAL.Get(id);

            return new JsonResult(Convertir(category));
        }

        #endregion


        #region Agregar

        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] CategoryModel category)
        {
            categoryDAL.Add(Convertir(category));

            return new JsonResult(category);
        }

        #endregion


        #region Modificar

        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CategoryModel category)
        {
            categoryDAL.Update(Convertir(category));

            return new JsonResult(category);
        }

        #endregion


        #region Eliminar

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Category category = new Category
            {
                CategoryId = id
            };

            categoryDAL.Remove(category);
        }

        #endregion
    }
}
