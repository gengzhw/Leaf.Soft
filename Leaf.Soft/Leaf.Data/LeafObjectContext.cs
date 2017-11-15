using Leaf.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using Leaf.Data.Map;

namespace Leaf.Data
{
    
    public class LeafObjectContext : DbContext
    {
        // private readonly IConfigurationRoot config;

        //public LsyiObjectContext(IConfigurationRoot config)
        //{
        //    this.config = config;
        //}
      //  public DbSet<User> Users { get; set; }
        private string conn { get; set; }
        //public LeafObjectContext(DbContextOptions<LeafObjectContext> options):base(options)
        //{

        //}

        public LeafObjectContext(string conn)
        {
            this.conn = conn;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //base.OnConfiguring(optionsBuilder);
            //var conn = config.GetConnectionString("default");

            //optionsBuilder.UseSqlServer(@"Data Source=lsy-pc; Initial Catalog=dbCore; User ID=sa;Password=sql;");
            // optionsBuilder.UseSqlServer(@"Data Source=192.168.0.214; Initial Catalog=coredb; User ID=sa;Password=Dzcye@2016;");
            optionsBuilder.UseSqlServer(conn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //old
       //     var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
       //.Where(type => !String.IsNullOrEmpty(type.Namespace))
       //.Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
       //    type.BaseType.GetGenericTypeDefinition() == typeof(NopEntityTypeConfiguration<>));
       //     foreach (var type in typesToRegister)
       //     {
       //         dynamic configurationInstance = Activator.CreateInstance(type);
       //         modelBuilder.Configurations.Add(configurationInstance);
       //     }

            //right 
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);

            foreach (var type in typesToRegister)
            {

                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            // modelBuilder.ApplyConfiguration(new UserMap());


            base.OnModelCreating(modelBuilder);
        }
    }

    
}
