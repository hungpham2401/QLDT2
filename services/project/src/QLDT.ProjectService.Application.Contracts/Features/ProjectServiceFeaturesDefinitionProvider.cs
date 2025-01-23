using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDT.ProjectService.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace QLDT.ProjectService.Features
{
    public class ProjectServiceFeaturesDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var myGroup = context.AddGroup(ProjectServiceFeatures.GroupName);
            myGroup.AddFeature(
                ProjectServiceFeatures.Project.Default,
                defaultValue: "false",
                displayName: L("Project"),
                valueType: new ToggleStringValueType());
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProjectServiceResource>(name);
        }
    }
}
