﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    

namespace CRUD_Img_Upload.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base (options)
        {

        }
        
        public DbSet<ImageCrudClass> Saveimg { get;set;}

    }
}
