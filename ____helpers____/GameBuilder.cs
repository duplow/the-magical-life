using System;
using System.Collections.Generic;
using System.Text;

namespace NpcBehaviors
{
    class GameBuilder
    {
        public core.Container Container;

        public void SetContainer(core.Container container)
        {
            this.Container = container;
        }

        public core.Container GetContainer()
        {
            return this.Container;
        }

        public void SetScene(string sceneName)
        {
        
        }

        public void SetPlayerSkin(string skinName)
        {
        
        }

        public void SetControlInputsAdapter(object inputControlAdapter)
        {
        
        }

        public void SetLogger(object logger)
        {
        
        }

        public void SetDebugMode(object debugMode)
        {
        
        }

        public void Build()
        {
            // TODO: Code here
        }

        public void Run()
        {
            // TODO: Run builded game
        }
    }
}
