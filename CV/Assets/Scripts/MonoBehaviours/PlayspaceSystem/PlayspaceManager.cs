using System.Collections.Generic;
using MonoBehaviours.Abstract;
using UnityEngine;

namespace MonoBehaviours.PlayspaceSystem
{
    public class PlayspaceManager : MonoSingleton<PlayspaceManager>
    {
        private readonly List<Playspace> _playspacesOnScene = new List<Playspace>();
        private readonly Stack<Playspace> _visitedPlayspaces = new Stack<Playspace>();
        private Playspace _currentPlayspace;

        public Playspace DefaultPlayspace { get; private set; }


        protected override void Init()
        {
            var playspacesInChildren = transform.GetComponentsInChildren<Playspace>();

            if (playspacesInChildren.Length == 0)
                Debug.LogError("No Playspaces found. Children the playspaces to the Playspace Manager.");

            foreach (var playspace in playspacesInChildren)
            {
                if (!_playspacesOnScene.Contains(playspace))
                    _playspacesOnScene.Add(playspace);
            }

            if (DefaultPlayspace == null)
                DefaultPlayspace = _playspacesOnScene[0];

            _currentPlayspace = DefaultPlayspace;

            AwakeAccessiblePlayspaces(DefaultPlayspace);
        }

        private void EnterPlayspace(Playspace playspace)
        {
            if (_currentPlayspace == DefaultPlayspace)
            {
                _visitedPlayspaces.Push(DefaultPlayspace);
            }
            else if (_visitedPlayspaces.Contains(playspace))
            {
                EnteringVisitedPlayspace(playspace);
            }
            else
            {
                if (!_visitedPlayspaces.Peek().AccessibleContains(playspace))
                    _visitedPlayspaces.Push(_currentPlayspace);
            }

            _currentPlayspace = playspace;
            AwakeAccessiblePlayspaces(playspace);
        }

        private void EnteringVisitedPlayspace(Object playspace)
        {
            while (_visitedPlayspaces.Peek() != playspace) _visitedPlayspaces.Pop();
            _visitedPlayspaces.Pop();
        }

        private void AwakeAccessiblePlayspaces(Playspace playspace)
        {
            foreach (var playspaceOnScene in _playspacesOnScene)
            {
                playspaceOnScene.isAwake = false;

                foreach (var obj in playspace.accessiblePlayspaces)
                {
                    if (playspaceOnScene != obj) continue;
                    playspaceOnScene.isAwake = true;
                    break;
                }
            }
        }

        private void OnEnable()
        {
            EventManager.Instance.OnPlayspaceMouseDown += EnterPlayspace;
        }

        private void OnDisable()
        {
            if (EventManager.Instance != null)
                EventManager.Instance.OnPlayspaceMouseDown -= EnterPlayspace;
        }

        public Playspace LastVisited()
        {
            return _visitedPlayspaces.Peek();
        }
    }
}