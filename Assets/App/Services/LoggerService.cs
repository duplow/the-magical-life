using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerService : ILoggerService
{
    private string FromContextToString(IContext context)
    {
        if (context == null) {
            return "";
        }

        return " " + context.ToLogger();
    }

    private string BuildMessage(string level, string message, IContext context)
    {
        if (context == null)
            return $"[{level}] {message}";

        return $"[{level}] {message}\nContext: {FromContextToString(context)}";
    }

    private void Log(string level, string message, IContext context)
    {
        UnityEngine.Debug.Log(BuildMessage(level, message, context));
    }

    public void Debug(string message, IContext context = null)
    {
        Log("debug", message, context);
    }

    public void Error(string message, IContext context = null)
    {
        Log("error", message, context);
    }

    public void Info(string message, IContext context = null)
    {
        Log("info", message, context);
    }

    public void Ok(string message, IContext context = null)
    {
        Log("ok", message, context);
    }

    public void Warning(string message, IContext context = null)
    {
        Log("warning", message, context);
    }
}
