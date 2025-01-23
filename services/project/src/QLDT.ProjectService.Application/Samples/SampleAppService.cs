using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using QLDT.ProjectService.Projects.dto;
using Volo.Abp.Domain.Repositories;

namespace QLDT.ProjectService.Samples;

public class SampleAppService : ProjectServiceAppService, ISampleAppService
{
    private readonly IRepository<Project, Guid> repository;

    public SampleAppService(IRepository<Project, Guid> repository)
    {
        this.repository = repository;
    }
    public async Task<SampleDto> GetAsync()
    {
        var projectDto = new ProjectDto
        {
            Name = "Sample Project"
        };
        var project = await repository.InsertAsync(new Project(projectDto.Name));
        var query = await repository.GetListAsync();
        return new SampleDto
        {
            Value = query.Count
        };
        //return Task.FromResult(
        //    new SampleDto
        //    {
        //        Value = 42
        //    }
        //);
    }

    [Authorize]
    public Task<SampleDto> GetAuthorizedAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }
}
