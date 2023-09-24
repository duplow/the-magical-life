using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContext {
    string ToLogger();
}

public interface ILoggerService
{
    void Info(string message, IContext context = null);
    void Warning(string message, IContext context = null);
    void Error(string message, IContext context = null);
    void Ok(string message, IContext context = null);
    void Debug(string message, IContext context = null);
}
