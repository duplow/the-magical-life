using System;
using System.Collections.Generic;
using System.Text;

namespace NpcBehaviors.core
{
    public interface Container
    {
        Container Set<T>(T dependencyInstanceOrDeclaration);

        T Get<T>();
    }
}
