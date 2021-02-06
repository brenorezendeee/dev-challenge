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
    public class WorkforceController : ApiController
    {
        public Workforce[] Get()
        {
            var collection = JsonConvert.DeserializeObject<List<Workforce>>(File.ReadAllText("C:/xampp/htdocs/dashboard/src/Controllers/workforce.json")); 
            List<Workforce> aux_collection = new List<Workforce>(); 
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].Name.Contains(Search.GetInstance().query) || collection[i].Shift.Contains(Search.GetInstance().query)) 
                { 
                    aux_collection.Add(collection[i]);
                }
            }

            Workforce[] workforceArray = new Workforce[aux_collection.Count]; 
            for (int i = 0; i < aux_collection.Count; i++)
            {
                workforceArray[i] = aux_collection[i]; 
            }
            
            return workforceArray; 
        }
    }
}