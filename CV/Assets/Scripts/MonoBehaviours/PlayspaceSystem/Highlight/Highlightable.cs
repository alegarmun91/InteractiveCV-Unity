using UnityEngine;

namespace MonoBehaviours.PlayspaceSystem
{
    [RequireComponent(typeof(Collider))]
    public class Highlightable : Highlighter
    {
        private new Renderer _renderer;
        private Color _tempColor;

        protected override void Start()
        {
            base.Start();
            _renderer = transform.GetComponent<Renderer>();
            _tempColor = _renderer.material.color;
        }

        private void OnPlayspaceMouseOver(Playspace playspace)
        {
            if (playspace == myPlayspace)
                HighlightSelf(myPlayspace.highlightColor);
        }

        private void OnPlayspaceMouseExit(Playspace playspace)
        {
            if (playspace == myPlayspace)
                DehighlightSelf();
        }

        private void OnPlayspaceChange(Playspace playspace)
        {
            DehighlightSelf();
        }

        private void HighlightSelf(Color color)
        {
            var material = _renderer.material;
            _tempColor = material.color;
            material.color = color;
        }

        private void DehighlightSelf()
        {
            _renderer.material.color = _tempColor;
        }

        private void OnEnable()
        {
            EventManager.Instance.OnPlayspaceMouseOver += OnPlayspaceMouseOver;
            EventManager.Instance.OnPlayspaceMouseExit += OnPlayspaceMouseExit;
            EventManager.Instance.OnPlayspaceMouseDown += OnPlayspaceChange;
        }

        private void OnDisable()
        {
            if (EventManager.Instance == null) return;
            EventManager.Instance.OnPlayspaceMouseOver -= OnPlayspaceMouseOver;
            EventManager.Instance.OnPlayspaceMouseExit -= OnPlayspaceMouseExit;
            EventManager.Instance.OnPlayspaceMouseDown -= OnPlayspaceChange;
        }
    }
}