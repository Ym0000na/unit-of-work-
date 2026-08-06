using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ReposituryPatternWithUOW.Core.Models;
using System.Text;
using System.Threading.Tasks;


namespace ReposituryPatternWithUOW.EF
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { 
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }
    }

    
    }
