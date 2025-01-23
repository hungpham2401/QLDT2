using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDT.ProjectService.Projects.dto;
using Volo.Abp.Application.Services;

namespace QLDT.ProjectService.Projects
{
    public interface IProjectAppService : IApplicationService
    {
        Task<List<ProjectDto>> GetAllAsync();

        Task<ProjectDto> Create(ProjectDto projectDto);
    }
}
