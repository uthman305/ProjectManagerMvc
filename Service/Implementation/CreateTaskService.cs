using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Dto;
using ProjectManager.Repository.Interface;
using ProjectManager.Service.Interface;
using Task = ProjectManager.Models.Task;

namespace ProjectManager.Service.Implementation
{
    public class CreateTaskService : ICreateTaskService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly ITeamMemberProjectRepository _teamMemberProjectRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CreateTaskService(IProjectRepository projectRepository, ITeamMemberProjectRepository teamMemberProjectRepository, ITeamMemberRepository teamMemberRepository, IUserRepository userRepository, ITaskRepository taskRepository, IWebHostEnvironment hostEnvironment)
        {
            _projectRepository = projectRepository;
            _teamMemberProjectRepository = teamMemberProjectRepository;
            _teamMemberRepository = teamMemberRepository;
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            _hostEnvironment = hostEnvironment;
        }
        public BaseResponse Create(CreateTaskViewModel model, string userId, string projectId)
        {
              if (model == null)
            {
                return new BaseResponse
                {
                    Message = "Model is null",
                    Status = false
                };
            }
            var teamMemberId = _teamMemberRepository.GetTeamMemberIdByUserId(userId);
            if (model.Document is null || model.Document.Length <= 0)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Please select a document"
                };
            }

            var acceptableExtensions = new List<string>() { ".jpg", ".jpeg", ".png", ".docx" }; // Corrected extension list
            var fileExtension = Path.GetExtension(model.Document.FileName)?.ToLower(); // Convert to lowercase for comparison
            if (!acceptableExtensions.Contains(fileExtension))
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "File format not supported, please upload a valid document"
                };
            }
            var task = new Task
            {
                ProjectId = projectId,
                DocumentReference = ManageUploadOfDocument(model.Document),
                // DocumentReference = "adc",
                TeamMemberId = teamMemberId,
                Description = model.Description
            };
            _taskRepository.Add(task);
            return new BaseResponse
            {
                Message = "Created Successfully",
                Status = true,
            };
        }
        public List<Task> GetTasksByProjectId(string projectId)
        {
            return _taskRepository.GetTasksByProjectId(projectId);
        }




        private string ManageUploadOfDocument(IFormFile document)
        {
            var uploadsFolderPath = Path.Combine(_hostEnvironment.WebRootPath, "Document");
            Directory.CreateDirectory(uploadsFolderPath);
            string fileName = Guid.NewGuid() + document.FileName;
            string photoPath = Path.Combine(uploadsFolderPath, fileName);

            using (var fileStream = new FileStream(photoPath, FileMode.Create))
            {
                document.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}