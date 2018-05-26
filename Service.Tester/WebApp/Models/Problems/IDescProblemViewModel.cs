﻿using System;

namespace WebApp.Models.Problems
{
    public interface IDescProblemViewModel
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }
    }
}