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
        private readonly IUserRepository _userRepository;
        private readonly IUserGroupRepository _userGroupRepository;

        public GroupService(IGroupsRepository repository, IUserRepository userRepository, IUserGroupRepository userGroupRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _userGroupRepository = userGroupRepository;
        }

        public void Create(int userId, GroupDto entity)
        {
            // Validar que exista el profesor
            User user = _userRepository.GetItem(userId);

            if(user == null)
            {
                throw new Exception("User no existe");
            }
            if(user.Student == true)
            {
                throw new Exception("Los estudiantes no pueden crear grupo");
            }

            _repository.Create(new Group
            {
                Name = entity.Name,
                Description = entity.Description,
                MaxGrade = entity.MaxGrade
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
                MaxGrade = c.MaxGrade
            }).ToList();
        }


        /*
        public ICollection<GroupDto> GetCollectionByTeacherId(int id)
        {
            User user = _userRepository.GetItem(id);
            /* Botar un error de exeption 
            if(user == null) {
                throw new Exception("No existe profesor");
                return;
            }*/
            /*ICollection<GroupDto> collectionUserGroup = _userGroupRepository.GetItemsByTeacherId(id);
            ICollection<Group> groups;
            foreach()
        }*/


        public GroupDto GetItem(int id)
        {
            Group group = _repository.GetItem(id);
            GroupDto groupDto = new GroupDto();
            groupDto.Id = group.Id;
            groupDto.Name = group.Name;
            groupDto.Description = group.Description;
            groupDto.MaxGrade = group.MaxGrade;
            return groupDto;
        }

        public void Update( GroupDto entity)
        {
            Group group = _repository.GetItem(entity.Id);
            group.Name = entity.Name;
            group.Description = entity.Description;
            //group.MaxGrade = entity.MaxGrade;
            _repository.Update(group);
        }
    }
}