using QLDT.Samples;
using Xunit;

namespace QLDT.EntityFrameworkCore.Domains;

[Collection(QLDTTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<QLDTEntityFrameworkCoreTestModule>
{

}
