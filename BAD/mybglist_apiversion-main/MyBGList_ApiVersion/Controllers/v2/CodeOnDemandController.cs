using Asp.Versioning;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MyBGList.Controllers.v2;

[Route("v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("2.0")]
public class CodeOnDemandController : ControllerBase
{
    [HttpGet]
    [Route ("test")]
    [EnableCors("AnyOrigin_GetOnly")]
    [ResponseCache(NoStore = true)]
    public ContentResult GetTest()
    {
        return Content("<script>" +
                       "window.alert('Your client supports JavaScript!" +
                       "\\r\\n\\r\\n" +
                       $"Server time (UTC): {DateTime.UtcNow.ToString("o")}" +
                       "\\r\\n" +
                       "Client time (UTC): ' + new Date().toISOString());" +
                       "</script>" +
                       "<noscript>Your client does not support JavaScript</noscript>",
            "text/html");
    }
    
    [HttpGet]
    [Route ("test2")]
    [EnableCors("AnyOrigin_GetOnly")]
    [ResponseCache(NoStore = true)]
    public ContentResult GetTest2(int? addMinutes)
    {
        var time = DateTime.UtcNow;
        
        if (addMinutes != null)
        {
           time = time.AddMinutes(addMinutes.Value);
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