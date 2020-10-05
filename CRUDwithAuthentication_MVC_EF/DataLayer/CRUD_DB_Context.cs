using CRUDwithAuthentication_MVC_EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDwithAuthentication_MVC_EF.DataLayer
{
    public class CRUD_DB_Context:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}