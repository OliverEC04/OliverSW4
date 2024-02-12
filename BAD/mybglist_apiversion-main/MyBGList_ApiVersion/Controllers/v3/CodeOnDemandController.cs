using Asp.Versioning;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MyBGList.Controllers.v3;

[Route("v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("3.0")]
public class CodeOnDemandController : ControllerBase
{
    [HttpGet]
    [Route ("test2")]
    [EnableCors("AnyOrigin_GetOnly")]
    [ResponseCache(NoStore = true)]
    public ContentResult GetTest2(int? minutesToAdd)
    {
        var time = DateTime.UtcNow;
        
        if (minutesToAdd != null)
        {
            time = time.AddMinutes(minutesToAdd.Value);
        }
        
        return Content("<script>" +
                       "window.alert('Your client supports JavaScript!" +
                       "\\r\\n\\r\\n" +
                       $"Server time (UTC): {time.ToString("o")}" +
                       "\\r\\n" +
                       "Client time (UTC): ' + new Date().toISOString());" +
                       "</script>" +
                       "<noscript>Your client does not support JavaScript</noscript>",
            "text/html");
    }
}