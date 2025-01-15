using Tasky.Samples;
using Xunit;

namespace Tasky.EntityFrameworkCore.Domains;

[Collection(TaskyTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<TaskyEntityFrameworkCoreTestModule>
{

}
