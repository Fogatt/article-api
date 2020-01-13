using Microsoft.AspNetCore.Mvc;

namespace Article.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public object Get()
        {
            // return _repository.Get();
            return new
            {
                version = "Version 1"
            };
        }
    }
}