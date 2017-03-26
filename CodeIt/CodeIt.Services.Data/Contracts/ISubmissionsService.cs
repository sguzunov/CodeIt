﻿using CodeIt.Data.Models;
using System;

namespace CodeIt.Services.Data.Contracts
{
    public interface ISubmissionsService
    {
        Submission Create(User creator, Guid challengeId, string sourceCode);
    }
}