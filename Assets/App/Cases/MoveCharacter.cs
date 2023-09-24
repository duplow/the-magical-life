using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MoveCharacter : UseCase<Vector3, object>
{
    private ILoggerService logger;

    public MoveCharacter(ILoggerService loggerService, object playerMoveController, object _playerStatController)
    {
        this.logger = loggerService;
    }

    public object Execute(Vector3 payload)
    {
        throw new System.NotImplementedException();
    }
}
