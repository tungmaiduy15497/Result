﻿using System;

namespace Tung.Result.Sample.Core.Exceptions
{
    public class ForecastConflictException : Exception
    {
        public ForecastConflictException() : base("Forecast Conflict.") { }
    }
}
