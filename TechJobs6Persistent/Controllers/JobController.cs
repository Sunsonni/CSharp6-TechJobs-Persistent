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
    public class JobController : Controller
    {
        private JobDbContext context;

        public JobController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }


        [HttpGet("Add")]

        public IActionResult Add()
        {
            //Creates list employer object and populates with database items
            List<Employer> employers = context.Employers.OrderBy(employers => employers.Name).ToList();
            //Creates view model passes in employers and adds to view
            AddJobViewModel addJobViewModel = new AddJobViewModel(employers);
            return View(addJobViewModel);
        }

        [HttpPost("Add")]
        public IActionResult Add(AddJobViewModel addJobViewModel)
        {
            if(ModelState.IsValid)
            {
                //creates job object and sets properties
               Job job = new Job
               {
                Name = addJobViewModel.Name,
                EmployerId = addJobViewModel.EmployerId
               };
               //passing to database and saving changes
                context.Jobs.Add(job);
                context.SaveChanges();
                return Redirect("/Job");
            }
            //if not valid, repopulates employers list for next round
            addJobViewModel.Employers = context.Employers.ToList();
            return View(addJobViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.jobs = context.Jobs.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] jobIds)
        {
            foreach (int jobId in jobIds)
            {
                Job theJob = context.Jobs.Find(jobId);
                context.Jobs.Remove(theJob);
            }

            context.SaveChanges();

            return Redirect("/Job");
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs.Include(j => j.Employer).Include(j => j.Skills).Single(j => j.Id == id);

            JobDetailViewModel jobDetailViewModel = new JobDetailViewModel(theJob);

            return View(jobDetailViewModel);

        }
    }
}

