using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Dto;
using ProjectManager.Models;

namespace ProjectManager.Service.Interface
{
    public interface IJoinProjectService
    {
        BaseResponse Create(JoinProjectRequestModel model, string userId);
        Project GetProjectById(string projectId);
    }
}