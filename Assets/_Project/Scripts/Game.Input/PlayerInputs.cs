// GENERATED AUTOMATICALLY FROM 'Assets/_Project/InputActions/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Game.Input
{
    public class @PlayerInputs : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""LandControls"",
            ""id"": ""fe9aace5-7b74-4ebe-a521-7ce69750fc80"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""2b368520-9ca5-4163-a94e-60fb8494831c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b8609bad-25e8-4e4b-af8c-2dc2204a0113"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ad162ded-3933-4e87-a42b-ab0f5f712b65"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""da8ce536-a6ca-4a7b-940c-3a0b891eefb0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""e498551a-d69a-4bd8-9b5e-0b128b763a57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseItem"",
                    ""type"": ""Button"",
                    ""id"": ""db8316c1-324a-4367-aa3f-7117758a0728"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""c89ee431-332c-4158-b816-9b5abb6980cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ThrowObject"",
                    ""type"": ""Button"",
                    ""id"": ""a85b944f-761f-476a-9788-73ddc7bae54c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""429bdcbc-a458-4d56-9f47-2d33be987c88"",
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
                    ""id"": ""6dbe40f5-b4df-4a44-a3f0-a2d7d43cd5a9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""45e87b48-148a-4180-acf4-2fb4b3bda26d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cbe6fd49-d10d-4b04-92a2-d77b3beca822"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""de0dda19-9b61-4387-ae98-50c6bc1ed0b2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""92a9b1cc-2213-4128-8ab3-166d98745008"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57c31fe9-847d-4a72-af12-2928a4df5c8d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06d25742-812a-431c-bd81-d5ae11c2383d"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6972eb5-0d43-4a22-a4fa-253d856cc7c4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9928fc5a-5ccd-47f9-8dd7-20d68968a71b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb978a29-cc5e-4134-a4e6-da03b268d672"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bccc7208-370a-4f4c-9b0f-699f6067105c"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIControls"",
            ""id"": ""2e470573-7046-4972-a884-f0728629871c"",
            ""actions"": [
                {
                    ""name"": ""PressESC"",
                    ""type"": ""Button"",
                    ""id"": ""3cff12f8-dd7d-4f89-a987-82ba4c4f2843"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b73f863b-c648-4483-abce-197e4536fda9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressESC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // LandControls
            m_LandControls = asset.FindActionMap("LandControls", throwIfNotFound: true);
            m_LandControls_MousePosition = m_LandControls.FindAction("MousePosition", throwIfNotFound: true);
            m_LandControls_Movement = m_LandControls.FindAction("Movement", throwIfNotFound: true);
            m_LandControls_MouseLook = m_LandControls.FindAction("MouseLook", throwIfNotFound: true);
            m_LandControls_Sprint = m_LandControls.FindAction("Sprint", throwIfNotFound: true);
            m_LandControls_Crouch = m_LandControls.FindAction("Crouch", throwIfNotFound: true);
            m_LandControls_UseItem = m_LandControls.FindAction("UseItem", throwIfNotFound: true);
            m_LandControls_Interact = m_LandControls.FindAction("Interact", throwIfNotFound: true);
            m_LandControls_ThrowObject = m_LandControls.FindAction("ThrowObject", throwIfNotFound: true);
            // UIControls
            m_UIControls = asset.FindActionMap("UIControls", throwIfNotFound: true);
            m_UIControls_PressESC = m_UIControls.FindAction("PressESC", throwIfNotFound: true);
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

        // LandControls
        private readonly InputActionMap m_LandControls;
        private ILandControlsActions m_LandControlsActionsCallbackInterface;
        private readonly InputAction m_LandControls_MousePosition;
        private readonly InputAction m_LandControls_Movement;
        private readonly InputAction m_LandControls_MouseLook;
        private readonly InputAction m_LandControls_Sprint;
        private readonly InputAction m_LandControls_Crouch;
        private readonly InputAction m_LandControls_UseItem;
        private readonly InputAction m_LandControls_Interact;
        private readonly InputAction m_LandControls_ThrowObject;
        public struct LandControlsActions
        {
            private @PlayerInputs m_Wrapper;
            public LandControlsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @MousePosition => m_Wrapper.m_LandControls_MousePosition;
            public InputAction @Movement => m_Wrapper.m_LandControls_Movement;
            public InputAction @MouseLook => m_Wrapper.m_LandControls_MouseLook;
            public InputAction @Sprint => m_Wrapper.m_LandControls_Sprint;
            public InputAction @Crouch => m_Wrapper.m_LandControls_Crouch;
            public InputAction @UseItem => m_Wrapper.m_LandControls_UseItem;
            public InputAction @Interact => m_Wrapper.m_LandControls_Interact;
            public InputAction @ThrowObject => m_Wrapper.m_LandControls_ThrowObject;
            public InputActionMap Get() { return m_Wrapper.m_LandControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LandControlsActions set) { return set.Get(); }
            public void SetCallbacks(ILandControlsActions instance)
            {
                if (m_Wrapper.m_LandControlsActionsCallbackInterface != null)
                {
                    @MousePosition.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMousePosition;
                    @Movement.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMovement;
                    @MouseLook.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMouseLook;
                    @MouseLook.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMouseLook;
                    @MouseLook.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMouseLook;
                    @Sprint.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnSprint;
                    @Crouch.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnCrouch;
                    @Crouch.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnCrouch;
                    @Crouch.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnCrouch;
                    @UseItem.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnUseItem;
                    @UseItem.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnUseItem;
                    @UseItem.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnUseItem;
                    @Interact.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnInteract;
                    @ThrowObject.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnThrowObject;
                    @ThrowObject.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnThrowObject;
                    @ThrowObject.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnThrowObject;
                }
                m_Wrapper.m_LandControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @MouseLook.started += instance.OnMouseLook;
                    @MouseLook.performed += instance.OnMouseLook;
                    @MouseLook.canceled += instance.OnMouseLook;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                    @Crouch.started += instance.OnCrouch;
                    @Crouch.performed += instance.OnCrouch;
                    @Crouch.canceled += instance.OnCrouch;
                    @UseItem.started += instance.OnUseItem;
                    @UseItem.performed += instance.OnUseItem;
                    @UseItem.canceled += instance.OnUseItem;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @ThrowObject.started += instance.OnThrowObject;
                    @ThrowObject.performed += instance.OnThrowObject;
                    @ThrowObject.canceled += instance.OnThrowObject;
                }
            }
        }
        public LandControlsActions @LandControls => new LandControlsActions(this);

        // UIControls
        private readonly InputActionMap m_UIControls;
        private IUIControlsActions m_UIControlsActionsCallbackInterface;
        private readonly InputAction m_UIControls_PressESC;
        public struct UIControlsActions
        {
            private @PlayerInputs m_Wrapper;
            public UIControlsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @PressESC => m_Wrapper.m_UIControls_PressESC;
            public InputActionMap Get() { return m_Wrapper.m_UIControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIControlsActions set) { return set.Get(); }
            public void SetCallbacks(IUIControlsActions instance)
            {
                if (m_Wrapper.m_UIControlsActionsCallbackInterface != null)
                {
                    @PressESC.started -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnPressESC;
                    @PressESC.performed -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnPressESC;
                    @PressESC.canceled -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnPressESC;
                }
                m_Wrapper.m_UIControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @PressESC.started += instance.OnPressESC;
                    @PressESC.performed += instance.OnPressESC;
                    @PressESC.canceled += instance.OnPressESC;
                }
            }
        }
        public UIControlsActions @UIControls => new UIControlsActions(this);
        public interface ILandControlsActions
        {
            void OnMousePosition(InputAction.CallbackContext context);
            void OnMovement(InputAction.CallbackContext context);
            void OnMouseLook(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnCrouch(InputAction.CallbackContext context);
            void OnUseItem(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnThrowObject(InputAction.CallbackContext context);
        }
        public interface IUIControlsActions
        {
            void OnPressESC(InputAction.CallbackContext context);
        }
    }
}
