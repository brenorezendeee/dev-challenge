using dashboard.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dashboard.Controllers
{
    public class EquipmentController : ApiController
    {
     public Equipment[] Get()
        {
            var collection = JsonConvert.DeserializeObject<List<Equipment>>(File.ReadAllText("C:/xampp/htdocs/dashboard/src/Controllers/equipments.json")); 
            List<Equipment> aux_collection = new List<Equipment>(); 
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].EquipmentID.Contains(Search.GetInstance().query) || collection[i].EquipmentName.Contains(Search.GetInstance().query)) 
                {
                    aux_collection.Add(collection[i]);
                }
            }

            Equipment[] equipmentArray = new Equipment[aux_collection.Count]; 
            for (int i = 0; i < aux_collection.Count; i++)
            {
                equipmentArray[i] = aux_collection[i]; 
            }

    return equipmentArray; 
        }
    }
}