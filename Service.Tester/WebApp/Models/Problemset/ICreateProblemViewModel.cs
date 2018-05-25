﻿using System;

namespace WebApp.Models.Problemset
{
    public interface ICreateProblemViewModel
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }
    }
}