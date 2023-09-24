using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerService : ILoggerService
{
    public void Debug(string message, IContext context = null)
    {
        UnityEngine.Debug.Log($"[debug] {message}");
    }

    public void Error(string message, IContext context = null)
    {
        UnityEngine.Debug.Log($"[error] {message}");
    }

    public void Info(string message, IContext context = null)
    {
        UnityEngine.Debug.Log($"[info] {message}");
    }

    public void Ok(string message, IContext context = null)
    {
        UnityEngine.Debug.Log($"[ok] {message}");
    }

    public void Warning(string message, IContext context = null)
    {
        UnityEngine.Debug.Log($"[warning] {message}");
    }
}
