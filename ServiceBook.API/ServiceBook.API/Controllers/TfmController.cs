using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Entities;
using ServiceBook.API.Models;
using ServiceBook.API.Repositories;
using System.Collections.Generic;

namespace ServiceBook.API.Controllers
{
    [Produces("application/json")]
    [Route("api/tfms")]
    public class TfmController : Controller
    {
        private ITfmRepository _tfmRepository;

        public TfmController(ITfmRepository tfmRepository)
        {
            _tfmRepository = tfmRepository;
        }
     
        [HttpGet( Name = "GetTfms" )]
        public IActionResult GetTfms()
        {
            IEnumerable<Tfm> tfmsFromRepo = _tfmRepository.GetAll();
            IEnumerable<TfmDto> tfms = Mapper.Map<IEnumerable<Tfm>, IEnumerable<TfmDto>>(tfmsFromRepo);

            return Ok(tfms);
        }
    }
}
