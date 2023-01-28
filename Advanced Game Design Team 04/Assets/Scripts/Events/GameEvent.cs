using System;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "new GameEvent", menuName = "ScriptableObjects/Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private event Action _event;

        public void Register(Action onEvent)
        {
            _event += onEvent;
        }

        public void Unregister(Action onEvent)
        {
            _event -= onEvent;
        }
    }
}