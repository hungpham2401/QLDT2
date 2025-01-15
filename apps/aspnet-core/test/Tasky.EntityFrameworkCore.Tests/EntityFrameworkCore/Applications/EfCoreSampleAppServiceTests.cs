using Tasky.Samples;
using Xunit;

namespace Tasky.EntityFrameworkCore.Applications;

[Collection(TaskyTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<TaskyEntityFrameworkCoreTestModule>
{

}
