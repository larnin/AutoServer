using Spectrum.API;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Spectrum.API.Configuration;
using System.IO;

namespace Spectrum.Plugins.ServerMod
{
    public class Entry : IPlugin
    {
        public static ServerModVersion PluginVersion = new ServerModVersion("C.8.3.0");
        private static Settings Settings = new Settings(typeof(Entry));
        public static bool IsFirstRun = false;
        public static Entry Instance = null;

        public string FriendlyName => "Server commands Mod";
        public string Author => "Corecii";
        public string Contact => "SteamID: Corecii; Discord: Corecii#3019";
        public APILevel CompatibleAPILevel => APILevel.XRay;

        public void Initialize(IManager manager)
        {
            
        }

        public void Shutdown()
        {
            
        }
    }
}
