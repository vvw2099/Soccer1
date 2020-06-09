using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Soccer.Web.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Soccer.Web.Models
{
    public class TeamViewModel:TeamEntity
    {
        [Display(Name ="Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
