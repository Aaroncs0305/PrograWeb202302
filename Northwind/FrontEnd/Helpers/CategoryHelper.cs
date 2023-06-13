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
    }
}
