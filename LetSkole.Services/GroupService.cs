﻿using LetSkole.DataAccess;
using LetSkole.Dto;
using LetSkole.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LetSkole.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupsRepository _repository;

        public GroupService(IGroupsRepository repository)
        {
            _repository = repository;
        }

        public void Create(GroupDto entity)
        {
            _repository.Create(new Group
            {
                Name = entity.Name,
                Description = entity.Description,
            });
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ICollection<GroupDto> GetCollection(string filter)
        {
            var Collection = _repository.GetCollection(filter ?? string.Empty);
            return Collection.Select(c => new GroupDto
            {
                Id = c.Id,
                Description = c.Description,
                Name = c.Name,

            }).ToList();
        }

        public GroupDto GetItem(int id)
        {

  
            Group group = _repository.GetItem(id);

            GroupDto groupDto = new GroupDto();
            groupDto.Id = group.Id;
            groupDto.Name = group.Name;
            groupDto.Description = group.Description;
            return groupDto;
        }

        public void Update( GroupDto entity)
        {


            Group group = _repository.GetItem(entity.Id);

            group.Name = entity.Name;
            group.Description = entity.Description;
            _repository.Update(group);
        }
    }
}