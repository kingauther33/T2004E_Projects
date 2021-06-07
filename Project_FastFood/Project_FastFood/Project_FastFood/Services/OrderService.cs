using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using System.Net;
//using System.Net.Http;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Newtonsoft.Json;
using Project_FastFood.Models;

namespace Project_FastFood.Services
{
    class OrderService
    {
        private Adapters.Adapter adapter = Adapters.Adapter.GetAdapter();
        public async Task<bool> CreateOrder(List<CartItem> items)
        {
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri(adapter.GetCreateOrderAPI);
            HttpStringContent content = new HttpStringContent("{items: "
                + JsonConvert.SerializeObject(items) + "}",
                UnicodeEncoding.utf8,
                "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(uri, content);
            httpResponseMessage.EnsureSuccessStatusCode();
            var httpResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            CreateOrder createOrder = JsonConvert.DeserializeObject<CreateOrder>(httpResponseBody);
            return createOrder;
        }
    }
}