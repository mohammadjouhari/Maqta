using DTO;
using Maqta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maqta.Pages
{
    public class EditEmployeeModel : PageModel
    {
        public EditEmployeeModel(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }


        [BindProperty]
        public DTO.Employee Employee { get; set; }
        public IEmployeeService EmployeeService { get; }

        public void OnGet()
        {
            var id = int.Parse(Request.Query["id"]);
            Employee = EmployeeService.Get(id);

        }

        public void OnPost()
        {
            var emp = new DTO.Employee();
            emp.Mobile = Request.Form["mobile"].ToString();
            emp.Email = Request.Form["Email"].ToString();
            emp.FirstName = Request.Form["name"].ToString();
            emp.ID = int.Parse(Request.Form["Id"].ToString());
            EmployeeService.Update(emp);
            Response.Redirect("Index");

        }

    }
}
