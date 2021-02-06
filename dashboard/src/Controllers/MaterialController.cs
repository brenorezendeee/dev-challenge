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
    public class MaterialController : ApiController
    {
        public Material[] Get()
        {
            var collection = JsonConvert.DeserializeObject<List<Material>>(File.ReadAllText("C:/xampp/htdocs/dashboard/src/Controllers/materials.json")); 
            List<Material> aux_collection = new List<Material>(); 
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].MaterialID.Contains(Search.GetInstance().query) || collection[i].MaterialName.Contains(Search.GetInstance().query)) 
                {
                    aux_collection.Add(collection[i]);
                }
            }

            Material[] materialArray = new Material[aux_collection.Count]; 
            for (int i = 0; i < aux_collection.Count; i++)
            {
                materialArray[i] = aux_collection[i]; 
            }

            return materialArray; 
        }
    }
}