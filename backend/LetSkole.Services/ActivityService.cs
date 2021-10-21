﻿using LetSkole.DataAccess;
using LetSkole.Dto;
using LetSkole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetSkole.Services
{
    public class ActivityService : IActivityService
    {

        private readonly IActivityRepository _repository;
        private readonly IUserRepository _userRepository;
        //Falta agregar la entidad User repository
        //private readonly IUserRepository _repository2;


        public ActivityService(IActivityRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public void Create(ActivityDto entity)
        {
            DateTime now = DateTime.Now;
            DateTime inicio = DateTime.MinValue;
            entity.StartDate = new DateTime(now.Year, now.Month, now.Day);

            // Validar user
            User user = _userRepository.GetItem(entity.UserId);
            if(user == null)
            {
                throw new Exception("User not found");
            }

            // Buscamos errores
            int res = DateTime.Compare(entity.StartDate, entity.EndDate);
            if (res >= 0)
            {
                throw new Exception("Fecha invalida");
            }

            if (entity.StartTime != inicio && entity.EndTime != inicio)
            {
                // Puedo comparar 
                if (DateTime.Compare(entity.StartTime, entity.EndTime) >= 0)
                {
                    throw new Exception("Fecha invalida");
                }

                if (DateTime.Compare(entity.StartDate, entity.StartTime) > 0)
                {
                    throw new Exception("Fecha invalida");
                }
            }

            if (entity.Name == "" || entity.Name == null)
            {
                throw new Exception("Falta ingresar nombre");
            }
     
            _repository.Create(new Activity
            {
                UserId = entity.UserId, //validar el user id
                Name = entity.Name,
                Description = entity.Description,
                StartDate = entity.StartDate, // Tiempo del sistema a las 0:0:0 horas
                EndDate = entity.EndDate,
                Completed = false, // Siempre inicia en falso
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
            });
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ICollection<ActivityDto> GetCollection(string filter)
        {
            var Collection = _repository.GetActivities(filter ?? string.Empty);
            return Collection.Select(c => new ActivityDto
            {
                Id = c.Id,
                UserId = c.UserId,
                Name = c.Name,
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Completed = c.Completed,
                StartTime = c.StartTime,
                EndTime = c.EndTime
            }).ToList();
        }

        public ActivityDto GetItem(int id)
        {
            Activity activity = _repository.GetItem(id);
            ActivityDto activityDto = new ActivityDto();





            activityDto.Id = activity.Id;
            activityDto.UserId = activity.UserId;
            activityDto.Name = activity.Name;
            activityDto.Description = activity.Description;
            activityDto.StartDate = activity.StartDate;
            activityDto.EndDate = activity.EndDate;
            activityDto.Completed = activity.Completed;
            activityDto.StartTime = activity.StartTime;
            activityDto.EndTime = activity.EndTime;
            return activityDto;
        }

        public void Update(ActivityDto entity)
        {

            Activity activity = _repository.GetItem(entity.Id);
            DateTime inicio = DateTime.MinValue;

            if (activity == null)
            {
                throw new Exception("El id de la actividad no existe");
                return;
            }

            //Falta comprobar si el usuario existe
            /*Activity activityUserID = _repository.GetItem(entity.UserId);
            if (activityUserID == null)
            {
                throw new Exception("El id del usuario no existe");
                return;
            }*/


            //Nombre
            if (entity.Name == "" || entity.Name == null)
            {
                activity.Name = activity.Name;
            }
            else
            {
                activity.Name = entity.Name;
            }

            //Description
            if (entity.Description == "" || entity.Description == null)
            {
                activity.Description = activity.Description;
            }
            else
            {
                activity.Description = entity.Description;
            }


            if (entity.EndDate == inicio)
            {
                activity.EndDate = activity.EndDate;
            }
            else
            {
                DateTime auxEndDate = entity.EndDate;
                int resCom = DateTime.Compare(activity.StartDate, auxEndDate);
                if (resCom < 0)
                {
                    //Modifico
                    activity.EndDate = entity.EndDate;
                }
                else
                {
                    throw new Exception("Fecha incorrecta");
                    return;
                }



            }

            activity.Completed = entity.Completed;

            DateTime auxStartDate = entity.StartDate;
            DateTime auxStarTime = entity.StartTime;

            int res3 = DateTime.Compare(auxStartDate, entity.StartTime);
            if (res3 >= 0)
            {
                throw new Exception("Fecha incorrecta");
                return;
            }

            DateTime auxEndDate2 = entity.EndDate;
            res3 = DateTime.Compare(entity.StartTime, auxEndDate2);
            if (res3 >= 0)
            {
                throw new Exception("Fecha incorrecta");
                return;
            }

            res3 = DateTime.Compare(entity.EndTime, auxStartDate);
            if (res3 <= 0)
            {
                throw new Exception("Fecha incorrecta");
                return;
            }

            res3 = DateTime.Compare(entity.EndTime, auxEndDate2);
            if (res3 >= 0)
            {
                throw new Exception("Fecha incorrecta");
                return;
            }

            res3 = DateTime.Compare(entity.StartTime, entity.EndTime);
            if (res3 >= 0)
            {
                throw new Exception("Fecha incorrecta");
                return;

            }

            activity.StartTime = entity.StartTime;
            _repository.Update(activity);
        }
    }
}