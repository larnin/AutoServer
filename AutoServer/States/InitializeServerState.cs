using AutoServer.Utilities;
using UnityEngine;
using Events;
using Events.BlackFade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Network;
using Events.MainMenu;

namespace AutoServer.States
{
    public class InitializeServerState : BaseState
    {
        const float actionDelay = 0.5f;
        SubscriberList m_subscriberList = new SubscriberList();

        public override void Start()
        {
            m_subscriberList.Add(new StaticEvent<Initialized.Data>.Subscriber(OnMenuLoaded));
            m_subscriberList.Subscribe();

        }

        public override void Update()
        {

        }

        public override void End()
        {
            m_subscriberList.Unsubscribe();
        }

        void OnMenuLoaded(Initialized.Data e)
        {
            m_subscriberList.Unsubscribe();
            m_subscriberList.Clear();

            Log.Info("Game Loaded");

            TimedAction.DelayedCall(actionDelay, () =>
            {
                var menu = GameObject.FindObjectOfType<MainMenuLogic>();

                if(menu == null)
                {
                    Log.Error("Impossible to find the main menu object !");
                    return;
                }
                menu.OnMultiplayerClicked();

                TimedAction.DelayedCall(actionDelay, () =>
                {
                    menu.OnOnlineMPScreenClicked();
                    TimedAction.DelayedCall(actionDelay, () => OnMultiplayerMenu(menu.onlineMenuLogic_));
                });
            });
        }

        void OnMultiplayerMenu(OnlineMenuLogic menu)
        {
            menu.OnHostAGameClicked();

            TimedAction.DelayedCall(actionDelay, () =>
            {
                m_subscriberList.Add(new StaticEvent<ServerInitialized.Data>.Subscriber(OnServerInitialized));
                m_subscriberList.Subscribe();

                menu.StartConnectionTimer();
                Server.Create("Test autoserver", "", 32);
            });
        }

        void OnServerInitialized(ServerInitialized.Data e)
        {
            Log.Info("Server Initialized !");
        }
    }
}
