using System;
using System.Collections.Generic;
using System.Text;

namespace NpcBehaviors
{
    public class Container : core.Container
    {
        public core.Container Set<T>(T dependencyInstanceOrDeclaration)
        {
            throw new Exception("Not implemented yet");
        }

        public T Get<T>()
        {
            throw new Exception("Not implemented yet");
        }
    }
}
