using Spectrum.API;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Spectrum.API.Configuration;
using System.IO;
using AutoServer.States;

namespace AutoServer
{
    public class Entry : IPlugin, IUpdatable
    {
        public string IPCIdentifier { get { return "Auto Server"; }  set { } }

        StateMachine m_machine;

        public void Initialize(IManager manager)
        {
            m_machine = new StateMachine(new InitializeServerState());
        }

        public void Update()
        {
            m_machine.Update();
        }
    }
}
