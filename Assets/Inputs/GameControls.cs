//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Inputs/GameControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Standard"",
            ""id"": ""84951fb9-a143-4f6a-ab31-511a3fd3d423"",
            ""actions"": [
                {
                    ""name"": ""ShootBullet"",
                    ""type"": ""Button"",
                    ""id"": ""39bdf5b1-16f9-4f33-b012-7941f9824ab1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FlyUp"",
                    ""type"": ""Value"",
                    ""id"": ""48c642f0-35e6-4af3-8a5b-20cfa9a7ca50"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FlyDown"",
                    ""type"": ""Value"",
                    ""id"": ""6c8bebd2-357f-42a8-99ba-6075ce0f2417"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FlyRight"",
                    ""type"": ""Value"",
                    ""id"": ""ab917ff4-74a7-464c-957b-7bcf229221b5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FlyLeft"",
                    ""type"": ""Value"",
                    ""id"": ""cfd4a8b4-9a2c-44f6-bc04-88a8605aa0d1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""5914fc76-3920-42eb-b7d1-74b37ab971d7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShootTorpedo"",
                    ""type"": ""Button"",
                    ""id"": ""b2099a83-905a-4cae-a46f-214c48a6e5f5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DevSpawnDrone"",
                    ""type"": ""Button"",
                    ""id"": ""204b849e-5861-4814-9afa-d7af0b7c00e1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f3064b8d-36cf-495e-bdf7-f4e5fa507df2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootBullet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f912fc53-952b-434d-a2f9-2b3795f4f6da"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8be1ac64-ff81-4d7f-9e9d-90af565e773f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05f77d96-a9f0-4b07-9b31-8e70874f5f88"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b02027dc-b77f-4eb3-a525-d74f7e142e75"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""825116a7-21a6-4ade-ad9a-4f1519c4696d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25753908-5833-4403-a073-ba44cb23b5ee"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0e6412c-be5e-4c46-ac43-fadb0f5ca989"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3528e21-1de6-42c3-8171-26766ca29fc8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2cf457c9-e20d-4f48-bfd1-01505d7aea03"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""238918b6-84cb-41f3-ab79-9700ddb8e670"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootTorpedo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""1f46a86b-29cb-4405-be20-2897c5a42bf4"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootTorpedo"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""591518d6-9595-4375-b482-97bafa826473"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootTorpedo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""b3774175-2493-4a30-8af9-c2991d66a22c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootTorpedo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""4cb659cb-167e-4cae-b1a5-2c3ddab2fa3b"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootTorpedo"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""a7a76cc5-2eac-42ef-94fd-98cc44923450"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootTorpedo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""6a5a05dd-ee13-46c6-9ef9-baab45ee343c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootTorpedo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c528a9dc-9789-45d9-a8c6-2610a854c4c1"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DevSpawnDrone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Standard
        m_Standard = asset.FindActionMap("Standard", throwIfNotFound: true);
        m_Standard_ShootBullet = m_Standard.FindAction("ShootBullet", throwIfNotFound: true);
        m_Standard_FlyUp = m_Standard.FindAction("FlyUp", throwIfNotFound: true);
        m_Standard_FlyDown = m_Standard.FindAction("FlyDown", throwIfNotFound: true);
        m_Standard_FlyRight = m_Standard.FindAction("FlyRight", throwIfNotFound: true);
        m_Standard_FlyLeft = m_Standard.FindAction("FlyLeft", throwIfNotFound: true);
        m_Standard_Left = m_Standard.FindAction("Left", throwIfNotFound: true);
        m_Standard_ShootTorpedo = m_Standard.FindAction("ShootTorpedo", throwIfNotFound: true);
        m_Standard_DevSpawnDrone = m_Standard.FindAction("DevSpawnDrone", throwIfNotFound: true);
    }

    ~@GameControls()
    {
        UnityEngine.Debug.Assert(!m_Standard.enabled, "This will cause a leak and performance issues, GameControls.Standard.Disable() has not been called.");
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Standard
    private readonly InputActionMap m_Standard;
    private List<IStandardActions> m_StandardActionsCallbackInterfaces = new List<IStandardActions>();
    private readonly InputAction m_Standard_ShootBullet;
    private readonly InputAction m_Standard_FlyUp;
    private readonly InputAction m_Standard_FlyDown;
    private readonly InputAction m_Standard_FlyRight;
    private readonly InputAction m_Standard_FlyLeft;
    private readonly InputAction m_Standard_Left;
    private readonly InputAction m_Standard_ShootTorpedo;
    private readonly InputAction m_Standard_DevSpawnDrone;
    public struct StandardActions
    {
        private @GameControls m_Wrapper;
        public StandardActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ShootBullet => m_Wrapper.m_Standard_ShootBullet;
        public InputAction @FlyUp => m_Wrapper.m_Standard_FlyUp;
        public InputAction @FlyDown => m_Wrapper.m_Standard_FlyDown;
        public InputAction @FlyRight => m_Wrapper.m_Standard_FlyRight;
        public InputAction @FlyLeft => m_Wrapper.m_Standard_FlyLeft;
        public InputAction @Left => m_Wrapper.m_Standard_Left;
        public InputAction @ShootTorpedo => m_Wrapper.m_Standard_ShootTorpedo;
        public InputAction @DevSpawnDrone => m_Wrapper.m_Standard_DevSpawnDrone;
        public InputActionMap Get() { return m_Wrapper.m_Standard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StandardActions set) { return set.Get(); }
        public void AddCallbacks(IStandardActions instance)
        {
            if (instance == null || m_Wrapper.m_StandardActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_StandardActionsCallbackInterfaces.Add(instance);
            @ShootBullet.started += instance.OnShootBullet;
            @ShootBullet.performed += instance.OnShootBullet;
            @ShootBullet.canceled += instance.OnShootBullet;
            @FlyUp.started += instance.OnFlyUp;
            @FlyUp.performed += instance.OnFlyUp;
            @FlyUp.canceled += instance.OnFlyUp;
            @FlyDown.started += instance.OnFlyDown;
            @FlyDown.performed += instance.OnFlyDown;
            @FlyDown.canceled += instance.OnFlyDown;
            @FlyRight.started += instance.OnFlyRight;
            @FlyRight.performed += instance.OnFlyRight;
            @FlyRight.canceled += instance.OnFlyRight;
            @FlyLeft.started += instance.OnFlyLeft;
            @FlyLeft.performed += instance.OnFlyLeft;
            @FlyLeft.canceled += instance.OnFlyLeft;
            @Left.started += instance.OnLeft;
            @Left.performed += instance.OnLeft;
            @Left.canceled += instance.OnLeft;
            @ShootTorpedo.started += instance.OnShootTorpedo;
            @ShootTorpedo.performed += instance.OnShootTorpedo;
            @ShootTorpedo.canceled += instance.OnShootTorpedo;
            @DevSpawnDrone.started += instance.OnDevSpawnDrone;
            @DevSpawnDrone.performed += instance.OnDevSpawnDrone;
            @DevSpawnDrone.canceled += instance.OnDevSpawnDrone;
        }

        private void UnregisterCallbacks(IStandardActions instance)
        {
            @ShootBullet.started -= instance.OnShootBullet;
            @ShootBullet.performed -= instance.OnShootBullet;
            @ShootBullet.canceled -= instance.OnShootBullet;
            @FlyUp.started -= instance.OnFlyUp;
            @FlyUp.performed -= instance.OnFlyUp;
            @FlyUp.canceled -= instance.OnFlyUp;
            @FlyDown.started -= instance.OnFlyDown;
            @FlyDown.performed -= instance.OnFlyDown;
            @FlyDown.canceled -= instance.OnFlyDown;
            @FlyRight.started -= instance.OnFlyRight;
            @FlyRight.performed -= instance.OnFlyRight;
            @FlyRight.canceled -= instance.OnFlyRight;
            @FlyLeft.started -= instance.OnFlyLeft;
            @FlyLeft.performed -= instance.OnFlyLeft;
            @FlyLeft.canceled -= instance.OnFlyLeft;
            @Left.started -= instance.OnLeft;
            @Left.performed -= instance.OnLeft;
            @Left.canceled -= instance.OnLeft;
            @ShootTorpedo.started -= instance.OnShootTorpedo;
            @ShootTorpedo.performed -= instance.OnShootTorpedo;
            @ShootTorpedo.canceled -= instance.OnShootTorpedo;
            @DevSpawnDrone.started -= instance.OnDevSpawnDrone;
            @DevSpawnDrone.performed -= instance.OnDevSpawnDrone;
            @DevSpawnDrone.canceled -= instance.OnDevSpawnDrone;
        }

        public void RemoveCallbacks(IStandardActions instance)
        {
            if (m_Wrapper.m_StandardActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IStandardActions instance)
        {
            foreach (var item in m_Wrapper.m_StandardActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_StandardActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public StandardActions @Standard => new StandardActions(this);
    public interface IStandardActions
    {
        void OnShootBullet(InputAction.CallbackContext context);
        void OnFlyUp(InputAction.CallbackContext context);
        void OnFlyDown(InputAction.CallbackContext context);
        void OnFlyRight(InputAction.CallbackContext context);
        void OnFlyLeft(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnShootTorpedo(InputAction.CallbackContext context);
        void OnDevSpawnDrone(InputAction.CallbackContext context);
    }
}
