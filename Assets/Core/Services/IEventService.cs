using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventService
{
    void Subscribe(string eventName, object handler);

    void Publish(string eventName, object eventData);
}
