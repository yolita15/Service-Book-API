using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Repositories;

namespace ServiceBook.API.Controllers
{
    public class ObjectController : Controller
    {
        private IObjectRepository _objectRepository;

        public ObjectController(IObjectRepository objectRepository)
        {
            _objectRepository = objectRepository;
        }
    }
}
