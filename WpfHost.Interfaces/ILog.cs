﻿using System;

namespace WpfHost.Interfaces
{
    public interface ILog
    {
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Warn(string message, Exception ex);
        void Error(string message);
        void Error(string message, Exception ex);
    }
}
