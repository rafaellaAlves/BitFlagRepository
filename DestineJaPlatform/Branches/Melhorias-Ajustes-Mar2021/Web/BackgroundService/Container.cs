﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.BackgroundService
{
    public static class Container
    {
        public static BackgroundServices.UpdateDemandStatusService UpdateDemandStatusService;
        public static BackgroundServices.UpdateDemandDestinationStatusService UpdateDemandDestinationStatusService;
    }
}
