using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace TrelloPush
{

    public static class TrelloPush
    {

// {
//   "bindings": [
//     {
//       "type": "httpTrigger",
//       "direction": "in",
//       "webHookType": "github",
//       "name": "req"
//     },
//     {
//       "type": "http",
//       "direction": "out",
//       "name": "res"
//     }
//   ],
//   "disabled": false
// }

        [FunctionName("GitPush")]
        public static IActionResult GitPush(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, 
            TraceWriter log)
        {
            log.Info("Git push received.");

            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();
            
            

            return req.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
