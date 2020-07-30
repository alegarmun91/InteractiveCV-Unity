using UnityEngine;

namespace MonoBehaviours.PlayspaceSystem
{
    [RequireComponent(typeof(Collider))]
    public class Highlighter : MonoBehaviour
    {
        private Collider _myCollider;
        
        public Playspace myPlayspace;

        protected virtual void Start()
        {
            _myCollider = transform.GetComponent<Collider>();
        }

        protected void ColliderController(bool colliderState)
        {
            _myCollider.enabled = colliderState;
        }

        private void OnMouseEnter()
        {
            if (myPlayspace.isAwake)
                EventManager.Instance.PlayspaceMouseOver(myPlayspace);
        }

        private void OnMouseDown()
        {
            if (myPlayspace.isAwake)
                EventManager.Instance.PlayspaceMouseDown(myPlayspace);
        }

        private void OnMouseExit()
        {
            if (myPlayspace.isAwake)
                EventManager.Instance.PlayspaceMouseExit(myPlayspace);
        }
    }
}