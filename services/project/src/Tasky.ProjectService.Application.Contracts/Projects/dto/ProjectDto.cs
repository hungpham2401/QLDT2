using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Tasky.ProjectService.Projects.dto
{
    public class ProjectDto : EntityDto<Guid>
    {
        public string Name { get; set; } = string.Empty;
    }
}
