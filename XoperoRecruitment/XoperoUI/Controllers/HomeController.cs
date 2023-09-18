using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XoperoUI.Models;
using XoperoCore.HostingService;
using XoperoUI.Models.Home;

namespace XoperoUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHosting _hosting;
        public HomeController(ILogger<HomeController> logger, IHosting hosting)
        {
            _logger = logger;
            _hosting = hosting;
        }

        public IActionResult Index(BaseModel model)
        {
            HostingModel hostingModel = new HostingModel();
            if (model != null)
            {
                hostingModel.HostingName = _hosting.GetHostingName();
            }
            return View(hostingModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddIssue(AddIssueModel addssueModel)
        {
            await _hosting.AddNewIssue(new XoperoCore.HostingService.Models.NewIssueModel
            {
                IssueDescription = addssueModel.IssueDescription,
                IssueName = addssueModel.IssueName,
                RepositoryName = addssueModel.RepositoryName,
                RepositoryUserName = addssueModel.RepositoryUserName,
            });

            return RedirectToAction("Index", "Home", new { model = addssueModel});
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}