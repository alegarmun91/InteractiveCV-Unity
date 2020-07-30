using System;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace MonoBehaviours.PlayspaceSystem
{
    [RequireComponent(typeof(PlayspaceCameraController))]
    public class Playspace : MonoBehaviour
    {
        [Tooltip("Playspaces that can be accessed from this playspace.")]
        public Playspace[] accessiblePlayspaces;

        public Color highlightColor = Color.red;

        [HideInInspector] public bool isAwake;

        public string playspaceName;

        public bool AccessibleContains([NotNull] Playspace playspace)
        {
            if (playspace == null) throw new ArgumentNullException(nameof(playspace));
            return accessiblePlayspaces.Any(obj => playspace == obj);
        }
    }
}