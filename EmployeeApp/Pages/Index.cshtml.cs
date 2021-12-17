using EFEmployeeAccessLibrary.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EmployeeContext _db;

        public IndexModel(ILogger<IndexModel> logger, EmployeeContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            LoadAllData();
        }

        public void LoadAllData()
        {
            var employees = _db.Employees.ToList();
        }
    }
}