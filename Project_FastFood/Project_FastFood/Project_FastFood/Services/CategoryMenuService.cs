using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_FastFood.Adapters;
using Project_FastFood.Models;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace Project_FastFood.Services
{
    class CategoryMenuService
    {
        private Adapter _adapter = Adapter.GetAdapter();

        public async Task<CategoryDetail> GetCategoryMenu()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_adapter.GetCategoryMenuAPI);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                CategoryDetail categoryData = JsonConvert.DeserializeObject<CategoryDetail>(stringContent);
                return categoryData;
            }
            return null;
        }
    }
}
