﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Entities
{
    public class UserSessionMetrics:EntityBase
    {
        public Guid ServerId { get; set; }
        public Server Server { get; set; }
        public string UserLoginName { get; set; }
    }
}