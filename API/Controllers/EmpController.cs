using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Repositories;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        private readonly IAdoNetRepository adoNetRepository;
        private readonly ISeriLog seriLog;
        private readonly IUnitOfWork unitOfWork;

        public EmpController(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IConfiguration configuration, 
            IAdoNetRepository adoNetRepository, 
            ISeriLog seriLog)
        {
            unitOfWork = UnitOfWork;
            _mapper = mapper;
            this.configuration = configuration;
            this.adoNetRepository = adoNetRepository;
            this.seriLog = seriLog;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult List(bool shouldLog= true)
        {
            var entitiy = unitOfWork.Employee.GetAll();
            var dtoModel = _mapper.Map<List<DTO.Employee>>(entitiy);
            var dtoModel2 = adoNetRepository.GetAllEmployess();
            IDbConnection db = new SqlConnection(configuration.GetConnectionString("HrSoultion"));
            var dtoModel3 = db.Query<DTO.Employee>("select * from employee").ToList();
            if(shouldLog)
            {
                seriLog.Log(dtoModel3.Count.ToString());
            }
            db.Dispose();
            return Ok(dtoModel);
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
            entitiy.Bank = new Entity.EmployeeBank();
            entitiy.Bank.EmployeeId = dtoModel.EmployeeId;
            entitiy.Bank.Iban = "";
            entitiy.Bank.IsActive = false;
            entitiy.Bank.DeletedDate = DateTime.UtcNow;
            entitiy.Bank.DeleteUserID = -1;
            entitiy.Bank.ModifiedDate = DateTime.UtcNow;
            entitiy.Bank.CreationUserID = -1;
            entitiy.Bank.ModifiedDate = DateTime.UtcNow;
            entitiy.Bank.IsDeleted = false;
            entitiy.Bank.DeletedDate = DateTime.UtcNow;
            entitiy.Bank.Name = "";
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
        [Route("[action]")]
        [HttpGet]
        public JsonResult A()
        {

            //TODO: user now contains the details, you can do required operations  
            var rng = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new 
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = ""
            })
            .ToArray();
            return new JsonResult(result);
        }

    }
}
