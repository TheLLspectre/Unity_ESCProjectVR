// GENERATED AUTOMATICALLY FROM 'Assets/_Prefab/Input/XRInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @XRInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @XRInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""XRInputActions"",
    ""maps"": [
        {
            ""name"": ""Control"",
            ""id"": ""d19f6b44-2ad1-421f-9532-ea5f527b49d8"",
            ""actions"": [
                {
                    ""name"": ""LeftHandTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""038049b5-45cc-4701-abdc-b8323b8b8851"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandGrip"",
                    ""type"": ""Button"",
                    ""id"": ""e8628683-95ba-42fc-a388-5537e6a128e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandButton1"",
                    ""type"": ""Button"",
                    ""id"": ""5d8b11a4-d22a-4a63-a071-f136165ee340"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandButton2"",
                    ""type"": ""Button"",
                    ""id"": ""a83a67df-7c0e-48aa-99b8-1d843f13bd6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandStick"",
                    ""type"": ""Value"",
                    ""id"": ""afc0cdf1-52c5-4888-919a-9af8c76f7c67"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandStickUp"",
                    ""type"": ""Value"",
                    ""id"": ""76020cc6-9c0a-4b67-9e72-92bc428f20e5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandStickX"",
                    ""type"": ""Value"",
                    ""id"": ""45363931-b916-4e3a-b5b4-69499826f3b1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandStickY"",
                    ""type"": ""Value"",
                    ""id"": ""a931de23-09ac-40b2-bf36-41536a118ed5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandStickDown"",
                    ""type"": ""Value"",
                    ""id"": ""f9c7f0d8-8e17-4b4e-9ec1-49c8a1f6bb08"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""4b46bd39-cd7b-45b3-a4c9-8504a3b3a7de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandGrip"",
                    ""type"": ""Button"",
                    ""id"": ""e9a03c93-4dba-4df1-98fa-aaddd70636b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandButton1"",
                    ""type"": ""Button"",
                    ""id"": ""b8f8a91d-4f7d-47ae-b631-64de6af939b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandButton2"",
                    ""type"": ""Button"",
                    ""id"": ""6c61979f-eab5-4f0e-a2d7-e5db557e1b68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandStick"",
                    ""type"": ""Value"",
                    ""id"": ""e6f1e4c4-ab93-49f7-8462-35561eae5ca3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandStickUp"",
                    ""type"": ""Value"",
                    ""id"": ""059c9747-4499-41fb-9b42-c9ac0b362629"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandStickX"",
                    ""type"": ""Value"",
                    ""id"": ""f0a8a51d-d3f7-4e2d-82ca-a0ff516173eb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandStickY"",
                    ""type"": ""Value"",
                    ""id"": ""b160c553-2edc-4ae1-bf01-add912439df7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandStickDown"",
                    ""type"": ""Value"",
                    ""id"": ""25657c26-b994-4b85-b88b-58e1c7771b8e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandTouchPad"",
                    ""type"": ""Value"",
                    ""id"": ""a0df8363-1ec8-48ed-af69-05e8126d0924"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2,ScaleVector2,StickDeadzone(max=1)"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8190bdd7-9b85-437a-a8cf-4804b6959152"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""LeftHandTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27cb2b19-d6b0-4ae3-9a8f-50732b6666f4"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""RightHandTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47d3630b-2d1b-43a3-8685-0e8964e07dfc"",
                    ""path"": ""<XRController>{RightHand}/touchpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""RightHandTouchPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cf8a84d-a616-4244-9ace-a498f261b6b7"",
                    ""path"": ""<XRController>{RightHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""RightHandStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c82bb58-f019-4f50-a35e-c3c57d8e0591"",
                    ""path"": ""<XRController>{RightHand}/joystick"",
                    ""interactions"": ""Sector(directions=1),Sector(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""RightHandStickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c14b1bfd-ace5-4f43-a1e9-e2b506309396"",
                    ""path"": ""<XRController>{RightHand}/joystick"",
                    ""interactions"": ""Sector(directions=12),Sector(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""RightHandStickX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1d32978-bfb3-4dd9-b5dd-7710a06691b6"",
                    ""path"": ""<XRController>{RightHand}/joystick"",
                    ""interactions"": ""Sector(directions=3),Sector(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""RightHandStickY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83697cdc-7859-432f-8938-337b73b6aae3"",
                    ""path"": ""<XRController>{RightHand}/joystick"",
                    ""interactions"": ""Sector(directions=2),Sector(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""RightHandStickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bc30cbe-80ff-4166-9195-e8aa02a69366"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""LeftHandStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9601e8dc-55cd-476a-89bc-17a7fc076881"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": ""Sector(directions=1),Sector(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""LeftHandStickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7984a4aa-4f62-4786-8b87-6bf1f03bfe6b"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": ""Sector(directions=12),Sector(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""LeftHandStickX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95fe78f6-bb8c-43c7-8492-440f65340578"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": ""Sector(directions=3),Sector(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""LeftHandStickY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1b5f0aa-c3e1-4d65-b3b0-9d0cb1dc2a26"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": ""Sector(directions=2),Sector(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""LeftHandStickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e8431f3-e9c5-43ec-b6f6-b993395b931e"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""RightHandGrip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b09d477c-5c11-43a9-9c2e-33cacf07b2b2"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""RightHandButton1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""685158bf-5b30-473f-97ea-a3ff3bfcdbc7"",
                    ""path"": ""<XRController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""RightHandButton2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dbed59e-dcad-4dcf-9793-49ec252190f2"",
                    ""path"": ""<XRController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""LeftHandButton2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa17cf97-572e-443b-bbf2-295f66d9efdd"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""LeftHandButton1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21d0cb96-54a5-430c-b18f-953c466ac1c0"",
                    ""path"": ""<XRController>{LeftHand}/gripButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""LeftHandGrip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""4f5e1f37-0de1-4c3f-8e90-a8d07c47d289"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""9585d253-530c-463c-a5f8-9ac1f9126e45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d6a56937-7431-4a46-ad1e-c1624e265d4d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<TrackedDevice>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XRHMD>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Control
        m_Control = asset.FindActionMap("Control", throwIfNotFound: true);
        m_Control_LeftHandTrigger = m_Control.FindAction("LeftHandTrigger", throwIfNotFound: true);
        m_Control_LeftHandGrip = m_Control.FindAction("LeftHandGrip", throwIfNotFound: true);
        m_Control_LeftHandButton1 = m_Control.FindAction("LeftHandButton1", throwIfNotFound: true);
        m_Control_LeftHandButton2 = m_Control.FindAction("LeftHandButton2", throwIfNotFound: true);
        m_Control_LeftHandStick = m_Control.FindAction("LeftHandStick", throwIfNotFound: true);
        m_Control_LeftHandStickUp = m_Control.FindAction("LeftHandStickUp", throwIfNotFound: true);
        m_Control_LeftHandStickX = m_Control.FindAction("LeftHandStickX", throwIfNotFound: true);
        m_Control_LeftHandStickY = m_Control.FindAction("LeftHandStickY", throwIfNotFound: true);
        m_Control_LeftHandStickDown = m_Control.FindAction("LeftHandStickDown", throwIfNotFound: true);
        m_Control_RightHandTrigger = m_Control.FindAction("RightHandTrigger", throwIfNotFound: true);
        m_Control_RightHandGrip = m_Control.FindAction("RightHandGrip", throwIfNotFound: true);
        m_Control_RightHandButton1 = m_Control.FindAction("RightHandButton1", throwIfNotFound: true);
        m_Control_RightHandButton2 = m_Control.FindAction("RightHandButton2", throwIfNotFound: true);
        m_Control_RightHandStick = m_Control.FindAction("RightHandStick", throwIfNotFound: true);
        m_Control_RightHandStickUp = m_Control.FindAction("RightHandStickUp", throwIfNotFound: true);
        m_Control_RightHandStickX = m_Control.FindAction("RightHandStickX", throwIfNotFound: true);
        m_Control_RightHandStickY = m_Control.FindAction("RightHandStickY", throwIfNotFound: true);
        m_Control_RightHandStickDown = m_Control.FindAction("RightHandStickDown", throwIfNotFound: true);
        m_Control_RightHandTouchPad = m_Control.FindAction("RightHandTouchPad", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Newaction = m_UI.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
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

    // Control
    private readonly InputActionMap m_Control;
    private IControlActions m_ControlActionsCallbackInterface;
    private readonly InputAction m_Control_LeftHandTrigger;
    private readonly InputAction m_Control_LeftHandGrip;
    private readonly InputAction m_Control_LeftHandButton1;
    private readonly InputAction m_Control_LeftHandButton2;
    private readonly InputAction m_Control_LeftHandStick;
    private readonly InputAction m_Control_LeftHandStickUp;
    private readonly InputAction m_Control_LeftHandStickX;
    private readonly InputAction m_Control_LeftHandStickY;
    private readonly InputAction m_Control_LeftHandStickDown;
    private readonly InputAction m_Control_RightHandTrigger;
    private readonly InputAction m_Control_RightHandGrip;
    private readonly InputAction m_Control_RightHandButton1;
    private readonly InputAction m_Control_RightHandButton2;
    private readonly InputAction m_Control_RightHandStick;
    private readonly InputAction m_Control_RightHandStickUp;
    private readonly InputAction m_Control_RightHandStickX;
    private readonly InputAction m_Control_RightHandStickY;
    private readonly InputAction m_Control_RightHandStickDown;
    private readonly InputAction m_Control_RightHandTouchPad;
    public struct ControlActions
    {
        private @XRInputActions m_Wrapper;
        public ControlActions(@XRInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftHandTrigger => m_Wrapper.m_Control_LeftHandTrigger;
        public InputAction @LeftHandGrip => m_Wrapper.m_Control_LeftHandGrip;
        public InputAction @LeftHandButton1 => m_Wrapper.m_Control_LeftHandButton1;
        public InputAction @LeftHandButton2 => m_Wrapper.m_Control_LeftHandButton2;
        public InputAction @LeftHandStick => m_Wrapper.m_Control_LeftHandStick;
        public InputAction @LeftHandStickUp => m_Wrapper.m_Control_LeftHandStickUp;
        public InputAction @LeftHandStickX => m_Wrapper.m_Control_LeftHandStickX;
        public InputAction @LeftHandStickY => m_Wrapper.m_Control_LeftHandStickY;
        public InputAction @LeftHandStickDown => m_Wrapper.m_Control_LeftHandStickDown;
        public InputAction @RightHandTrigger => m_Wrapper.m_Control_RightHandTrigger;
        public InputAction @RightHandGrip => m_Wrapper.m_Control_RightHandGrip;
        public InputAction @RightHandButton1 => m_Wrapper.m_Control_RightHandButton1;
        public InputAction @RightHandButton2 => m_Wrapper.m_Control_RightHandButton2;
        public InputAction @RightHandStick => m_Wrapper.m_Control_RightHandStick;
        public InputAction @RightHandStickUp => m_Wrapper.m_Control_RightHandStickUp;
        public InputAction @RightHandStickX => m_Wrapper.m_Control_RightHandStickX;
        public InputAction @RightHandStickY => m_Wrapper.m_Control_RightHandStickY;
        public InputAction @RightHandStickDown => m_Wrapper.m_Control_RightHandStickDown;
        public InputAction @RightHandTouchPad => m_Wrapper.m_Control_RightHandTouchPad;
        public InputActionMap Get() { return m_Wrapper.m_Control; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlActions set) { return set.Get(); }
        public void SetCallbacks(IControlActions instance)
        {
            if (m_Wrapper.m_ControlActionsCallbackInterface != null)
            {
                @LeftHandTrigger.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandTrigger;
                @LeftHandTrigger.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandTrigger;
                @LeftHandTrigger.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandTrigger;
                @LeftHandGrip.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandGrip;
                @LeftHandGrip.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandGrip;
                @LeftHandGrip.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandGrip;
                @LeftHandButton1.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandButton1;
                @LeftHandButton1.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandButton1;
                @LeftHandButton1.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandButton1;
                @LeftHandButton2.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandButton2;
                @LeftHandButton2.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandButton2;
                @LeftHandButton2.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandButton2;
                @LeftHandStick.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStick;
                @LeftHandStick.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStick;
                @LeftHandStick.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStick;
                @LeftHandStickUp.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickUp;
                @LeftHandStickUp.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickUp;
                @LeftHandStickUp.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickUp;
                @LeftHandStickX.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickX;
                @LeftHandStickX.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickX;
                @LeftHandStickX.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickX;
                @LeftHandStickY.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickY;
                @LeftHandStickY.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickY;
                @LeftHandStickY.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickY;
                @LeftHandStickDown.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickDown;
                @LeftHandStickDown.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickDown;
                @LeftHandStickDown.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLeftHandStickDown;
                @RightHandTrigger.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandTrigger;
                @RightHandTrigger.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandTrigger;
                @RightHandTrigger.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandTrigger;
                @RightHandGrip.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandGrip;
                @RightHandGrip.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandGrip;
                @RightHandGrip.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandGrip;
                @RightHandButton1.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandButton1;
                @RightHandButton1.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandButton1;
                @RightHandButton1.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandButton1;
                @RightHandButton2.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandButton2;
                @RightHandButton2.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandButton2;
                @RightHandButton2.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandButton2;
                @RightHandStick.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStick;
                @RightHandStick.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStick;
                @RightHandStick.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStick;
                @RightHandStickUp.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickUp;
                @RightHandStickUp.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickUp;
                @RightHandStickUp.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickUp;
                @RightHandStickX.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickX;
                @RightHandStickX.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickX;
                @RightHandStickX.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickX;
                @RightHandStickY.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickY;
                @RightHandStickY.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickY;
                @RightHandStickY.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickY;
                @RightHandStickDown.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickDown;
                @RightHandStickDown.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickDown;
                @RightHandStickDown.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandStickDown;
                @RightHandTouchPad.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandTouchPad;
                @RightHandTouchPad.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandTouchPad;
                @RightHandTouchPad.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnRightHandTouchPad;
            }
            m_Wrapper.m_ControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftHandTrigger.started += instance.OnLeftHandTrigger;
                @LeftHandTrigger.performed += instance.OnLeftHandTrigger;
                @LeftHandTrigger.canceled += instance.OnLeftHandTrigger;
                @LeftHandGrip.started += instance.OnLeftHandGrip;
                @LeftHandGrip.performed += instance.OnLeftHandGrip;
                @LeftHandGrip.canceled += instance.OnLeftHandGrip;
                @LeftHandButton1.started += instance.OnLeftHandButton1;
                @LeftHandButton1.performed += instance.OnLeftHandButton1;
                @LeftHandButton1.canceled += instance.OnLeftHandButton1;
                @LeftHandButton2.started += instance.OnLeftHandButton2;
                @LeftHandButton2.performed += instance.OnLeftHandButton2;
                @LeftHandButton2.canceled += instance.OnLeftHandButton2;
                @LeftHandStick.started += instance.OnLeftHandStick;
                @LeftHandStick.performed += instance.OnLeftHandStick;
                @LeftHandStick.canceled += instance.OnLeftHandStick;
                @LeftHandStickUp.started += instance.OnLeftHandStickUp;
                @LeftHandStickUp.performed += instance.OnLeftHandStickUp;
                @LeftHandStickUp.canceled += instance.OnLeftHandStickUp;
                @LeftHandStickX.started += instance.OnLeftHandStickX;
                @LeftHandStickX.performed += instance.OnLeftHandStickX;
                @LeftHandStickX.canceled += instance.OnLeftHandStickX;
                @LeftHandStickY.started += instance.OnLeftHandStickY;
                @LeftHandStickY.performed += instance.OnLeftHandStickY;
                @LeftHandStickY.canceled += instance.OnLeftHandStickY;
                @LeftHandStickDown.started += instance.OnLeftHandStickDown;
                @LeftHandStickDown.performed += instance.OnLeftHandStickDown;
                @LeftHandStickDown.canceled += instance.OnLeftHandStickDown;
                @RightHandTrigger.started += instance.OnRightHandTrigger;
                @RightHandTrigger.performed += instance.OnRightHandTrigger;
                @RightHandTrigger.canceled += instance.OnRightHandTrigger;
                @RightHandGrip.started += instance.OnRightHandGrip;
                @RightHandGrip.performed += instance.OnRightHandGrip;
                @RightHandGrip.canceled += instance.OnRightHandGrip;
                @RightHandButton1.started += instance.OnRightHandButton1;
                @RightHandButton1.performed += instance.OnRightHandButton1;
                @RightHandButton1.canceled += instance.OnRightHandButton1;
                @RightHandButton2.started += instance.OnRightHandButton2;
                @RightHandButton2.performed += instance.OnRightHandButton2;
                @RightHandButton2.canceled += instance.OnRightHandButton2;
                @RightHandStick.started += instance.OnRightHandStick;
                @RightHandStick.performed += instance.OnRightHandStick;
                @RightHandStick.canceled += instance.OnRightHandStick;
                @RightHandStickUp.started += instance.OnRightHandStickUp;
                @RightHandStickUp.performed += instance.OnRightHandStickUp;
                @RightHandStickUp.canceled += instance.OnRightHandStickUp;
                @RightHandStickX.started += instance.OnRightHandStickX;
                @RightHandStickX.performed += instance.OnRightHandStickX;
                @RightHandStickX.canceled += instance.OnRightHandStickX;
                @RightHandStickY.started += instance.OnRightHandStickY;
                @RightHandStickY.performed += instance.OnRightHandStickY;
                @RightHandStickY.canceled += instance.OnRightHandStickY;
                @RightHandStickDown.started += instance.OnRightHandStickDown;
                @RightHandStickDown.performed += instance.OnRightHandStickDown;
                @RightHandStickDown.canceled += instance.OnRightHandStickDown;
                @RightHandTouchPad.started += instance.OnRightHandTouchPad;
                @RightHandTouchPad.performed += instance.OnRightHandTouchPad;
                @RightHandTouchPad.canceled += instance.OnRightHandTouchPad;
            }
        }
    }
    public ControlActions @Control => new ControlActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Newaction;
    public struct UIActions
    {
        private @XRInputActions m_Wrapper;
        public UIActions(@XRInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IControlActions
    {
        void OnLeftHandTrigger(InputAction.CallbackContext context);
        void OnLeftHandGrip(InputAction.CallbackContext context);
        void OnLeftHandButton1(InputAction.CallbackContext context);
        void OnLeftHandButton2(InputAction.CallbackContext context);
        void OnLeftHandStick(InputAction.CallbackContext context);
        void OnLeftHandStickUp(InputAction.CallbackContext context);
        void OnLeftHandStickX(InputAction.CallbackContext context);
        void OnLeftHandStickY(InputAction.CallbackContext context);
        void OnLeftHandStickDown(InputAction.CallbackContext context);
        void OnRightHandTrigger(InputAction.CallbackContext context);
        void OnRightHandGrip(InputAction.CallbackContext context);
        void OnRightHandButton1(InputAction.CallbackContext context);
        void OnRightHandButton2(InputAction.CallbackContext context);
        void OnRightHandStick(InputAction.CallbackContext context);
        void OnRightHandStickUp(InputAction.CallbackContext context);
        void OnRightHandStickX(InputAction.CallbackContext context);
        void OnRightHandStickY(InputAction.CallbackContext context);
        void OnRightHandStickDown(InputAction.CallbackContext context);
        void OnRightHandTouchPad(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
