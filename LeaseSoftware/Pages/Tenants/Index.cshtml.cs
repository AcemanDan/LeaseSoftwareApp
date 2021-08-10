using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LeaseSoftware.Data;
using LeaseSoftware.Models;
using Microsoft.Extensions.Configuration;

namespace LeaseSoftware.Pages.Tenants
{
    public class IndexModel : PageModel
    {
        private readonly LeaseSoftwareContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(LeaseSoftwareContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string LastNameSort { get; set; }
        public string FirstNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Tenant> Tenants { get; set; }

        //public IList<Tenant> Tenants { get;set; }

       public async Task OnGetAsync(string sortOrder, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            LastNameSort = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            FirstNameSort = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = CurrentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Tenant> tenantsIQ = from t in _context.Tenants
                                            select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                tenantsIQ = tenantsIQ.Where(t => t.LastName.ToUpper().Contains(searchString.ToUpper())
                                       || t.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "lastname_desc":
                    tenantsIQ = tenantsIQ.OrderByDescending(t => t.LastName);
                    break;
                case "firstname_desc":
                    tenantsIQ = tenantsIQ.OrderByDescending(t => t.FirstName);
                    break;          
                default:
                    tenantsIQ = tenantsIQ.OrderBy(t => t.LastName);
                    break;
            }

            var pageSize = _configuration.GetValue("PageSize", 4);
            Tenants = await PaginatedList<Tenant>.CreateAsync(
                tenantsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }  
    }
}
