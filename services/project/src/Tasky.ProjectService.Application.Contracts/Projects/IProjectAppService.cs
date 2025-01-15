using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.ProjectService.Projects.dto;
using Volo.Abp.Application.Services;

namespace Tasky.ProjectService.Projects
{
    public interface IProjectAppService : IApplicationService
    {
        Task<List<ProjectDto>> GetAllAsync();

        Task<ProjectDto> Create(ProjectDto projectDto);
    }
}
