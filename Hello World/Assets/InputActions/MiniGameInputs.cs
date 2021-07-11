// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/MiniGameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MiniGameInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MiniGameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MiniGameInputs"",
    ""maps"": [
        {
            ""name"": ""SimonSays"",
            ""id"": ""fbe3c25e-e4fe-4c07-b67d-630825ef8d59"",
            ""actions"": [
                {
                    ""name"": ""Click1"",
                    ""type"": ""Value"",
                    ""id"": ""b3a47a68-186c-4af8-85d7-0a79f0c4d612"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click2"",
                    ""type"": ""Value"",
                    ""id"": ""0253c554-a5de-4792-8957-63431e1194c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AltClick1"",
                    ""type"": ""Button"",
                    ""id"": ""818f0f0a-4903-4093-bcff-43fc3715127f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AltClick2"",
                    ""type"": ""Button"",
                    ""id"": ""cada3223-d8be-4e12-b4d7-1e14fc674b55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonA"",
                    ""type"": ""Button"",
                    ""id"": ""1f65f325-1905-490e-9027-ce037be7ca7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonB"",
                    ""type"": ""Button"",
                    ""id"": ""e2571135-849f-49b9-836b-cfbf79a8182e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonX"",
                    ""type"": ""Button"",
                    ""id"": ""4466d137-e88a-4dc7-8494-c46a08fed53d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonY"",
                    ""type"": ""Button"",
                    ""id"": ""471bf002-2055-45b6-8e6d-7d917d4734c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AnyInput"",
                    ""type"": ""Button"",
                    ""id"": ""b3ed2f57-c513-46c7-8c58-8b2a3472d5ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DPadRight"",
                    ""type"": ""Button"",
                    ""id"": ""6540be99-9cfd-4f70-9720-11df30a65572"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DPadLeft"",
                    ""type"": ""Button"",
                    ""id"": ""a84fb04c-26f5-4c39-a7f5-be452ad26a1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DPadUp"",
                    ""type"": ""Button"",
                    ""id"": ""613a5028-a6f2-4566-8ba8-3463756f42bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DPadDown"",
                    ""type"": ""Button"",
                    ""id"": ""db7bc8a9-087f-454b-bb10-0d6bdeda0665"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1e765069-5877-4760-91f3-2bffa87b2b78"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f883f96c-486d-4581-96fb-d04b7fa6d0ad"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9268064d-ef96-4447-adcf-565b2539cc60"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98a1a51d-b7b5-4e9e-99c7-8c2dc5b14989"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f8a972c-f995-489a-889c-8810aa5b6971"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltClick1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e9c8ea2-bd46-4c6a-8bbe-aae3bd06b2cf"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltClick1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f6001ec-5ba2-490a-8754-4e67b6c010c6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltClick2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d2c334b-cd1c-480d-8044-747c3a9ad225"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltClick2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc6339c0-e685-44ac-ad8c-1d355d8ae7cb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8177ac2f-711d-4b25-9610-5c43653ff2bd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fbb0f2f-527a-4f41-8185-db02e9167447"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c51b9341-d1a4-4fc5-9633-1fff3b3f4195"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50116e7d-ae50-4a25-b50a-38e7100ddc81"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4eea203-7f74-44b9-8062-dbc6ca1567f3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c69e631b-947d-4b9b-8a32-c5a72c5b2862"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b430ef5-32f2-4163-884c-bc6a789d64c6"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00bc6e13-95da-4ae8-9a46-4397491415fb"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4487fa6e-5302-4106-a3fd-2c00b11ac6fe"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8e826dd-f994-4d78-b3f1-700aa2025988"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cb5d955-1354-454e-90f7-be4ccd7e1363"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""456ccda5-059d-46a0-a6ba-7c2ac5e30c2f"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15426520-3396-4d7b-9c4a-eb499bbe749b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""048b80d1-614f-4016-8bdc-1c01b0100f44"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f8392a7-afc6-4042-8dfd-d74a529e33bb"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de80e51d-4afb-4d36-8067-2f9ca749f708"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c6a3497-764d-42f3-823c-e8804683774e"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8fd6b90-8969-441c-be3d-93752ead9bed"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""981785a2-9823-4223-8bd2-d3f66294bfa7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03922809-f0b3-4ba9-8fde-b2e5d1ff59cf"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebf23e5a-deaa-481c-b153-6785b794ed66"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a920c1a6-82ea-4eef-885b-6c5f73eec1b0"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b57050ae-fcb6-4b2e-93ba-2b9045409a55"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ac40953-1bd3-4267-a194-06263df7873e"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a727db65-6cfa-4afd-b3c5-4772bec259db"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0dfb3c5-8adf-4885-9ded-399641a06424"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1aebbb5a-ecca-48a4-801b-bbfca0670a4d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""814359cf-114f-4482-83ec-07e8107aaef4"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""HoldingObjects"",
            ""id"": ""54c3036c-f84a-4b2b-a785-50b1177b318a"",
            ""actions"": [
                {
                    ""name"": ""LeftHandMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bc5c61ec-6bb9-418d-b703-45dd446f326b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0fbf5a5e-e18e-497b-8eb3-57e4450ef35b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandGrab"",
                    ""type"": ""Value"",
                    ""id"": ""bcd5df9f-cf28-43b3-a251-46d7a5b26ae3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandGrab"",
                    ""type"": ""Value"",
                    ""id"": ""e155206c-ed75-4c3c-b028-7f2a959f5d3e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fbd90330-17dc-42a3-bf4c-efd731d5a432"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftHandMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1601c110-4bf1-41e0-a8f9-bd1006dbd285"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightHandMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7db59cbf-1ebb-47e6-9936-5479f3d49629"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftHandGrab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbf30cb1-d460-45d8-b247-0b04aff97eb1"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightHandGrab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""QWOP"",
            ""id"": ""4e1789d8-3995-4a30-86d4-0b500e215cb1"",
            ""actions"": [
                {
                    ""name"": ""LeftMovement1"",
                    ""type"": ""Button"",
                    ""id"": ""5a110672-c471-422f-9fbb-a591cbde0e5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMovement2"",
                    ""type"": ""Button"",
                    ""id"": ""d57c018c-75af-48e7-8845-442f9c904926"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMovement1"",
                    ""type"": ""Button"",
                    ""id"": ""590c0d6e-4bca-461e-b427-68f5041c56c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMovement2"",
                    ""type"": ""Button"",
                    ""id"": ""f5b9c6e1-9fd0-405d-85d3-d495585aba41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ec401a9a-fc28-48f6-8a85-3c3996008c0d"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMovement1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23b19fdf-5909-4292-9291-a3f093a4a44c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMovement1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afe39e71-8c92-4bd8-9f6f-ade49f21db21"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMovement1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""856d30bc-bb1f-4324-9b13-deff94382b74"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMovement1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""432791c7-1bcc-47e6-8fb6-0f8f02bc2ffa"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMovement2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5c925c7-8116-42b1-96e5-7602ce95f7fb"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMovement2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec5bded2-6917-49c0-b515-4c4f58267928"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMovement2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c452a18-bff0-4d39-bf1a-7871ced1c8ff"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMovement2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""RollOver"",
            ""id"": ""2527bfc7-f1ef-4ecf-b852-2d56ab0157ea"",
            ""actions"": [
                {
                    ""name"": ""Key1"",
                    ""type"": ""Button"",
                    ""id"": ""95fd99bb-d8f9-473c-b9b7-9b05ebeffce2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Key2"",
                    ""type"": ""Button"",
                    ""id"": ""51f8c0ca-5c91-4691-ac94-fbd1ee1018f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Key3"",
                    ""type"": ""Button"",
                    ""id"": ""f198de43-fc8e-41ab-9447-62da1ceaa43a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Key4"",
                    ""type"": ""Button"",
                    ""id"": ""499a45c6-d6a5-4bf9-b66a-0d88aa7c6291"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Key5"",
                    ""type"": ""Button"",
                    ""id"": ""35c94b72-242c-4587-9ade-d5d911084c8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c71eada6-a6b3-4b30-bbd0-4b6ab1adf8f1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d08193f6-647a-442e-9ec5-4596ff1cc3ee"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1e89670-22cb-4c7a-a067-b797b65e16fd"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ef7e7b2-b34e-44d5-85be-9780eb2dd526"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d33dce07-8c49-4acb-b325-7dc6da2cff10"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e564a46d-7000-479f-b346-38d4b9d5874a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c787bdfd-2cef-4858-baab-39292ee23ae5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95a10b4f-2d46-4ace-b0fd-e86abaefedf5"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e5700e0-c987-4c21-9b1d-a1fbcf28e546"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""927407d0-0523-4a90-a011-b12a2630e42c"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Blinking"",
            ""id"": ""22f1f073-523c-4f8a-b9b5-468415ae1079"",
            ""actions"": [
                {
                    ""name"": ""Key1"",
                    ""type"": ""Button"",
                    ""id"": ""4bdf2778-4ec0-428e-bfeb-d543b8415c00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f17a0374-01da-447b-976e-eb7d3096b7a0"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8893330b-35aa-410b-9ebd-c032b7527bdb"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""aa5f2c9c-e259-4918-ab6c-68922087488d"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""b2661e97-0a4a-4770-beeb-cc94a57c049f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""277fd313-593c-41b1-8bfc-983ec93c91a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""04de4a64-53a1-4ff9-92a4-778bfa98ff46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1d6e0e77-6737-42a8-b8f2-ee6297b00678"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea1aa9ba-e82c-4511-b8a2-8a6cccfb65ba"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7da8704-642c-4890-9cc3-565b9501a022"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e257ee45-1c92-4e3e-92ae-f7ae05c84eed"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SimonSays
        m_SimonSays = asset.FindActionMap("SimonSays", throwIfNotFound: true);
        m_SimonSays_Click1 = m_SimonSays.FindAction("Click1", throwIfNotFound: true);
        m_SimonSays_Click2 = m_SimonSays.FindAction("Click2", throwIfNotFound: true);
        m_SimonSays_AltClick1 = m_SimonSays.FindAction("AltClick1", throwIfNotFound: true);
        m_SimonSays_AltClick2 = m_SimonSays.FindAction("AltClick2", throwIfNotFound: true);
        m_SimonSays_ButtonA = m_SimonSays.FindAction("ButtonA", throwIfNotFound: true);
        m_SimonSays_ButtonB = m_SimonSays.FindAction("ButtonB", throwIfNotFound: true);
        m_SimonSays_ButtonX = m_SimonSays.FindAction("ButtonX", throwIfNotFound: true);
        m_SimonSays_ButtonY = m_SimonSays.FindAction("ButtonY", throwIfNotFound: true);
        m_SimonSays_AnyInput = m_SimonSays.FindAction("AnyInput", throwIfNotFound: true);
        m_SimonSays_DPadRight = m_SimonSays.FindAction("DPadRight", throwIfNotFound: true);
        m_SimonSays_DPadLeft = m_SimonSays.FindAction("DPadLeft", throwIfNotFound: true);
        m_SimonSays_DPadUp = m_SimonSays.FindAction("DPadUp", throwIfNotFound: true);
        m_SimonSays_DPadDown = m_SimonSays.FindAction("DPadDown", throwIfNotFound: true);
        // HoldingObjects
        m_HoldingObjects = asset.FindActionMap("HoldingObjects", throwIfNotFound: true);
        m_HoldingObjects_LeftHandMovement = m_HoldingObjects.FindAction("LeftHandMovement", throwIfNotFound: true);
        m_HoldingObjects_RightHandMovement = m_HoldingObjects.FindAction("RightHandMovement", throwIfNotFound: true);
        m_HoldingObjects_LeftHandGrab = m_HoldingObjects.FindAction("LeftHandGrab", throwIfNotFound: true);
        m_HoldingObjects_RightHandGrab = m_HoldingObjects.FindAction("RightHandGrab", throwIfNotFound: true);
        // QWOP
        m_QWOP = asset.FindActionMap("QWOP", throwIfNotFound: true);
        m_QWOP_LeftMovement1 = m_QWOP.FindAction("LeftMovement1", throwIfNotFound: true);
        m_QWOP_LeftMovement2 = m_QWOP.FindAction("LeftMovement2", throwIfNotFound: true);
        m_QWOP_RightMovement1 = m_QWOP.FindAction("RightMovement1", throwIfNotFound: true);
        m_QWOP_RightMovement2 = m_QWOP.FindAction("RightMovement2", throwIfNotFound: true);
        // RollOver
        m_RollOver = asset.FindActionMap("RollOver", throwIfNotFound: true);
        m_RollOver_Key1 = m_RollOver.FindAction("Key1", throwIfNotFound: true);
        m_RollOver_Key2 = m_RollOver.FindAction("Key2", throwIfNotFound: true);
        m_RollOver_Key3 = m_RollOver.FindAction("Key3", throwIfNotFound: true);
        m_RollOver_Key4 = m_RollOver.FindAction("Key4", throwIfNotFound: true);
        m_RollOver_Key5 = m_RollOver.FindAction("Key5", throwIfNotFound: true);
        // Blinking
        m_Blinking = asset.FindActionMap("Blinking", throwIfNotFound: true);
        m_Blinking_Key1 = m_Blinking.FindAction("Key1", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Navigate = m_MainMenu.FindAction("Navigate", throwIfNotFound: true);
        m_MainMenu_Select = m_MainMenu.FindAction("Select", throwIfNotFound: true);
        m_MainMenu_Cancel = m_MainMenu.FindAction("Cancel", throwIfNotFound: true);
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

    // SimonSays
    private readonly InputActionMap m_SimonSays;
    private ISimonSaysActions m_SimonSaysActionsCallbackInterface;
    private readonly InputAction m_SimonSays_Click1;
    private readonly InputAction m_SimonSays_Click2;
    private readonly InputAction m_SimonSays_AltClick1;
    private readonly InputAction m_SimonSays_AltClick2;
    private readonly InputAction m_SimonSays_ButtonA;
    private readonly InputAction m_SimonSays_ButtonB;
    private readonly InputAction m_SimonSays_ButtonX;
    private readonly InputAction m_SimonSays_ButtonY;
    private readonly InputAction m_SimonSays_AnyInput;
    private readonly InputAction m_SimonSays_DPadRight;
    private readonly InputAction m_SimonSays_DPadLeft;
    private readonly InputAction m_SimonSays_DPadUp;
    private readonly InputAction m_SimonSays_DPadDown;
    public struct SimonSaysActions
    {
        private @MiniGameInputs m_Wrapper;
        public SimonSaysActions(@MiniGameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click1 => m_Wrapper.m_SimonSays_Click1;
        public InputAction @Click2 => m_Wrapper.m_SimonSays_Click2;
        public InputAction @AltClick1 => m_Wrapper.m_SimonSays_AltClick1;
        public InputAction @AltClick2 => m_Wrapper.m_SimonSays_AltClick2;
        public InputAction @ButtonA => m_Wrapper.m_SimonSays_ButtonA;
        public InputAction @ButtonB => m_Wrapper.m_SimonSays_ButtonB;
        public InputAction @ButtonX => m_Wrapper.m_SimonSays_ButtonX;
        public InputAction @ButtonY => m_Wrapper.m_SimonSays_ButtonY;
        public InputAction @AnyInput => m_Wrapper.m_SimonSays_AnyInput;
        public InputAction @DPadRight => m_Wrapper.m_SimonSays_DPadRight;
        public InputAction @DPadLeft => m_Wrapper.m_SimonSays_DPadLeft;
        public InputAction @DPadUp => m_Wrapper.m_SimonSays_DPadUp;
        public InputAction @DPadDown => m_Wrapper.m_SimonSays_DPadDown;
        public InputActionMap Get() { return m_Wrapper.m_SimonSays; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SimonSaysActions set) { return set.Get(); }
        public void SetCallbacks(ISimonSaysActions instance)
        {
            if (m_Wrapper.m_SimonSaysActionsCallbackInterface != null)
            {
                @Click1.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnClick1;
                @Click1.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnClick1;
                @Click1.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnClick1;
                @Click2.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnClick2;
                @Click2.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnClick2;
                @Click2.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnClick2;
                @AltClick1.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnAltClick1;
                @AltClick1.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnAltClick1;
                @AltClick1.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnAltClick1;
                @AltClick2.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnAltClick2;
                @AltClick2.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnAltClick2;
                @AltClick2.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnAltClick2;
                @ButtonA.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonA;
                @ButtonA.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonA;
                @ButtonA.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonA;
                @ButtonB.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonB;
                @ButtonB.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonB;
                @ButtonB.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonB;
                @ButtonX.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonX;
                @ButtonX.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonX;
                @ButtonX.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonX;
                @ButtonY.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonY;
                @ButtonY.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonY;
                @ButtonY.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnButtonY;
                @AnyInput.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnAnyInput;
                @AnyInput.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnAnyInput;
                @AnyInput.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnAnyInput;
                @DPadRight.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadRight;
                @DPadRight.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadRight;
                @DPadRight.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadRight;
                @DPadLeft.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadLeft;
                @DPadUp.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadUp;
                @DPadUp.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadUp;
                @DPadUp.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadUp;
                @DPadDown.started -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadDown;
                @DPadDown.performed -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadDown;
                @DPadDown.canceled -= m_Wrapper.m_SimonSaysActionsCallbackInterface.OnDPadDown;
            }
            m_Wrapper.m_SimonSaysActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click1.started += instance.OnClick1;
                @Click1.performed += instance.OnClick1;
                @Click1.canceled += instance.OnClick1;
                @Click2.started += instance.OnClick2;
                @Click2.performed += instance.OnClick2;
                @Click2.canceled += instance.OnClick2;
                @AltClick1.started += instance.OnAltClick1;
                @AltClick1.performed += instance.OnAltClick1;
                @AltClick1.canceled += instance.OnAltClick1;
                @AltClick2.started += instance.OnAltClick2;
                @AltClick2.performed += instance.OnAltClick2;
                @AltClick2.canceled += instance.OnAltClick2;
                @ButtonA.started += instance.OnButtonA;
                @ButtonA.performed += instance.OnButtonA;
                @ButtonA.canceled += instance.OnButtonA;
                @ButtonB.started += instance.OnButtonB;
                @ButtonB.performed += instance.OnButtonB;
                @ButtonB.canceled += instance.OnButtonB;
                @ButtonX.started += instance.OnButtonX;
                @ButtonX.performed += instance.OnButtonX;
                @ButtonX.canceled += instance.OnButtonX;
                @ButtonY.started += instance.OnButtonY;
                @ButtonY.performed += instance.OnButtonY;
                @ButtonY.canceled += instance.OnButtonY;
                @AnyInput.started += instance.OnAnyInput;
                @AnyInput.performed += instance.OnAnyInput;
                @AnyInput.canceled += instance.OnAnyInput;
                @DPadRight.started += instance.OnDPadRight;
                @DPadRight.performed += instance.OnDPadRight;
                @DPadRight.canceled += instance.OnDPadRight;
                @DPadLeft.started += instance.OnDPadLeft;
                @DPadLeft.performed += instance.OnDPadLeft;
                @DPadLeft.canceled += instance.OnDPadLeft;
                @DPadUp.started += instance.OnDPadUp;
                @DPadUp.performed += instance.OnDPadUp;
                @DPadUp.canceled += instance.OnDPadUp;
                @DPadDown.started += instance.OnDPadDown;
                @DPadDown.performed += instance.OnDPadDown;
                @DPadDown.canceled += instance.OnDPadDown;
            }
        }
    }
    public SimonSaysActions @SimonSays => new SimonSaysActions(this);

    // HoldingObjects
    private readonly InputActionMap m_HoldingObjects;
    private IHoldingObjectsActions m_HoldingObjectsActionsCallbackInterface;
    private readonly InputAction m_HoldingObjects_LeftHandMovement;
    private readonly InputAction m_HoldingObjects_RightHandMovement;
    private readonly InputAction m_HoldingObjects_LeftHandGrab;
    private readonly InputAction m_HoldingObjects_RightHandGrab;
    public struct HoldingObjectsActions
    {
        private @MiniGameInputs m_Wrapper;
        public HoldingObjectsActions(@MiniGameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftHandMovement => m_Wrapper.m_HoldingObjects_LeftHandMovement;
        public InputAction @RightHandMovement => m_Wrapper.m_HoldingObjects_RightHandMovement;
        public InputAction @LeftHandGrab => m_Wrapper.m_HoldingObjects_LeftHandGrab;
        public InputAction @RightHandGrab => m_Wrapper.m_HoldingObjects_RightHandGrab;
        public InputActionMap Get() { return m_Wrapper.m_HoldingObjects; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HoldingObjectsActions set) { return set.Get(); }
        public void SetCallbacks(IHoldingObjectsActions instance)
        {
            if (m_Wrapper.m_HoldingObjectsActionsCallbackInterface != null)
            {
                @LeftHandMovement.started -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnLeftHandMovement;
                @LeftHandMovement.performed -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnLeftHandMovement;
                @LeftHandMovement.canceled -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnLeftHandMovement;
                @RightHandMovement.started -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnRightHandMovement;
                @RightHandMovement.performed -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnRightHandMovement;
                @RightHandMovement.canceled -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnRightHandMovement;
                @LeftHandGrab.started -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnLeftHandGrab;
                @LeftHandGrab.performed -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnLeftHandGrab;
                @LeftHandGrab.canceled -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnLeftHandGrab;
                @RightHandGrab.started -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnRightHandGrab;
                @RightHandGrab.performed -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnRightHandGrab;
                @RightHandGrab.canceled -= m_Wrapper.m_HoldingObjectsActionsCallbackInterface.OnRightHandGrab;
            }
            m_Wrapper.m_HoldingObjectsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftHandMovement.started += instance.OnLeftHandMovement;
                @LeftHandMovement.performed += instance.OnLeftHandMovement;
                @LeftHandMovement.canceled += instance.OnLeftHandMovement;
                @RightHandMovement.started += instance.OnRightHandMovement;
                @RightHandMovement.performed += instance.OnRightHandMovement;
                @RightHandMovement.canceled += instance.OnRightHandMovement;
                @LeftHandGrab.started += instance.OnLeftHandGrab;
                @LeftHandGrab.performed += instance.OnLeftHandGrab;
                @LeftHandGrab.canceled += instance.OnLeftHandGrab;
                @RightHandGrab.started += instance.OnRightHandGrab;
                @RightHandGrab.performed += instance.OnRightHandGrab;
                @RightHandGrab.canceled += instance.OnRightHandGrab;
            }
        }
    }
    public HoldingObjectsActions @HoldingObjects => new HoldingObjectsActions(this);

    // QWOP
    private readonly InputActionMap m_QWOP;
    private IQWOPActions m_QWOPActionsCallbackInterface;
    private readonly InputAction m_QWOP_LeftMovement1;
    private readonly InputAction m_QWOP_LeftMovement2;
    private readonly InputAction m_QWOP_RightMovement1;
    private readonly InputAction m_QWOP_RightMovement2;
    public struct QWOPActions
    {
        private @MiniGameInputs m_Wrapper;
        public QWOPActions(@MiniGameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftMovement1 => m_Wrapper.m_QWOP_LeftMovement1;
        public InputAction @LeftMovement2 => m_Wrapper.m_QWOP_LeftMovement2;
        public InputAction @RightMovement1 => m_Wrapper.m_QWOP_RightMovement1;
        public InputAction @RightMovement2 => m_Wrapper.m_QWOP_RightMovement2;
        public InputActionMap Get() { return m_Wrapper.m_QWOP; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(QWOPActions set) { return set.Get(); }
        public void SetCallbacks(IQWOPActions instance)
        {
            if (m_Wrapper.m_QWOPActionsCallbackInterface != null)
            {
                @LeftMovement1.started -= m_Wrapper.m_QWOPActionsCallbackInterface.OnLeftMovement1;
                @LeftMovement1.performed -= m_Wrapper.m_QWOPActionsCallbackInterface.OnLeftMovement1;
                @LeftMovement1.canceled -= m_Wrapper.m_QWOPActionsCallbackInterface.OnLeftMovement1;
                @LeftMovement2.started -= m_Wrapper.m_QWOPActionsCallbackInterface.OnLeftMovement2;
                @LeftMovement2.performed -= m_Wrapper.m_QWOPActionsCallbackInterface.OnLeftMovement2;
                @LeftMovement2.canceled -= m_Wrapper.m_QWOPActionsCallbackInterface.OnLeftMovement2;
                @RightMovement1.started -= m_Wrapper.m_QWOPActionsCallbackInterface.OnRightMovement1;
                @RightMovement1.performed -= m_Wrapper.m_QWOPActionsCallbackInterface.OnRightMovement1;
                @RightMovement1.canceled -= m_Wrapper.m_QWOPActionsCallbackInterface.OnRightMovement1;
                @RightMovement2.started -= m_Wrapper.m_QWOPActionsCallbackInterface.OnRightMovement2;
                @RightMovement2.performed -= m_Wrapper.m_QWOPActionsCallbackInterface.OnRightMovement2;
                @RightMovement2.canceled -= m_Wrapper.m_QWOPActionsCallbackInterface.OnRightMovement2;
            }
            m_Wrapper.m_QWOPActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftMovement1.started += instance.OnLeftMovement1;
                @LeftMovement1.performed += instance.OnLeftMovement1;
                @LeftMovement1.canceled += instance.OnLeftMovement1;
                @LeftMovement2.started += instance.OnLeftMovement2;
                @LeftMovement2.performed += instance.OnLeftMovement2;
                @LeftMovement2.canceled += instance.OnLeftMovement2;
                @RightMovement1.started += instance.OnRightMovement1;
                @RightMovement1.performed += instance.OnRightMovement1;
                @RightMovement1.canceled += instance.OnRightMovement1;
                @RightMovement2.started += instance.OnRightMovement2;
                @RightMovement2.performed += instance.OnRightMovement2;
                @RightMovement2.canceled += instance.OnRightMovement2;
            }
        }
    }
    public QWOPActions @QWOP => new QWOPActions(this);

    // RollOver
    private readonly InputActionMap m_RollOver;
    private IRollOverActions m_RollOverActionsCallbackInterface;
    private readonly InputAction m_RollOver_Key1;
    private readonly InputAction m_RollOver_Key2;
    private readonly InputAction m_RollOver_Key3;
    private readonly InputAction m_RollOver_Key4;
    private readonly InputAction m_RollOver_Key5;
    public struct RollOverActions
    {
        private @MiniGameInputs m_Wrapper;
        public RollOverActions(@MiniGameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Key1 => m_Wrapper.m_RollOver_Key1;
        public InputAction @Key2 => m_Wrapper.m_RollOver_Key2;
        public InputAction @Key3 => m_Wrapper.m_RollOver_Key3;
        public InputAction @Key4 => m_Wrapper.m_RollOver_Key4;
        public InputAction @Key5 => m_Wrapper.m_RollOver_Key5;
        public InputActionMap Get() { return m_Wrapper.m_RollOver; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RollOverActions set) { return set.Get(); }
        public void SetCallbacks(IRollOverActions instance)
        {
            if (m_Wrapper.m_RollOverActionsCallbackInterface != null)
            {
                @Key1.started -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey1;
                @Key1.performed -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey1;
                @Key1.canceled -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey1;
                @Key2.started -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey2;
                @Key2.performed -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey2;
                @Key2.canceled -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey2;
                @Key3.started -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey3;
                @Key3.performed -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey3;
                @Key3.canceled -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey3;
                @Key4.started -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey4;
                @Key4.performed -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey4;
                @Key4.canceled -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey4;
                @Key5.started -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey5;
                @Key5.performed -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey5;
                @Key5.canceled -= m_Wrapper.m_RollOverActionsCallbackInterface.OnKey5;
            }
            m_Wrapper.m_RollOverActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Key1.started += instance.OnKey1;
                @Key1.performed += instance.OnKey1;
                @Key1.canceled += instance.OnKey1;
                @Key2.started += instance.OnKey2;
                @Key2.performed += instance.OnKey2;
                @Key2.canceled += instance.OnKey2;
                @Key3.started += instance.OnKey3;
                @Key3.performed += instance.OnKey3;
                @Key3.canceled += instance.OnKey3;
                @Key4.started += instance.OnKey4;
                @Key4.performed += instance.OnKey4;
                @Key4.canceled += instance.OnKey4;
                @Key5.started += instance.OnKey5;
                @Key5.performed += instance.OnKey5;
                @Key5.canceled += instance.OnKey5;
            }
        }
    }
    public RollOverActions @RollOver => new RollOverActions(this);

    // Blinking
    private readonly InputActionMap m_Blinking;
    private IBlinkingActions m_BlinkingActionsCallbackInterface;
    private readonly InputAction m_Blinking_Key1;
    public struct BlinkingActions
    {
        private @MiniGameInputs m_Wrapper;
        public BlinkingActions(@MiniGameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Key1 => m_Wrapper.m_Blinking_Key1;
        public InputActionMap Get() { return m_Wrapper.m_Blinking; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BlinkingActions set) { return set.Get(); }
        public void SetCallbacks(IBlinkingActions instance)
        {
            if (m_Wrapper.m_BlinkingActionsCallbackInterface != null)
            {
                @Key1.started -= m_Wrapper.m_BlinkingActionsCallbackInterface.OnKey1;
                @Key1.performed -= m_Wrapper.m_BlinkingActionsCallbackInterface.OnKey1;
                @Key1.canceled -= m_Wrapper.m_BlinkingActionsCallbackInterface.OnKey1;
            }
            m_Wrapper.m_BlinkingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Key1.started += instance.OnKey1;
                @Key1.performed += instance.OnKey1;
                @Key1.canceled += instance.OnKey1;
            }
        }
    }
    public BlinkingActions @Blinking => new BlinkingActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_Navigate;
    private readonly InputAction m_MainMenu_Select;
    private readonly InputAction m_MainMenu_Cancel;
    public struct MainMenuActions
    {
        private @MiniGameInputs m_Wrapper;
        public MainMenuActions(@MiniGameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_MainMenu_Navigate;
        public InputAction @Select => m_Wrapper.m_MainMenu_Select;
        public InputAction @Cancel => m_Wrapper.m_MainMenu_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigate;
                @Select.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelect;
                @Cancel.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    public interface ISimonSaysActions
    {
        void OnClick1(InputAction.CallbackContext context);
        void OnClick2(InputAction.CallbackContext context);
        void OnAltClick1(InputAction.CallbackContext context);
        void OnAltClick2(InputAction.CallbackContext context);
        void OnButtonA(InputAction.CallbackContext context);
        void OnButtonB(InputAction.CallbackContext context);
        void OnButtonX(InputAction.CallbackContext context);
        void OnButtonY(InputAction.CallbackContext context);
        void OnAnyInput(InputAction.CallbackContext context);
        void OnDPadRight(InputAction.CallbackContext context);
        void OnDPadLeft(InputAction.CallbackContext context);
        void OnDPadUp(InputAction.CallbackContext context);
        void OnDPadDown(InputAction.CallbackContext context);
    }
    public interface IHoldingObjectsActions
    {
        void OnLeftHandMovement(InputAction.CallbackContext context);
        void OnRightHandMovement(InputAction.CallbackContext context);
        void OnLeftHandGrab(InputAction.CallbackContext context);
        void OnRightHandGrab(InputAction.CallbackContext context);
    }
    public interface IQWOPActions
    {
        void OnLeftMovement1(InputAction.CallbackContext context);
        void OnLeftMovement2(InputAction.CallbackContext context);
        void OnRightMovement1(InputAction.CallbackContext context);
        void OnRightMovement2(InputAction.CallbackContext context);
    }
    public interface IRollOverActions
    {
        void OnKey1(InputAction.CallbackContext context);
        void OnKey2(InputAction.CallbackContext context);
        void OnKey3(InputAction.CallbackContext context);
        void OnKey4(InputAction.CallbackContext context);
        void OnKey5(InputAction.CallbackContext context);
    }
    public interface IBlinkingActions
    {
        void OnKey1(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
}
