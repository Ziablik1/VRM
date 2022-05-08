﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace VRM.DAL.Models
{
    public class User: IdentityUser
    {
        public int Id { get; set; }
        public string Userame { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
