﻿using EFEmployeeAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEmployeeAccessLibrary.DataAccess
{
    public sealed  class EmployeeContext: DbContext
    {
        public EmployeeContext()
        { }


        public EmployeeContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }



    }
}
