using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherFCProject.Models
{
    public class WFCastContext : DbContext
    {

        public WFCastContext() : base()
        {

        }
        public WFCastContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Weather> Weathers { get; set; }

    }
}
