using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class EmployerController : Controller
    { 
        private readonly JobDbContext context;

        public EmployerController(JobDbContext dbcontext)
        {
            context = dbcontext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //Passing all of the employer objects to view
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        [HttpPost("create")]
        public IActionResult ProcessCreateEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            //If all items pass, an employer object is created and saved to database
            if(ModelState.IsValid)
            {
                Employer employer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location,
                };
                context.Employers.Add(employer);
                context.SaveChanges();
                return Redirect("/Employer");
            }
            //redirects to create page if not
            return View("create", addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            //Checks to see if employer object exists in database
            Employer? requestedEmployer = context.Employers.Find(id);
            //If it exists, an object is created and after searching for item again it replicates specified data
            if(requestedEmployer != null)
            {
                Employer theEmployer = context.Employers.Find(id);
                return View(theEmployer);
            }
            //If it does not exist, return user to Index page
            return View("Index");
        }
    }
}

