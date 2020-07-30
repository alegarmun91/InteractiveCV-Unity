using System.Diagnostics.CodeAnalysis;
using Cinemachine;
using UnityEngine;

namespace MonoBehaviours.PlayspaceSystem
{
    public class PlayspaceCameraController : MonoBehaviour
    {
        private CinemachineVirtualCamera _myCamera;
        private Playspace _myPlayspace;

        private void Awake()
        {
            _myCamera = gameObject.GetComponent<CinemachineVirtualCamera>();

            if (!_myCamera) gameObject.AddComponent<CinemachineVirtualCamera>();

            _myPlayspace = gameObject.GetComponent<Playspace>();

            if (!_myPlayspace) Debug.LogError("Camera missing its Playspace.");
        }

        private void ManageSelf(Playspace playspace)
        {
            if (playspace == _myPlayspace)
                TakeCameraControl();
            else
                ReturnCameraControl();
        }

        private void TakeCameraControl()
        {
            _myCamera.Priority = 20;
        }

        private void ReturnCameraControl()
        {
            _myCamera.Priority = 10;
        }

        private void OnEnable()
        {
            EventManager.Instance.OnPlayspaceMouseDown += ManageSelf;
        }

        private void OnDisable()
        {
            if (EventManager.Instance != null)
                EventManager.Instance.OnPlayspaceMouseDown -= ManageSelf;
        }
    }
}