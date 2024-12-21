using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.CosmosDB;
using System.Configuration;
using Microsoft.Azure.WebJobs.Extensions.Http;
namespace Company.Function
{
    public static class GetCounter
    {
        [FunctionName("GetCounter")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB("AzureSite", "Counter", Connection = "AzureConnectionString", Id = "1", PartitionKey = "1")] Counter counter,
            [CosmosDB("AzureSite", "Counter", Connection = "AzureConnectionString", Id = "1", PartitionKey = "1")] out Counter updatedCounter)
        {

            updatedCounter = counter;
            updatedCounter.Count += 1;
            var jsonToReturn = JsonConvert.SerializeObject(counter);
            return new OkObjectResult(jsonToReturn);
        }
    }
}
