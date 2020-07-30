using UnityEngine;

namespace MonoBehaviours.PlayspaceSystem.PlayspaceAgents
{
    public abstract class PlayspaceAgent : MonoBehaviour
    {
        public Playspace myPlayspace;
        
        protected bool isActive;

        protected virtual void Start()
        {
            if (!myPlayspace)
                Debug.LogError("Missing Playspace!");
        }

        protected virtual void CheckPlayspace(Playspace playspace)
        {
            if (playspace == myPlayspace)
                ActivateItem();
            else if(isActive)
                DeactivateItem();
        }

        protected virtual void ActivateItem()
        {
            isActive = true;
        }

        protected virtual void DeactivateItem()
        {
            isActive = false;
        }

        private void OnEnable()
        {
            EventManager.Instance.OnPlayspaceMouseDown += CheckPlayspace;
        }

        private void OnDisable()
        {
            if (EventManager.Instance != null)
                EventManager.Instance.OnPlayspaceMouseDown -= CheckPlayspace;
        }
    }
}