﻿using Microsoft.AspNetCore.Mvc;
using ServiceBook.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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