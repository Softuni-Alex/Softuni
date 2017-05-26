﻿using SOLID.Enums;

namespace SOLID.Interfaces
{
    using System;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        ILayout Layout { get; }

        void Append(DateTime date, ReportLevel reportLevel, string message);
    }
}
