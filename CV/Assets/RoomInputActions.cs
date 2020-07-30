// GENERATED AUTOMATICALLY FROM 'Assets/RoomInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Object = UnityEngine.Object;

public class RoomInputActions : IInputActionCollection, IDisposable
{
    // PlayspaceNavigation
    private readonly InputActionMap m_PlayspaceNavigation;
    private readonly InputAction m_PlayspaceNavigation_GoBack;
    private readonly InputAction m_PlayspaceNavigation_GoHome;
    private IPlayspaceNavigationActions m_PlayspaceNavigationActionsCallbackInterface;

    public RoomInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RoomInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayspaceNavigation"",
            ""id"": ""52d0b7d5-e111-47e4-afd0-33b1463659ed"",
            ""actions"": [
                {
                    ""name"": ""GoBack"",
                    ""type"": ""Button"",
                    ""id"": ""565355c4-0eb3-45fc-8de5-d49a37b82ee1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""GoHome"",
                    ""type"": ""Button"",
                    ""id"": ""c04d1551-4232-4370-86f0-19c975160d0f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eed44973-7cde-4ae9-9b57-62c62ab67eef"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04251652-8b83-4a10-a23c-6f494e53cef2"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoHome"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayspaceNavigation
        m_PlayspaceNavigation = asset.FindActionMap("PlayspaceNavigation", true);
        m_PlayspaceNavigation_GoBack = m_PlayspaceNavigation.FindAction("GoBack", true);
        m_PlayspaceNavigation_GoHome = m_PlayspaceNavigation.FindAction("GoHome", true);
    }

    public InputActionAsset asset { get; }
    public PlayspaceNavigationActions PlayspaceNavigation => new PlayspaceNavigationActions(this);

    public void Dispose()
    {
        Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public struct PlayspaceNavigationActions
    {
        private readonly RoomInputActions m_Wrapper;

        public PlayspaceNavigationActions(RoomInputActions wrapper)
        {
            m_Wrapper = wrapper;
        }

        public InputAction GoBack => m_Wrapper.m_PlayspaceNavigation_GoBack;
        public InputAction GoHome => m_Wrapper.m_PlayspaceNavigation_GoHome;

        public InputActionMap Get()
        {
            return m_Wrapper.m_PlayspaceNavigation;
        }

        public void Enable()
        {
            Get().Enable();
        }

        public void Disable()
        {
            Get().Disable();
        }

        public bool enabled => Get().enabled;

        public static implicit operator InputActionMap(PlayspaceNavigationActions set)
        {
            return set.Get();
        }

        public void SetCallbacks(IPlayspaceNavigationActions instance)
        {
            if (m_Wrapper.m_PlayspaceNavigationActionsCallbackInterface != null)
            {
                GoBack.started -= m_Wrapper.m_PlayspaceNavigationActionsCallbackInterface.OnGoBack;
                GoBack.performed -= m_Wrapper.m_PlayspaceNavigationActionsCallbackInterface.OnGoBack;
                GoBack.canceled -= m_Wrapper.m_PlayspaceNavigationActionsCallbackInterface.OnGoBack;
                GoHome.started -= m_Wrapper.m_PlayspaceNavigationActionsCallbackInterface.OnGoHome;
                GoHome.performed -= m_Wrapper.m_PlayspaceNavigationActionsCallbackInterface.OnGoHome;
                GoHome.canceled -= m_Wrapper.m_PlayspaceNavigationActionsCallbackInterface.OnGoHome;
            }

            m_Wrapper.m_PlayspaceNavigationActionsCallbackInterface = instance;
            if (instance != null)
            {
                GoBack.started += instance.OnGoBack;
                GoBack.performed += instance.OnGoBack;
                GoBack.canceled += instance.OnGoBack;
                GoHome.started += instance.OnGoHome;
                GoHome.performed += instance.OnGoHome;
                GoHome.canceled += instance.OnGoHome;
            }
        }
    }

    public interface IPlayspaceNavigationActions
    {
        void OnGoBack(InputAction.CallbackContext context);
        void OnGoHome(InputAction.CallbackContext context);
    }
}