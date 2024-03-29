﻿using Microsoft.AspNetCore.Mvc;
using Repositories;
using AutoMapper;
<<<<<<< HEAD
using Ado.NetSqlHelper;
=======
>>>>>>> 7f5fe51 (Added my project)
using NHibernate_Access.NHibernateEntity;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
<<<<<<< HEAD
        //Test from githup;
        //Test;
        //Test;
        // Testv2;
        private readonly IMapper _mapper;
        public IEmployeeRepositoryAdoNet repositoryEmployeeAdoNet;
=======
        private readonly IMapper _mapper;
>>>>>>> 7f5fe51 (Added my project)
        private readonly IMapperSession _session;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(
            IUnitOfWork UnitOfWork, 
            IMapper mapper, 
<<<<<<< HEAD
            IEmployeeRepositoryAdoNet repositoryEmployeeAdoNet,
=======
>>>>>>> 7f5fe51 (Added my project)
            IMapperSession session)
        {
            _session = session;
            unitOfWork = UnitOfWork;
            _mapper = mapper;
<<<<<<< HEAD
            this.repositoryEmployeeAdoNet = repositoryEmployeeAdoNet;
=======
>>>>>>> 7f5fe51 (Added my project)
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult List()
        {
<<<<<<< HEAD
            //Tets;
           // var s = _session.Employees.ToList();
            var entitiy = unitOfWork.Employee.GetAll();
            var dtoModel = _mapper.Map<List<DTO.Employee>>(entitiy);
            return Ok(dtoModel.Where(s => s.IsDeleted != true).ToList());
=======
            // Tets;
            var entitiy = unitOfWork.Employee.GetAll();
            var dtoModel = _mapper.Map<List<DTO.Employee>>(entitiy);
            return Ok(dtoModel);
>>>>>>> 7f5fe51 (Added my project)
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Add(DTO.Employee dtoModel)
        {
            var entitiy = _mapper.Map<Entity.Employee>(dtoModel);
            entitiy.ModifiedDate = null;
            entitiy.CreationUserID = 1;
            entitiy.ModifyUserID = null;
            entitiy.DeleteUserID = null;
            entitiy.IsDeleted = false;
            entitiy.DeletedDate = null;
            unitOfWork.Employee.Insert(entitiy);
            unitOfWork.Complete();
            unitOfWork.Clear();
            return Ok(entitiy);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetEmployee(int id)
        {
            var entity = unitOfWork.Employee.Get(id);
            var dtoModel2 = _mapper.Map<Entity.Employee>(entity);
            unitOfWork.Clear();
            unitOfWork.Complete();
            unitOfWork.Clear();
            return Ok(dtoModel2);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Edit(DTO.Employee dtoModel)
        {
            var entity = unitOfWork.Employee.Get(dtoModel.ID);
            unitOfWork.Clear();
            if (entity != null)
            {
                entity = _mapper.Map<Entity.Employee>(dtoModel);
                entity.ModifiedDate = DateTime.UtcNow;
                entity.ModifyUserID = 2;
                unitOfWork.Employee.Update(entity);
                unitOfWork.Complete();
                unitOfWork.Clear();
                return Ok(dtoModel);
            }
            else
            {
                return BadRequest(new
                {
                    ErrorMessage = "ID is not valid"
                }
                );
            }
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult delete(int id)
        {
            var entity = unitOfWork.Employee.Get(id);
            unitOfWork.Clear();
            if (entity != null)
            {
                entity.ModifiedDate = DateTime.UtcNow;
                entity.ModifyUserID = 2;
                entity.DeletedDate = DateTime.UtcNow;
                entity.DeleteUserID = 2;
                entity.IsDeleted = true;
                unitOfWork.Employee.Update(entity);     
                unitOfWork.Complete();
                unitOfWork.Clear();
                return Ok();
            }
            else
            {
                return BadRequest
                (
                    new 
                    { 
                        ErrorMessage = "ID is not valid" 
                    }
                );
            }
        }
    }

}
