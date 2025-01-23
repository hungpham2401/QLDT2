using AutoMapper;
using QLDT.ProjectService.Projects.dto;

namespace QLDT.ProjectService;

public class ProjectServiceApplicationAutoMapperProfile : Profile
{
    public ProjectServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Project, ProjectDto>();
    }
}
