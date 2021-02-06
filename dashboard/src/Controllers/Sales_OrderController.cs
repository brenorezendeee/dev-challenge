using dashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace dashboard.Controllers
{
    public class Sales_OrderController : ApiController
    {

        public Sales_Order[] Get()
        {
            var collection = JsonConvert.DeserializeObject<List<Sales_Order>>(File.ReadAllText("C:/xampp/htdocs/dashboard/src/Controllers/sales_orders.json")); 
            List<Sales_Order> aux_collection = new List<Sales_Order>();  
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].MaterialName.Contains(Search.GetInstance().query)) 
                {
                    aux_collection.Add(collection[i]);
                }
            }

            Sales_Order[] sales_orderArray = new Sales_Order[aux_collection.Count]; 
            for (int i = 0; i < aux_collection.Count; i++)
            {
                sales_orderArray[i] = aux_collection[i]; 
            }
            return sales_orderArray; 
        }
    }
}