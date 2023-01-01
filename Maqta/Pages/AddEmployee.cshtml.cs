using Maqta.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maqta.Pages
{
    public class AddEmployeeModel : PageModel
    {
        public AddEmployeeModel(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        public IEmployeeService EmployeeService { get; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Get the Model;
            var emp = new DTO.Employee();
            emp.FirstName = Request.Form["name"].ToString();
            emp.Email = Request.Form["email"].ToString();
            emp.Mobile = Request.Form["mobile"].ToString();
            EmployeeService.Add(emp);
            Response.Redirect("Index");
        }
    }
}
