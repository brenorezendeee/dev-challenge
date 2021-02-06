using dashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dashboard.Controllers
{
    public class Purchase_OrderController : ApiController
    {
        public Purchase_Order[] Get()
        {
            var collection = JsonConvert.DeserializeObject<List<Purchase_Order>>(File.ReadAllText("C:/xampp/htdocs/dashboard/src/Controllers/purchase_orders.json")); 
            List<Purchase_Order> aux_collection = new List<Purchase_Order>(); 
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].MaterialName.Contains(Search.GetInstance().query)) 
                {
                    aux_collection.Add(collection[i]);
                }
            }

            Purchase_Order[] purchase_orderArray = new Purchase_Order[aux_collection.Count]; 

            for (int i = 0; i < aux_collection.Count; i++)
            {
                purchase_orderArray[i] = aux_collection[i]; 
            }

            return purchase_orderArray; 
        }
    }
}