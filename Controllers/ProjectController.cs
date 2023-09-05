using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Dto;
using ProjectManager.Service.Interface;
using Task = ProjectManager.Models.Task;

namespace ProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ICreateUserService _createUserService;
        private readonly ILoginUserService _loginUserService;
        private readonly ICreateTaskService _createTaskService;
        private readonly IJoinProjectService _joinProjectService;
        private readonly IProjectListingService _projectListingService;
        public ProjectController(ICreateUserService createUserService, ILoginUserService loginUserService, ICreateTaskService createTaskService, IJoinProjectService joinProjectService, IProjectListingService projectListingService)
        {
            _createUserService = createUserService;
            _loginUserService = loginUserService;
            _createTaskService = createTaskService;
            _joinProjectService = joinProjectService;
            _projectListingService = projectListingService;
        }
        public IActionResult Index(string projectId)
        {
            var project = _joinProjectService.GetProjectById(projectId);
            if (project == null)
            {
                return NotFound();
            }

            ViewData["ProjectName"] = project.Name;
            return View(project);
        }
        [HttpGet]
        public IActionResult CreateTask(string projectId)
        {
            var viewModel = new CreateTaskViewModel
            {
                ProjectId = projectId,
            };
            TempData["projectId"] = projectId;
            TempData.Keep();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateTask(CreateTaskViewModel viewModel)
        {
            var projectId = TempData.Peek("projectId").ToString();
            // if (ModelState.IsValid)
            // {
            // Assign the logged-in user's TeamMemberId to the task
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _createTaskService.Create(viewModel, userId, projectId);
            return RedirectToAction("Index", "Project", new { projectId = TempData.Peek("projectId").ToString() });
            // }

            // return View(viewModel);
        }
        public IActionResult ProjectTask(string projectId)
        {
             var tasks = _createTaskService.GetTasksByProjectId(projectId);
             var project = _joinProjectService.GetProjectById(projectId);

            var viewModel = new TaskListingViewModel
            {
                Tasks = tasks,
                ProjectName = project.Name
            };

            return View(viewModel);
        }
    }
}
