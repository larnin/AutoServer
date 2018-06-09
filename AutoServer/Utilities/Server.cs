using Events;
using Spectrum.Interop.Game.EventArgs.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AutoServer.Utilities
{
    public class Server
    {
        public static void Create(string serverTitle, string password, int maxPlayerCount)
        {
            UnityEngine.Network.InitializeSecurity();
            try
            {
                G.Sys.NetworkingManager_.password_ = password;
                G.Sys.NetworkingManager_.serverTitle_ = serverTitle;
                G.Sys.NetworkingManager_.maxPlayerCount_ = maxPlayerCount;

                G.Sys.GameData_.SetString("ServerTitleDefault", serverTitle);
                G.Sys.GameData_.SetInt("MaxPlayersDefault", maxPlayerCount);

                var ncError = UnityEngine.Network.InitializeServer(maxPlayerCount - 1, 32323, true);

                if (ncError == NetworkConnectionError.NoError)
                {
                    StaticEvent<ServerCreatedEventArgs>.Broadcast(new ServerCreatedEventArgs(serverTitle, password, maxPlayerCount));
                    return;
                }

                Log.Error("Failed to start server");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }
}
