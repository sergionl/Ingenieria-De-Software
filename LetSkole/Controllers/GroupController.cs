﻿using LetSkole.Dto;
using LetSkole.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetSkole.Controllers
{
    [Route("api/v1/[controller]")]

    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroupService _service;

        public GroupController(IGroupService service)
        {
            _service = service;
        }

        [Route("Create")]
        [HttpPost]
        public void Post([FromBody] GroupDto GroupDto)
        {
            _service.Create(GroupDto);
        }

        [Route("GetAllByFilter")]
        [HttpGet]
        public IEnumerable<GroupDto> GetAllByFilter([FromQuery] string filter)
        {
            return _service.GetCollection(filter);
        }


        [Route("Update")]
        [HttpPut]
        public void Put([FromQuery] GroupDto groupDto)
        {
            _service.Update(groupDto);
        }

        [Route("Delete")]
        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            _service.Delete(id);
        }

        [Route("GetById")]
        [HttpGet]
        public GroupDto GetItemById([FromQuery] int id)
        {
        return _service.GetItem(id);
        }
}
}