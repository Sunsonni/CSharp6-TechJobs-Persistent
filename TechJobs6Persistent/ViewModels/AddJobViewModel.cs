using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels;

public class AddJobViewModel

{
    public int EmployerId { get; set;}

    public List<SelectListItem> Employers { get; set; } = [];

    [Required]
    public string? Name { get; set; }

    public AddJobViewModel(){}    
    public AddJobViewModel(List<Employer> possibleEmployers)
    {
        foreach (Employer employer in possibleEmployers)
        {
            string employerName = employer.Name;
            string employerLocation = employer.Location;
            Employers.Add(new SelectListItem(employerName, employerLocation));
        }
    }
}