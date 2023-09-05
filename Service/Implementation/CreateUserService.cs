using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Dto;
using ProjectManager.Models;
using ProjectManager.Repository.Interface;
using ProjectManager.Service.Interface;

namespace ProjectManager.Service.Implementation
{
    public class CreateUserService : ICreateUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CreateUserService(IUserRepository userRepository, IWebHostEnvironment hostEnvironment)
        {
            _userRepository = userRepository;
            _hostEnvironment = hostEnvironment;
        }

         public BaseResponse Create(CreateUserRequestModel model)
        {
             if (model == null)
            {
                return new BaseResponse
                {
                    Message = "Model is null",
                    Status = false
                };
            }
             var customerWithEmail = _userRepository.GetEmail(model.Email);
            if (customerWithEmail != null)
            {
                return new BaseResponse
                {
                    Message = "Email Already in Use",
                    Status = false
                };
            }
             if (model.FormFile is null || model.FormFile.Length <= 0)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Please select a profile picture"
                };
            }
             var acceptableExtension = new List<string>() { ".jpg", ".jpeg", ".png", ".dnb" };
            var fileExtension = Path.GetExtension(model.FormFile.FileName);
            if (!acceptableExtension.Contains(fileExtension))
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "File format not suppported, please upload a picture"
                };
            }
             var user = new User
            {
                Email = model.Email,
                PassWord = model.PassWord,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                ImageReference = ManageUploadOfProfilePictures(model.FormFile),
               

            };
            
            var addUser = _userRepository.Add(user);
             return new BaseResponse
            {
                Message = "Customer Successfully Created",
                Status = true
            };
        }

        private string ManageUploadOfProfilePictures(IFormFile picture)
        {
            var uploadsFolderPath = Path.Combine(_hostEnvironment.WebRootPath, "ProfilePictures");
            Directory.CreateDirectory(uploadsFolderPath);
            string fileName = Guid.NewGuid() + picture.FileName;
            string photoPath = Path.Combine(uploadsFolderPath, fileName);

            using (var fileStream = new FileStream(photoPath, FileMode.Create))
            {
                picture.CopyTo(fileStream);
            }

            return fileName;
        }

       
    }

    
}