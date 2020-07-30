using System;
using DG.Tweening;
using UnityEngine;

namespace MonoBehaviours.PlayspaceSystem.PlayspaceAgents
{
    public class Drawer : PlayspaceAgent
    {
        public float openingDistance = 0.8f;
        public float duration = 1f;
        
        private Vector3 _rootPosition;
        private Vector3 _openPosition;
        
        protected override void Start()
        {
            base.Start();

            _rootPosition = transform.parent.position;
            _openPosition = _rootPosition + Vector3.forward*openingDistance;
        }

        protected override void ActivateItem()
        {
            base.ActivateItem();
            
            transform.position = _rootPosition;
            Tweener tweener = transform.DOMove(_openPosition, duration);
            tweener.SetEase(Ease.InOutQuad);
        }

        protected override void DeactivateItem()
        {
            base.DeactivateItem();
            
            transform.position = _openPosition;
            Tweener tweener = transform.DOMove(_rootPosition, duration);
            tweener.SetEase(Ease.InOutQuad);
        }
    }
}
