using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels;

public class AddEmployerViewModel
{
    [Required]
    public string? Name { get; set;}
    [Required]
    public string? Location { get; set;}
}