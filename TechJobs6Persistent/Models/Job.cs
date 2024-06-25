using System;
using Microsoft.Extensions.Logging;

namespace TechJobs6Persistent.Models
{
    public class Job
    {
        //Job props
        public int Id { get; set; }
        public string Name { get; set; }
        //Employer props
        public Employer Employer { get; set; }
        public int EmployerId { get; set; }
        //Skills props
        public ICollection<Skill> Skills { get; set; }

        //Constructors
        public Job(){}
        public Job(string name, int employerId)
        {
            Name = name;
            EmployerId = employerId;
            Skills = new List<Skill>();
        }

        //Methods
         public override string? ToString()
        {
            return Name;
        }
        public override bool Equals(object? obj)
        {
            return obj is Job @job && Id == @job.Id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

