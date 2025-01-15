using Xunit;

namespace Tasky.EntityFrameworkCore;

[CollectionDefinition(TaskyTestConsts.CollectionDefinitionName)]
public class TaskyEntityFrameworkCoreCollection : ICollectionFixture<TaskyEntityFrameworkCoreFixture>
{

}
