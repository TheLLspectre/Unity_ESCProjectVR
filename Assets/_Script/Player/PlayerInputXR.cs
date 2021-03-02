// GENERATED AUTOMATICALLY FROM 'Assets/_Prefab/Input/PlayerInputXR.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputXR : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputXR()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputXR"",
    ""maps"": [
        {
            ""name"": ""XRControl"",
            ""id"": ""ad075c83-4bb2-40a7-8699-4196f846d689"",
            ""actions"": [
                {
                    ""name"": ""LeftHandTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""1519717b-50a3-41fb-9c1b-b94084fda103"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandGrip"",
                    ""type"": ""Button"",
                    ""id"": ""66046a79-bb21-437b-b043-01e87b8c2d84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandButton1"",
                    ""type"": ""Button"",
                    ""id"": ""c3c51b2d-5a07-4d59-bbfd-a9445a87e623"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandButton2"",
                    ""type"": ""Button"",
                    ""id"": ""86f9e9bc-e3a4-477c-ae2a-765b8dd79dac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandStick"",
                    ""type"": ""Value"",
                    ""id"": ""17417c30-6d17-4121-aa83-6e16535fcbe6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandStickUp"",
                    ""type"": ""Value"",
                    ""id"": ""8ab4cde8-4599-4baa-8808-4c4c5e47f68e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandStickX"",
                    ""type"": ""Value"",
                    ""id"": ""5787eb44-9068-4b0f-bf82-bd5009e2d733"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandStickY"",
                    ""type"": ""Value"",
                    ""id"": ""f9629c31-d3fc-4165-a152-5e6448c5a02f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandStickDown"",
                    ""type"": ""Value"",
                    ""id"": ""2057cc90-86f5-45f9-a620-23f67f160c88"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""171c0cb1-6fa3-4d35-a0e6-9d934ff2dd17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandGrip"",
                    ""type"": ""Button"",
                    ""id"": ""a9b73f15-68cc-4e5b-a535-39e913b78e4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandButton1"",
                    ""type"": ""Button"",
                    ""id"": ""a940a569-5854-4081-84c9-23ba1af2b4a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandButton2"",
                    ""type"": ""Button"",
                    ""id"": ""0c0f94a1-efc5-44ca-850a-04b0c9135a1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandStick"",
                    ""type"": ""Value"",
                    ""id"": ""490543da-2ce8-4771-ae41-c914041b4d67"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandStickUp"",
                    ""type"": ""Value"",
                    ""id"": ""c1a52c45-9350-4cb5-b82a-195c3a2feb5b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandStickX"",
                    ""type"": ""Value"",
                    ""id"": ""544c0f9e-7f2d-4ccb-af86-18d35f05986e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandStickY"",
                    ""type"": ""Value"",
                    ""id"": ""1e322fea-eafd-4afa-9933-2a2e0376a421"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandStickDown"",
                    ""type"": ""Value"",
                    ""id"": ""2dd8daf2-a758-45b7-a4d4-8d8a9289a16b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandTouchPad"",
                    ""type"": ""Value"",
                    ""id"": ""8ece29d7-6300-48b6-9e87-e18ea677d240"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2,ScaleVector2,StickDeadzone(max=1)"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""721fc944-3878-4135-8e2b-4a600519d29b"",
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
                    ""id"": ""f2f77e9d-bbc8-42f6-b16b-1aeb537fcc9b"",
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
                    ""id"": ""fd27dbc3-0f0c-405b-bf74-e4152ac27966"",
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
                    ""id"": ""fa4f6338-ddfb-4866-8fd0-fc81cdaf856b"",
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
                    ""id"": ""0ed24d31-dc01-46d5-933a-adfe8566b7b1"",
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
                    ""id"": ""f3d69d0b-585e-48ef-a44c-b1e3477465c6"",
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
                    ""id"": ""01903432-8d7b-4659-b046-1d48abb247dc"",
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
                    ""id"": ""b7283db7-6c21-4d22-835c-d0536aad4a20"",
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
                    ""id"": ""976a98e0-4b0c-4926-832e-afb2c659927d"",
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
                    ""id"": ""47c1ea37-c6c2-4169-8842-30d1fbeb5ab4"",
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
                    ""id"": ""547d6680-f214-454f-8bbe-ae4cf1b3b678"",
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
                    ""id"": ""7a389635-e5ee-4991-a345-6aff2f8faefe"",
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
                    ""id"": ""611332c7-5b14-4a06-b1d0-6bdbdd2f596c"",
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
                    ""id"": ""751b3efb-9b19-412a-8f98-b3c687fad514"",
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
                    ""id"": ""bb2b57df-cb61-4166-95ce-8d823956548f"",
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
                    ""id"": ""592eb88c-9607-4bc8-ba45-4e88b93fbea8"",
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
                    ""id"": ""5ed2b8b8-4a8c-4936-aab3-b4388b2f3006"",
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
                    ""id"": ""ab42be97-14e1-407d-945b-6fa80facecca"",
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
                    ""id"": ""fd4b3327-7cea-4f0f-99b9-ffac2b129951"",
                    ""path"": ""<XRController>{LeftHand}/gripButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""LeftHandGrip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // XRControl
        m_XRControl = asset.FindActionMap("XRControl", throwIfNotFound: true);
        m_XRControl_LeftHandTrigger = m_XRControl.FindAction("LeftHandTrigger", throwIfNotFound: true);
        m_XRControl_LeftHandGrip = m_XRControl.FindAction("LeftHandGrip", throwIfNotFound: true);
        m_XRControl_LeftHandButton1 = m_XRControl.FindAction("LeftHandButton1", throwIfNotFound: true);
        m_XRControl_LeftHandButton2 = m_XRControl.FindAction("LeftHandButton2", throwIfNotFound: true);
        m_XRControl_LeftHandStick = m_XRControl.FindAction("LeftHandStick", throwIfNotFound: true);
        m_XRControl_LeftHandStickUp = m_XRControl.FindAction("LeftHandStickUp", throwIfNotFound: true);
        m_XRControl_LeftHandStickX = m_XRControl.FindAction("LeftHandStickX", throwIfNotFound: true);
        m_XRControl_LeftHandStickY = m_XRControl.FindAction("LeftHandStickY", throwIfNotFound: true);
        m_XRControl_LeftHandStickDown = m_XRControl.FindAction("LeftHandStickDown", throwIfNotFound: true);
        m_XRControl_RightHandTrigger = m_XRControl.FindAction("RightHandTrigger", throwIfNotFound: true);
        m_XRControl_RightHandGrip = m_XRControl.FindAction("RightHandGrip", throwIfNotFound: true);
        m_XRControl_RightHandButton1 = m_XRControl.FindAction("RightHandButton1", throwIfNotFound: true);
        m_XRControl_RightHandButton2 = m_XRControl.FindAction("RightHandButton2", throwIfNotFound: true);
        m_XRControl_RightHandStick = m_XRControl.FindAction("RightHandStick", throwIfNotFound: true);
        m_XRControl_RightHandStickUp = m_XRControl.FindAction("RightHandStickUp", throwIfNotFound: true);
        m_XRControl_RightHandStickX = m_XRControl.FindAction("RightHandStickX", throwIfNotFound: true);
        m_XRControl_RightHandStickY = m_XRControl.FindAction("RightHandStickY", throwIfNotFound: true);
        m_XRControl_RightHandStickDown = m_XRControl.FindAction("RightHandStickDown", throwIfNotFound: true);
        m_XRControl_RightHandTouchPad = m_XRControl.FindAction("RightHandTouchPad", throwIfNotFound: true);
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

    // XRControl
    private readonly InputActionMap m_XRControl;
    private IXRControlActions m_XRControlActionsCallbackInterface;
    private readonly InputAction m_XRControl_LeftHandTrigger;
    private readonly InputAction m_XRControl_LeftHandGrip;
    private readonly InputAction m_XRControl_LeftHandButton1;
    private readonly InputAction m_XRControl_LeftHandButton2;
    private readonly InputAction m_XRControl_LeftHandStick;
    private readonly InputAction m_XRControl_LeftHandStickUp;
    private readonly InputAction m_XRControl_LeftHandStickX;
    private readonly InputAction m_XRControl_LeftHandStickY;
    private readonly InputAction m_XRControl_LeftHandStickDown;
    private readonly InputAction m_XRControl_RightHandTrigger;
    private readonly InputAction m_XRControl_RightHandGrip;
    private readonly InputAction m_XRControl_RightHandButton1;
    private readonly InputAction m_XRControl_RightHandButton2;
    private readonly InputAction m_XRControl_RightHandStick;
    private readonly InputAction m_XRControl_RightHandStickUp;
    private readonly InputAction m_XRControl_RightHandStickX;
    private readonly InputAction m_XRControl_RightHandStickY;
    private readonly InputAction m_XRControl_RightHandStickDown;
    private readonly InputAction m_XRControl_RightHandTouchPad;
    public struct XRControlActions
    {
        private @PlayerInputXR m_Wrapper;
        public XRControlActions(@PlayerInputXR wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftHandTrigger => m_Wrapper.m_XRControl_LeftHandTrigger;
        public InputAction @LeftHandGrip => m_Wrapper.m_XRControl_LeftHandGrip;
        public InputAction @LeftHandButton1 => m_Wrapper.m_XRControl_LeftHandButton1;
        public InputAction @LeftHandButton2 => m_Wrapper.m_XRControl_LeftHandButton2;
        public InputAction @LeftHandStick => m_Wrapper.m_XRControl_LeftHandStick;
        public InputAction @LeftHandStickUp => m_Wrapper.m_XRControl_LeftHandStickUp;
        public InputAction @LeftHandStickX => m_Wrapper.m_XRControl_LeftHandStickX;
        public InputAction @LeftHandStickY => m_Wrapper.m_XRControl_LeftHandStickY;
        public InputAction @LeftHandStickDown => m_Wrapper.m_XRControl_LeftHandStickDown;
        public InputAction @RightHandTrigger => m_Wrapper.m_XRControl_RightHandTrigger;
        public InputAction @RightHandGrip => m_Wrapper.m_XRControl_RightHandGrip;
        public InputAction @RightHandButton1 => m_Wrapper.m_XRControl_RightHandButton1;
        public InputAction @RightHandButton2 => m_Wrapper.m_XRControl_RightHandButton2;
        public InputAction @RightHandStick => m_Wrapper.m_XRControl_RightHandStick;
        public InputAction @RightHandStickUp => m_Wrapper.m_XRControl_RightHandStickUp;
        public InputAction @RightHandStickX => m_Wrapper.m_XRControl_RightHandStickX;
        public InputAction @RightHandStickY => m_Wrapper.m_XRControl_RightHandStickY;
        public InputAction @RightHandStickDown => m_Wrapper.m_XRControl_RightHandStickDown;
        public InputAction @RightHandTouchPad => m_Wrapper.m_XRControl_RightHandTouchPad;
        public InputActionMap Get() { return m_Wrapper.m_XRControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(XRControlActions set) { return set.Get(); }
        public void SetCallbacks(IXRControlActions instance)
        {
            if (m_Wrapper.m_XRControlActionsCallbackInterface != null)
            {
                @LeftHandTrigger.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandTrigger;
                @LeftHandTrigger.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandTrigger;
                @LeftHandTrigger.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandTrigger;
                @LeftHandGrip.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandGrip;
                @LeftHandGrip.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandGrip;
                @LeftHandGrip.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandGrip;
                @LeftHandButton1.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandButton1;
                @LeftHandButton1.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandButton1;
                @LeftHandButton1.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandButton1;
                @LeftHandButton2.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandButton2;
                @LeftHandButton2.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandButton2;
                @LeftHandButton2.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandButton2;
                @LeftHandStick.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStick;
                @LeftHandStick.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStick;
                @LeftHandStick.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStick;
                @LeftHandStickUp.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickUp;
                @LeftHandStickUp.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickUp;
                @LeftHandStickUp.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickUp;
                @LeftHandStickX.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickX;
                @LeftHandStickX.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickX;
                @LeftHandStickX.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickX;
                @LeftHandStickY.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickY;
                @LeftHandStickY.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickY;
                @LeftHandStickY.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickY;
                @LeftHandStickDown.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickDown;
                @LeftHandStickDown.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickDown;
                @LeftHandStickDown.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnLeftHandStickDown;
                @RightHandTrigger.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandTrigger;
                @RightHandTrigger.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandTrigger;
                @RightHandTrigger.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandTrigger;
                @RightHandGrip.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandGrip;
                @RightHandGrip.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandGrip;
                @RightHandGrip.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandGrip;
                @RightHandButton1.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandButton1;
                @RightHandButton1.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandButton1;
                @RightHandButton1.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandButton1;
                @RightHandButton2.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandButton2;
                @RightHandButton2.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandButton2;
                @RightHandButton2.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandButton2;
                @RightHandStick.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStick;
                @RightHandStick.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStick;
                @RightHandStick.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStick;
                @RightHandStickUp.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickUp;
                @RightHandStickUp.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickUp;
                @RightHandStickUp.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickUp;
                @RightHandStickX.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickX;
                @RightHandStickX.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickX;
                @RightHandStickX.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickX;
                @RightHandStickY.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickY;
                @RightHandStickY.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickY;
                @RightHandStickY.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickY;
                @RightHandStickDown.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickDown;
                @RightHandStickDown.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickDown;
                @RightHandStickDown.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandStickDown;
                @RightHandTouchPad.started -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandTouchPad;
                @RightHandTouchPad.performed -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandTouchPad;
                @RightHandTouchPad.canceled -= m_Wrapper.m_XRControlActionsCallbackInterface.OnRightHandTouchPad;
            }
            m_Wrapper.m_XRControlActionsCallbackInterface = instance;
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
    public XRControlActions @XRControl => new XRControlActions(this);
    public interface IXRControlActions
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
}
