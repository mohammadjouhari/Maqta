using Maqta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maqta.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmployeeService employeeService;

        [BindProperty]
        public List<DTO.Employee> Allemployees { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            this.employeeService = employeeService;
        }

        public IActionResult OnPostRedirect1()
        {
            return Redirect("~/AddEmployee");
        }

        public IActionResult OnPostRedirect2()
        {
            var empId = int.Parse(Request.Form["empId"].ToString());
            return Redirect("~/EditEmployee?id=" + empId);
        }

        public IActionResult OnPostRedirect3()
        {
            var empId = int.Parse(Request.Form["empId"].ToString());
            employeeService.Delete(empId);
            return Redirect("~/Index");
        }

        public void OnGet()
        {
            Allemployees = employeeService.GetAll().ToList();
        }
    }
}