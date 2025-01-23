using QLDT.Samples;
using Xunit;

namespace QLDT.EntityFrameworkCore.Applications;

[Collection(QLDTTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<QLDTEntityFrameworkCoreTestModule>
{

}
