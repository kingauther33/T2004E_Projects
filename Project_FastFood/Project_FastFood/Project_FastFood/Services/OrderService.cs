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
using Project_FastFood.Adapters;

namespace Project_FastFood.Services
{
    class OrderService
    {
        private Adapter adapter = Adapter.GetAdapter();
        public async Task<CreateOrder> CreateOrder(List<CartItem> items)
        {
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri(adapter.GetCreateOrderAPI);
            HttpStringContent content = new HttpStringContent("{items: "
                + JsonConvert.SerializeObject(items) + "}",
                UnicodeEncoding.Utf8,
                "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(uri, content);
            httpResponseMessage.EnsureSuccessStatusCode();
            var httpResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            CreateOrder createOrder = JsonConvert.DeserializeObject<CreateOrder>(httpResponseBody);
            return createOrder;
        }
    }
}