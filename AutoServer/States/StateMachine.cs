using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoServer.States
{
    public class StateMachine
    {
        List<BaseState> m_states = new List<BaseState>();

        int m_currentUpdateIndex = 0;

        public StateMachine(BaseState initialState = null)
        {
            SetState(initialState);
        }

        public void SetState(BaseState state)
        {
            ClearStates();
            PushState(state);
        }

        public void PushState(BaseState state)
        {
            if (state == null)
                return;
            var id = m_states.IndexOf(state);
            if (id < 0)
            {
                state.machine = this;
                state.Start();
                m_states.Add(state);
            }
        }

        public bool PopState(BaseState state)
        {
            var index = m_states.IndexOf(state);
            if (index < 0)
                return false;

            if (index <= m_currentUpdateIndex)
                m_currentUpdateIndex--;
            m_states[index].End();
            m_states.RemoveAt(index);
            return true;
        }

        public void ClearStates()
        {
            foreach (var state in m_states)
                state.End();
            m_states.Clear();
        }

        public void Update()
        {
            for(m_currentUpdateIndex = 0; m_currentUpdateIndex < m_states.Count; m_currentUpdateIndex++)
                m_states[m_currentUpdateIndex].Update();
        }
    }
}
