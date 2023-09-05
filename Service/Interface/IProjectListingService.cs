using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Dto;

namespace ProjectManager.Service.Interface
{
    public interface IProjectListingService
    {
            List<ProjectListingViewModel> GetUserProjects(string userId);
    }
}