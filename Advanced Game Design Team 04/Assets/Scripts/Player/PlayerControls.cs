//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Player/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""0cc6a9dc-6d30-41d3-b3fa-c42ab1982acd"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c406eaeb-e19e-449d-a22b-68cd8dcf5d4f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""549f01df-f60e-40fe-88bc-dac9187d1bdf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shotgun"",
                    ""type"": ""Button"",
                    ""id"": ""ae874865-3374-48ba-8768-b9ec4e71c1ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""ad45dc9b-5f92-48d2-8dea-1fe90e282224"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchForm"",
                    ""type"": ""Button"",
                    ""id"": ""6ba279e0-4038-48cc-a2c1-6ca4b86d7b5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LevelUp"",
                    ""type"": ""Button"",
                    ""id"": ""adbaa4c1-21b4-42fb-87b5-65c9cda94b65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slam"",
                    ""type"": ""Button"",
                    ""id"": ""b4bbcdb8-b0ab-4a62-97bf-7da1a45426db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a31a1fb6-b73c-4286-873d-7ec693099ecc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b6346cf8-8cc4-416e-889f-c87443e38f15"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""74369c1d-f862-42ba-a149-ca5d182225d3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dc6aa052-3156-4123-adee-9c63dfaa3393"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ac51ea5e-231d-4855-9c98-8fd7c76ff2f6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b86d4441-4d11-4736-a759-2e2d95e6b99d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""99563b98-fcf1-4054-ba12-0f5803084bbe"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eba25cca-7cbc-4fa7-ad03-b57e3e689645"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shotgun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98f07d56-5c69-496f-9e16-0e96a0222868"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Shotgun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d29a0ae2-a346-4ae4-b3cd-20451130f514"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d972a952-2c33-4f0e-81d9-812818890b2a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c3a07b9-f833-43d5-94f3-1afe51a79874"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""SwitchForm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e9c8d05-1a41-47e5-9317-12d8ee6b62fb"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SwitchForm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56a91fbe-f930-405b-9468-1f1067cbe4e8"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LevelUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd924d14-20c1-449b-b0ac-8e234f9b17d8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialogue"",
            ""id"": ""6de163ed-6a89-4051-b73b-9c4386832bdc"",
            ""actions"": [
                {
                    ""name"": ""Appear"",
                    ""type"": ""Button"",
                    ""id"": ""69788167-c5a6-4e4d-83ee-64fefabc6918"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5bb93b27-ea40-474d-8fc5-dd2733da8526"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Appear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a966aef5-eebe-4695-aef8-6d0b66bb7dd1"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Appear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KBM"",
            ""bindingGroup"": ""KBM"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_Movement = m_Controls.FindAction("Movement", throwIfNotFound: true);
        m_Controls_Aim = m_Controls.FindAction("Aim", throwIfNotFound: true);
        m_Controls_Shotgun = m_Controls.FindAction("Shotgun", throwIfNotFound: true);
        m_Controls_Dash = m_Controls.FindAction("Dash", throwIfNotFound: true);
        m_Controls_SwitchForm = m_Controls.FindAction("SwitchForm", throwIfNotFound: true);
        m_Controls_LevelUp = m_Controls.FindAction("LevelUp", throwIfNotFound: true);
        m_Controls_Slam = m_Controls.FindAction("Slam", throwIfNotFound: true);
        // Dialogue
        m_Dialogue = asset.FindActionMap("Dialogue", throwIfNotFound: true);
        m_Dialogue_Appear = m_Dialogue.FindAction("Appear", throwIfNotFound: true);
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

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_Movement;
    private readonly InputAction m_Controls_Aim;
    private readonly InputAction m_Controls_Shotgun;
    private readonly InputAction m_Controls_Dash;
    private readonly InputAction m_Controls_SwitchForm;
    private readonly InputAction m_Controls_LevelUp;
    private readonly InputAction m_Controls_Slam;
    public struct ControlsActions
    {
        private @PlayerControls m_Wrapper;
        public ControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Controls_Movement;
        public InputAction @Aim => m_Wrapper.m_Controls_Aim;
        public InputAction @Shotgun => m_Wrapper.m_Controls_Shotgun;
        public InputAction @Dash => m_Wrapper.m_Controls_Dash;
        public InputAction @SwitchForm => m_Wrapper.m_Controls_SwitchForm;
        public InputAction @LevelUp => m_Wrapper.m_Controls_LevelUp;
        public InputAction @Slam => m_Wrapper.m_Controls_Slam;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
                @Aim.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAim;
                @Shotgun.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnShotgun;
                @Shotgun.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnShotgun;
                @Shotgun.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnShotgun;
                @Dash.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDash;
                @SwitchForm.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSwitchForm;
                @SwitchForm.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSwitchForm;
                @SwitchForm.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSwitchForm;
                @LevelUp.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLevelUp;
                @LevelUp.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLevelUp;
                @LevelUp.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLevelUp;
                @Slam.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSlam;
                @Slam.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSlam;
                @Slam.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSlam;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shotgun.started += instance.OnShotgun;
                @Shotgun.performed += instance.OnShotgun;
                @Shotgun.canceled += instance.OnShotgun;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @SwitchForm.started += instance.OnSwitchForm;
                @SwitchForm.performed += instance.OnSwitchForm;
                @SwitchForm.canceled += instance.OnSwitchForm;
                @LevelUp.started += instance.OnLevelUp;
                @LevelUp.performed += instance.OnLevelUp;
                @LevelUp.canceled += instance.OnLevelUp;
                @Slam.started += instance.OnSlam;
                @Slam.performed += instance.OnSlam;
                @Slam.canceled += instance.OnSlam;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);

    // Dialogue
    private readonly InputActionMap m_Dialogue;
    private IDialogueActions m_DialogueActionsCallbackInterface;
    private readonly InputAction m_Dialogue_Appear;
    public struct DialogueActions
    {
        private @PlayerControls m_Wrapper;
        public DialogueActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Appear => m_Wrapper.m_Dialogue_Appear;
        public InputActionMap Get() { return m_Wrapper.m_Dialogue; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogueActions set) { return set.Get(); }
        public void SetCallbacks(IDialogueActions instance)
        {
            if (m_Wrapper.m_DialogueActionsCallbackInterface != null)
            {
                @Appear.started -= m_Wrapper.m_DialogueActionsCallbackInterface.OnAppear;
                @Appear.performed -= m_Wrapper.m_DialogueActionsCallbackInterface.OnAppear;
                @Appear.canceled -= m_Wrapper.m_DialogueActionsCallbackInterface.OnAppear;
            }
            m_Wrapper.m_DialogueActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Appear.started += instance.OnAppear;
                @Appear.performed += instance.OnAppear;
                @Appear.canceled += instance.OnAppear;
            }
        }
    }
    public DialogueActions @Dialogue => new DialogueActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KBM");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    public interface IControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShotgun(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnSwitchForm(InputAction.CallbackContext context);
        void OnLevelUp(InputAction.CallbackContext context);
        void OnSlam(InputAction.CallbackContext context);
    }
    public interface IDialogueActions
    {
        void OnAppear(InputAction.CallbackContext context);
    }
}
