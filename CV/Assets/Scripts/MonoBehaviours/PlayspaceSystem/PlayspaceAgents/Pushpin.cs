using UnityEngine;

namespace MonoBehaviours.PlayspaceSystem.PlayspaceAgents
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Pushpin : PlayspaceAgent
    {
        public string placeName;
        public string description;
        private Collider _myCollider;

        protected override void Start()
        {
            base.Start();

            _myCollider = GetComponent<Collider>();
            _myCollider.enabled = false;
        }

        protected override void ActivateItem()
        {
            base.ActivateItem();

            _myCollider.enabled = true;
        }
        
        protected override void DeactivateItem()
        {
            base.DeactivateItem();

            _myCollider.enabled = false;
        }

        

        private static void ShowDetails(string message)
        {
            TextManager.DisplayMessage(message, Color.black, 0f);
        }
    }
}