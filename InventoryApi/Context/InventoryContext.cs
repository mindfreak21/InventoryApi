﻿using InventoryApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace InventoryApi.Context
{
    public class InventoryContext: DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {
        }

        //Creamos nuestros DBSet
        public DbSet<User> userItems { get; set; }

    }
}