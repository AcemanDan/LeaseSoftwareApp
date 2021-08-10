using LeaseSoftware.Data;
using LeaseSoftware.Models;
using System;
using System.Linq;

namespace LeaseSoftware.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LeaseSoftwareContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Tenants.Any())
            {
                return;   // DB has been seeded
            }

            var tenants = new Tenant[]
            {
                new Tenant{Id = 1, LastName = "Alston", FirstName = "Kirsten",
                    Email = "kirstenalston@decratex.com", Phone = "987-559-2021",
                    Company = "Apextri", BusinessPhone = "950-516-2795"},
                new Tenant{Id = 2, LastName = "Cross", FirstName = "Cassandra",
                    Email = "cassandracross@orbiflex.com", Phone = "883-496-3985",
                    Company = "Orbiflex", BusinessPhone = "896-535-3706"},
                new Tenant{Id = 3, LastName = "Zamora", FirstName = "Torres",
                    Email = "torreszamora@endicil.com", Phone = "854-450-2142",
                    Company = "Endicil", BusinessPhone = "957-440-3289"},
                new Tenant{Id = 4, LastName = "Reid", FirstName = "Steven",
                    Email = "stevenreid@orbiflex.com", Phone = "883-496-3684",
                    Company = "Orbiflex", BusinessPhone = "896-535-3709"},
                new Tenant{Id = 5, LastName = "Fischer", FirstName = "Larson",
                    Email = "larsonfischer@endicil.com", Phone = "870-485-2842",
                    Company = "Entropix", BusinessPhone = "919-490-2166"},
                new Tenant{Id = 6, LastName = "Burton", FirstName = "Willie",
                    Email = "willieburton@entropix.com", Phone = "959-513-3751",
                    Company = "Opticom", BusinessPhone = "992-596-3973"}
            };

            context.Tenants.AddRange(tenants);
            context.SaveChanges();
        }
    }
}
