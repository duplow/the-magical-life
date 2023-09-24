using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConfig {
    string ServerHost { get; }
    int ServerPort { get; }
}

public interface IConfigurationService<T>
{
    T Get();

    bool isValid(T config);

    void Set(T config);
}

public interface IServerConfigurationService: IConfigurationService<IConfig> {}
