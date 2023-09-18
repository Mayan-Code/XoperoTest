using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XoperoCore.HostingService;
using XoperoUI.Models.Home;
using System.Reflection;

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

        public async Task<IActionResult> Index(HostingModel model)
        {
            model.HostingName = _hosting.GetHostingName();

            return View(model);
        }

        public async Task<IActionResult> GetIssues(HostingModel model)
        {
            model.Issues = await _hosting.GetAllIssue(model.BaseModel.RepositoryUserName, model.BaseModel.RepositoryName, model.BaseModel.RepositoryPAT);
            model.HostingName = _hosting.GetHostingName();

            return View(model);
        }

        public async Task<IActionResult> EditIssue(long id)
        {
            EditIssueModel model = new EditIssueModel();

            model.Issue = await _hosting.GetIssue(id);
            model.HostingName = _hosting.GetHostingName();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditIssue(EditIssueModel model)
        {
            await _hosting.EditIssue(model.Issue.Id, model.Issue.Name, model.Issue.Description);

            return this.RedirectToAction("GetIssues", "Home");
        }

        public async Task<IActionResult> CloseIssue(long id)
        {
            EditIssueModel model = new EditIssueModel();

            await _hosting.CloseIssue(id);
            model.HostingName = _hosting.GetHostingName();

            return this.RedirectToAction("GetIssues", "Home");
        }
        public async Task<IActionResult> AddIssue()
        {
            AddIssueModel model = new AddIssueModel();
            model.HostingName = _hosting.GetHostingName();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddIssue(AddIssueModel addssueModel)
        {
            await _hosting.AddNewIssue(addssueModel.Name, addssueModel.Description);

            return RedirectToAction("GetIssues", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}