using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectManager.Dto;
using ProjectManager.Service.Interface;

namespace ProjectManager.Controllers
{
    public class UserController : Controller
    {
        private readonly ICreateUserService _createUserService;
        private readonly ILoginUserService _loginUserService;
        private readonly ICreateProjectService _createProjectService;
        private readonly IJoinProjectService _joinProjectService;
        private readonly IProjectListingService _projectListingService;
        public UserController(ICreateUserService createUserService, ILoginUserService loginUserService, ICreateProjectService createProjectService, IJoinProjectService joinProjectService,IProjectListingService projectListingService)
        {
            _createUserService = createUserService;
            _loginUserService = loginUserService;
            _createProjectService = createProjectService;
            _joinProjectService = joinProjectService;
            _projectListingService = projectListingService;
        }
        public IActionResult SignUp(CreateUserRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    var signUp = _createUserService.Create(model);
                if (signUp.Status == true)
                {
                    return RedirectToAction("Index");
                }
                return View(signUp);
                }
                
            }
            return View();
        }
        public IActionResult CreateProject(CreateProjectRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var project = _createProjectService.Create(model, userId, out string projectId);
                if (project.Status == true)
                {
                    var joinLink = Url.Action("JoinProject", "User", new { projectId = projectId }, Request.Scheme);
                    ViewData["JoinLink"] = joinLink;
                    return View("CreateProject");
                }
                return View();
            }
            return View();
        }
        public IActionResult JoinProject(JoinProjectRequestModel model)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string projectId = model.ProjectId;
            var project = _joinProjectService.GetProjectById(projectId);

            if (project != null)
            {
                var join = _joinProjectService.Create(model,userId);
                if (join.Status == true)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            return View();
        }
        public IActionResult LogIn(LogInUserRequestModel model)
        {
            var user = _loginUserService.LogIn(model);
            if (user != null)
            {
                var claims = new List<Claim>
                   {
                       new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                       new Claim (ClaimTypes.Email, user.Email),
                   };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Invalid Email or Pin";
                return View();
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyProjects()
    {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userProjects = _projectListingService.GetUserProjects(userId);

        return View(userProjects);
    }

     public IActionResult LogOut()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}