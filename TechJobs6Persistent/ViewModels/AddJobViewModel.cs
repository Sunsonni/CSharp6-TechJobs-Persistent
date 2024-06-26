using System.ComponentModel.DataAnnotations;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels;

public class AddJobViewModel

{
    //Employer items
    public List<Employer> Employers { get; set; } = [];
    public int EmployerId { get; set; } 

    [Required]
    public string Name { get; set; }

    public AddJobViewModel(){}    
    public AddJobViewModel(List<Employer> possibleEmployers)
    {
        foreach (Employer employer in possibleEmployers)
        {
            Employers.Add(employer);
        }
    }
}