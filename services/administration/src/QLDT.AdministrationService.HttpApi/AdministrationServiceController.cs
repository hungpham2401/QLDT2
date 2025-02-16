﻿using QLDT.AdministrationService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QLDT.AdministrationService;

public abstract class AdministrationServiceController : AbpControllerBase
{
    protected AdministrationServiceController()
    {
        LocalizationResource = typeof(AdministrationServiceResource);
    }
}
