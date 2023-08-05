using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class CategoryHelper
    {
        ServiceRepository repository;

        public CategoryHelper() 
        {
             repository = new ServiceRepository();
        }

        public CategoryHelper(string token)
        {
            repository = new ServiceRepository(token);
        }

        #region GetAll

        public List<CategoryViewModel> GetAll()
        {
            List<CategoryViewModel> lista = new List<CategoryViewModel>();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Category/");

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

                lista = JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);
            }

            return lista;
        }

        #endregion


        #region GetByID

        /// <summary>
        /// Obtener categoria por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public CategoryViewModel GetById(int id) 
        {
            CategoryViewModel category = new CategoryViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Category/" + id);

            String content = responseMessage.Content.ReadAsStringAsync().Result;

            category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return category;
        }

        #endregion


        #region Update

        public CategoryViewModel Edit(CategoryViewModel category)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Category/", category);

            var content = responseMessage.Content.ReadAsStringAsync().Result;

            CategoryViewModel categoryAPI = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return categoryAPI;
        }

        #endregion


        #region Create

        public CategoryViewModel Add(CategoryViewModel category)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Category/", category);

            var content = responseMessage.Content.ReadAsStringAsync().Result;

            CategoryViewModel categoryAPI = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return categoryAPI;
        }

        #endregion


        #region Delete

        public CategoryViewModel Delete(int id)
        {
            CategoryViewModel category = new CategoryViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Category/" + id);

            //String content = responseMessage.Content.ReadAsStringAsync().Result;

            //category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return category;
        }

        #endregion
    }
}
