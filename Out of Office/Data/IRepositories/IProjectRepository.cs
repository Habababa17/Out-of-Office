﻿using Microsoft.EntityFrameworkCore;
using Out_of_Office.Models.DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Data.IRepositories
{
    public interface IProjectRepository : IRepository<ProjectModel>
    {
        public Task<ProjectModel?> GetAsync(Guid id);

    }
}
