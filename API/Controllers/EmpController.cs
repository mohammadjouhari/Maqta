using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        private readonly IAdoNetRepository adoNetRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDapperRepository dapperRepository;

        public EmpController(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IConfiguration configuration, 
            IAdoNetRepository adoNetRepository, 
            ISeriLog seriLog,
            IMemoryCache cache,
            IDapperRepository dapperRepository
            )
        {
            unitOfWork = UnitOfWork;
            _mapper = mapper;
            this.configuration = configuration;
            this.adoNetRepository = adoNetRepository;
            this.dapperRepository = dapperRepository;
        }


        [Route("[action]")]
        [HttpGet]
        public IActionResult List()
        {
            var entity = unitOfWork.Employee.GetAllv2().ToList();
            var entity2 = unitOfWork.Employee2.GetAllv2().ToList();
            var dtoModel = new List<DTO.Employee>();
            dtoModel = _mapper.Map<List<DTO.Employee>>(entity2);
            return Ok(dtoModel);
        }

        [Route("[action]")] 
        [HttpGet]
        public JsonResult List2(bool shouldLog = true, int pageNumber = 0, int pageSize = 10)
        {
            dapperRepository.GetAllEmployess();
            var dtoModel = new List<DTO.Employee>();
            var entity2 = unitOfWork.Employee.GetAllv2();
            dtoModel = _mapper.Map<List<DTO.Employee>>(entity2);
            return new JsonResult(dtoModel);
        }


        [Route("[action]")]
        [HttpPost]
        public IActionResult Add(DTO.Employee dtoModel)
        {
            var entitiy = _mapper.Map<Entity.Employee>(dtoModel);
            unitOfWork.Employee.Insert(entitiy);
            unitOfWork.Complete();
            unitOfWork.Clear();
            return Ok(dtoModel);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetEmployee(int id)
        {
            var entity = unitOfWork.Employee.Get(id);
            var entity2 = unitOfWork.Employee.GetAll(true).ToList().SingleOrDefault(Employee=> Employee.Id == id);
            unitOfWork.Employee.Update(entity);
            unitOfWork.Employee.Update(entity);
            unitOfWork.Enable();
            var dtoModel2 = _mapper.Map<Entity.Employee>(entity);
            unitOfWork.Complete();
            return Ok(dtoModel2);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Edit([FromForm] dynamic obj)
        {
            var returnUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrlWeb"] +"Index1";
            var dtoModel = new DTO.Employee();
            var id = int.Parse(Request.Form["id"].ToString());
            var firstName = Request.Form["name"];
            var email = Request.Form["email"];
            var mobile = Request.Form["mobile"];
            var entity = unitOfWork.Employee.Get(id);
            unitOfWork.Employee.GetAll(true);
            unitOfWork.Clear();
            if (entity != null)
            {
                entity.FirstName = firstName;
                entity.Email = email.ToString();
                entity.Mobile = mobile;
                dtoModel = _mapper.Map<DTO.Employee>(entity);
                dtoModel.EmployeeId = id.ToString();
                unitOfWork.Employee.Update(entity);
                unitOfWork.Complete();
                unitOfWork.Clear();
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult delete(int id)
        {
            unitOfWork.Enable();
            var entity = unitOfWork.Employee.Get(id);
            entity.IsDeleted = true;
            if (entity != null)
            {
                unitOfWork.Employee.Update(entity);
                unitOfWork.Complete();
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
