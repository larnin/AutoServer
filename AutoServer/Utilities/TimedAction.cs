using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AutoServer.Utilities
{
    public class TimedAction
    {
        GameObject gameObject;
        MonoBehaviour behaviour;

        static TimedAction m_instance;
        static TimedAction instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new TimedAction();
                return m_instance;
            }
        }

        TimedAction()
        {
            gameObject = new GameObject("TimedAction", typeof(MonoBehaviour));
            behaviour = gameObject.GetComponent<MonoBehaviour>();
            GameObject.DontDestroyOnLoad(gameObject);
        }

        public static void DelayedCall(float delay, Action action)
        {
            if(action != null)
                instance.behaviour.StartCoroutine(instance.DoDelayedCall(delay, action));
        }

        IEnumerator DoDelayedCall(float delay, Action action)
        {
            yield return new WaitForSeconds(delay);
            if (action != null)
                action();
        }

        public static void LerpFloat(float startValue, float endValue, float delay, Action<float> setFunction, Action onCompleteAction = null)
        {
            if (setFunction != null)
                instance.behaviour.StartCoroutine(instance.DoLerpFloat(startValue, endValue, delay, setFunction, onCompleteAction));
        }

        IEnumerator DoLerpFloat(float startValue, float endValue, float delay, Action<float> setFunction, Action onCompleteAction)
        {
            float currentTime = 0;
            while (currentTime < delay)
            {
                float value = startValue + (endValue - startValue) * currentTime / delay;
                setFunction(value);

                currentTime += Time.deltaTime;
                yield return null;
            }

            setFunction(endValue);

            if (onCompleteAction != null)
                onCompleteAction();
        }
    }
}
