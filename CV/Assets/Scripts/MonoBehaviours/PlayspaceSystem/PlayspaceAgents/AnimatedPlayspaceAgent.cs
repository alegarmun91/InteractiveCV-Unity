using UnityEngine;

namespace MonoBehaviours.PlayspaceSystem.PlayspaceAgents
{
    [RequireComponent(typeof(Animation))]
    public class AnimatedPlayspaceAgent : PlayspaceAgent
    {
        private string[] _animNames;
        private bool _isDone;

        protected override void Start()
        {
            myPlayspace = transform.GetComponentInChildren<Highlightable>().myPlayspace;

            _animNames = new string[GetComponent<Animation>().GetClipCount()];

            var index = 0;
            foreach (AnimationState anim in GetComponent<Animation>())
            {
                _animNames[index] = anim.name;
                index++;
            }
        }
        
        protected override void CheckPlayspace(Playspace playspace)
        {
            if (playspace == myPlayspace)
                ActivateItem();
            else if(_isDone)
                DeactivateItem();
        }

        protected override void ActivateItem()
        {
            base.ActivateItem();

            TriggerInteraction(0);
        }

        protected override void DeactivateItem()
        {
            base.DeactivateItem();

            TriggerInteraction(1);
        }

        private void TriggerInteraction(int animNumber)
        {
            var currentAnimation = GetComponent<Animation>();

            currentAnimation.Play(_animNames[animNumber]);
            _isDone = !_isDone;
        }
    }
}