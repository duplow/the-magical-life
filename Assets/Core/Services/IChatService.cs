using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChatChannel {
    DISABLED = 0,
    WORLD = 1,
    MAP = 2,
    PARTY = 3
}

public interface IChatService
{
    void SendMessageToWorld(string message);
    void SendMessageToMap(string message);
    void SendMessageToParty(string message);
    void SendMessageToPlayer(string playerNickname, string message);
    
    void JoinChannel(ChatChannel channel);
    void HandleMessageReceived();
}
