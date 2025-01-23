using Xunit;

namespace QLDT.EntityFrameworkCore;

[CollectionDefinition(QLDTTestConsts.CollectionDefinitionName)]
public class QLDTEntityFrameworkCoreCollection : ICollectionFixture<QLDTEntityFrameworkCoreFixture>
{

}
