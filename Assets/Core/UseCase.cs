using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UseCase<TPayload, TResult>
{
    TResult Execute(TPayload payload);
}
