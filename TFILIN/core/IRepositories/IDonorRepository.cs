﻿using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IRepositories
{
    public interface IDonorRepository
    {
       Task<List<Donor>> GetAllDonorsAsync();
    }
}
