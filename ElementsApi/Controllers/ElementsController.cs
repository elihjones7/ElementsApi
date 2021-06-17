using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElementsApi.Models;

namespace ElementsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElementsController : ControllerBase
    {
        private readonly ILogger<ElementsController> _logger;

        public Element[] file_to_array()
        {
            string line;
            int counter = 0;
            Element[] result = new Element[31];
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Eli\source\repos\ElementsApi\ElementsApi\Data\MockData.txt");

            while ((line = file.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                result[counter] = new Element();
                result[counter].Id = counter;
                result[counter].front = parts[1];
                result[counter].back = parts[2];
                counter++;
            }

            return result;
        }

        public ElementsController(ILogger<ElementsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Element[] Get()
        {
            return file_to_array();
        }

        [HttpGet("element")]
        public Element Get(int id)
        {
            return file_to_array()[id];
        }
    }
}
