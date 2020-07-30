using UnityEngine;
using UnityEngine.InputSystem;

//Manages if the player is able to navigate to the Home or the previous playspace
//using the new input system
namespace MonoBehaviours.PlayspaceSystem
{
    public class ReturnFeatureHandler : MonoBehaviour
    {
        public GameObject backButton;
        public GameObject homeButton;

        private RoomInputActions _inputAction;
        private PlayspaceManager _playspaceManager;

        private void Awake()
        {
            _inputAction = new RoomInputActions();
        }

        private void Start()
        {
            if (backButton == null)
                Debug.LogError("Back button display isn't assigned.");
            else if (homeButton == null)
                Debug.LogError("Home button display isn't assigned.");

            _playspaceManager = FindObjectOfType<PlayspaceManager>();

            if (!_playspaceManager)
                Debug.LogError("Missing Playspace Manager on scene.");

            ShowBackButton(false);
            ShowHomeButton(false);
        }

        private void CheckStatus(Playspace playspace)
        {
            if (playspace != _playspaceManager.DefaultPlayspace)
            {
                if (_playspaceManager.DefaultPlayspace.AccessibleContains(playspace))
                {
                    CanGoBack(true);
                    CanGoHome(false);
                }
                else
                {
                    CanGoBack(true);
                    CanGoHome(true);
                }
            }
            else
            {
                CanGoBack(false);
                CanGoHome(false);
            }
        }

        private void CanGoBack(bool state)
        {
            ShowBackButton(state);
            if (state)
                _inputAction.PlayspaceNavigation.GoBack.Enable();
            else
                _inputAction.PlayspaceNavigation.GoBack.Disable();
        }

        private void CanGoHome(bool state)
        {
            ShowHomeButton(state);
            if (state)
                _inputAction.PlayspaceNavigation.GoHome.Enable();
            else
                _inputAction.PlayspaceNavigation.GoHome.Disable();
        }

        private void ShowBackButton(bool desiredState)
        {
            backButton.SetActive(desiredState);
        }

        private void ShowHomeButton(bool desiredState)
        {
            homeButton.SetActive(desiredState);
        }

        private void GoBackPrevious(InputAction.CallbackContext context)
        {
            EventManager.Instance.PlayspaceMouseDown(_playspaceManager.LastVisited());
        }

        private void GoBackHome(InputAction.CallbackContext context)
        {
            EventManager.Instance.PlayspaceMouseDown(_playspaceManager.DefaultPlayspace);
        }

        private void OnEnable()
        {
            EventManager.Instance.OnPlayspaceMouseDown += CheckStatus;

            _inputAction.PlayspaceNavigation.GoBack.performed += GoBackPrevious;
            _inputAction.PlayspaceNavigation.GoHome.performed += GoBackHome;
        }

        private void OnDisable()
        {
            if (EventManager.Instance != null)
                EventManager.Instance.OnPlayspaceMouseDown -= CheckStatus;

            _inputAction.PlayspaceNavigation.Disable();

            _inputAction.PlayspaceNavigation.GoBack.performed -= GoBackPrevious;
            _inputAction.PlayspaceNavigation.GoHome.performed -= GoBackHome;
        }
    }
}