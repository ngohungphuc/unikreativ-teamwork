﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Services.Interface
{
    public interface IProjectServices
    {
        Task AddProjectAsync(Project project);
    }
}
