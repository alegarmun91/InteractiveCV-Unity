using System;
using MonoBehaviours.Abstract;

namespace MonoBehaviours.PlayspaceSystem
{
    public class EventManager : MonoSingleton<EventManager>
    {
        public event Action<Playspace> OnPlayspaceMouseOver;

        public void PlayspaceMouseOver(Playspace playspace)
        {
            OnPlayspaceMouseOver?.Invoke(playspace);
            // if (OnPlayspaceMouseOver != null)
            //     OnPlayspaceMouseOver(playspace);
        }

        public event Action<Playspace> OnPlayspaceMouseExit;

        public void PlayspaceMouseExit(Playspace playspace)
        {
            OnPlayspaceMouseExit?.Invoke(playspace);
        }

        public event Action<Playspace> OnPlayspaceMouseDown;

        public void PlayspaceMouseDown(Playspace playspace)
        {
            OnPlayspaceMouseDown?.Invoke(playspace);
        }

        public event Action<Playspace> OnEnteringPlayspace;

        public void EnteringPlayspace(Playspace playspace)
        {
            OnEnteringPlayspace?.Invoke(playspace);
        }
    }
}