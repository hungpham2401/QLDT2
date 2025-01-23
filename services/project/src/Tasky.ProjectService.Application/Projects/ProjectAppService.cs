using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.ProjectService.Features;
using Tasky.ProjectService.Permissions;
using Tasky.ProjectService.Projects.dto;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Features;

namespace Tasky.ProjectService.Projects
{
    //[RequiresFeature(ProjectServiceFeatures.Project.Default)]
    [Authorize(ProjectServicePermissions.Project.Default)]
    //[Authorize]
    public class ProjectAppService : ProjectServiceAppService, IProjectAppService
    {
        private readonly IRepository<Project, Guid> repository;

        public ProjectAppService(IRepository<Project, Guid> repository)
        {
            this.repository = repository;
        }

        public async Task<List<ProjectDto>> GetAllAsync()
        {
            var projects = await repository.GetListAsync();
            return ObjectMapper.Map<List<Project>, List<ProjectDto>>(projects);
        }

        //[Authorize(ProjectServicePermissions.Project.Create)]
        public async Task<ProjectDto> Create(ProjectDto projectDto)
        {
            var project = await repository.InsertAsync(new Project(projectDto.Name));
            return new ProjectDto
            {
                Name = project.Name
            };
        }
    }
}
