using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IServerTransportService
{
    void OnServerConnected(); // event handler

    void OnServerDisconnected(); // event handler

    void OnMessageReceived(); // event handler

    bool IsConnected();

    string GetMessage(); // Wait for messages sync

    void SendMessage(string message);
}
