using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class SimonSays : MonoBehaviour
{
    public List<SimonSaysInputs> possibleButtonInputs;

    public int maxMemory = 100;
    private int currentMemory = 0;
    public int startingNumb = 2;
    public int maxNumb = 7;
    private int difficulty;

    private List<SimonSaysInputs> buttonList;
    private List<SimonSaysInputs> buttonListSave;

    [Header("UI Elements")]
    public GameObject comboPanel;
    public GameObject playerInputPanel;
    public GameObject inputButtonPrefab;
    public GameObject winUI;

    public Slider memoryMetreSlider;

    private bool playerHasWon;
    private bool startCombo;
    private bool correctInput;
    public bool playerCanInput = true;

    private MiniGameInputs controls;

    private void Awake()
    {
        controls = new MiniGameInputs();

        SetInputActions();
    }
    
    void SetInputActions()
    {
        controls.SimonSays.AnyInput.performed += ctx => PlayerAnyInput();
        controls.SimonSays.AltClick1.performed += ctx => PlayerInput(controls.SimonSays.AltClick1);
        controls.SimonSays.AltClick2.performed += ctx => PlayerInput(controls.SimonSays.AltClick2);
        controls.SimonSays.ButtonA.performed += ctx => PlayerInput(controls.SimonSays.ButtonA);
        controls.SimonSays.ButtonB.performed += ctx => PlayerInput(controls.SimonSays.ButtonB);
        controls.SimonSays.ButtonX.performed += ctx => PlayerInput(controls.SimonSays.ButtonX);
        controls.SimonSays.ButtonY.performed += ctx => PlayerInput(controls.SimonSays.ButtonY);
        controls.SimonSays.DPadRight.performed += ctx => PlayerInput(controls.SimonSays.DPadRight);
        controls.SimonSays.DPadLeft.performed += ctx => PlayerInput(controls.SimonSays.DPadLeft);
        controls.SimonSays.DPadUp.performed += ctx => PlayerInput(controls.SimonSays.DPadUp);
        controls.SimonSays.DPadDown.performed += ctx => PlayerInput(controls.SimonSays.DPadDown);

        controls.SimonSays.Click1.performed += ctx => TriggerInput(controls.SimonSays.Click1, ctx.ReadValue<float>());
        controls.SimonSays.Click1.canceled += ctx => TriggerInput(controls.SimonSays.Click1, 0);

        controls.SimonSays.Click2.performed += ctx => TriggerInput(controls.SimonSays.Click2, ctx.ReadValue<float>());
        controls.SimonSays.Click2.canceled += ctx => TriggerInput(controls.SimonSays.Click2, 0);
    }

    void Start()
    {
        // Assign Lists
        buttonList = new List<SimonSaysInputs>();
        buttonListSave = new List<SimonSaysInputs>();

        memoryMetreSlider.maxValue = maxMemory;

        GenerateNewCombination();
    }

    private void OnEnable()
    {
        controls.SimonSays.Enable();
    }

    private void OnDisable()
    {
        controls.SimonSays.Disable();
    }

    void TriggerInput(InputAction action, float i)
    {
        if (i >= 1 && playerCanInput)
        {
            PlayerInput(action);

            Invoke("CalculateInput", 0.1f);
        }
    }

    public void PlayerInput(InputAction action)
    {
        if(playerCanInput && !playerHasWon && action.name == buttonList[0].inputName)
        {
            Debug.Log("Actually Works");

            correctInput = true;
        }
    }

    void PlayerAnyInput()
    {
        if (playerCanInput && !playerHasWon)
        {
            Invoke("CalculateInput", 0.1f);
        }
    }

    // Generate a new combo list
    void GenerateNewCombination()
    {
        // Clear current combos in the list
        buttonList.Clear();
        buttonListSave.Clear();

        // Clear UI elements
        for(int i = 0; i < comboPanel.transform.childCount; i++)
        {
            Destroy(comboPanel.transform.GetChild(i).gameObject);
        }

        // Generate a new combo list with the lenght depending on the difficulty
        for(int i = 0; i < startingNumb + difficulty; i++)
        {
            int rand = Random.Range(0, possibleButtonInputs.Count);

            buttonList.Add(possibleButtonInputs[rand]);

            AddButtonToComboPanel(possibleButtonInputs[rand]);
        }

        // Save the list
        buttonListSave.AddRange(buttonList);

        Invoke("ShowComboUI", 0.5f);
    }

    // Add the button to the UI
    void AddButtonToComboPanel(SimonSaysInputs scriptableObject)
    {
        // Create the object and set it's parent
        GameObject button = Instantiate(inputButtonPrefab, comboPanel.transform.position, comboPanel.transform.rotation);
        button.transform.SetParent(comboPanel.transform);

        // Set the spirte
        if (scriptableObject && scriptableObject.inputSprite)
        {
            button.GetComponent<Image>().sprite = scriptableObject.inputSprite;
        }
    }

    // When the player has sucessfully finished the combo
    void CombinationFinished()
    {
        // Check to see if the player has won
        if(currentMemory >= maxMemory)
        {
            PlayerWin();
        }
        else
        {
            // Increase the difficulty if it's not already at the max
            if(difficulty < maxNumb - startingNumb)
            {
                difficulty++;
            }

            GenerateNewCombination();
            RemovePlayerInputUI();
        }
    }

    // When the player wins
    void PlayerWin()
    {
        currentMemory = maxMemory;
        UpdateMemoryMetre();

        playerHasWon = true;

        winUI.SetActive(true);
    }

    void CalculateInput()
    {
        if (playerCanInput)
        {
            playerCanInput = false;

            // Check to see if the input matches the correct button in the combo
            if (correctInput)
            {
                RemoveInput();
            }
            else
            {
                ResetCombination();
            }
        }
    }

    void RemoveComboUI()
    {
        startCombo = false;

        for (int i = 0; i < comboPanel.transform.childCount; i++)
        {
            comboPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void AddPlayerInputButton(Sprite sprite)
    {
        GameObject button = Instantiate(inputButtonPrefab, playerInputPanel.transform.position, playerInputPanel.transform.rotation);
        button.transform.SetParent(playerInputPanel.transform);

        button.GetComponent<Image>().sprite = sprite;
    }

    void ShowComboUI()
    {
        startCombo = true;

        for (int i = 0; i < comboPanel.transform.childCount; i++)
        {
            comboPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Remove the button from the combo
    void RemoveInput()
    {
        correctInput = false;

        int childIndex = comboPanel.transform.childCount - buttonList.Count;
        AddPlayerInputButton(comboPanel.transform.GetChild(childIndex).GetComponent<Image>().sprite);

        buttonList.RemoveAt(0);

        // Check to see if the combo is finished
        if(buttonList.Count == 0)
        {
            currentMemory += 10;

            UpdateMemoryMetre();

            CombinationFinished();
        }

        if (startCombo)
        {
            RemoveComboUI();
        }

        playerCanInput = true;
    }

    // When the player inputs the wrong button
    void ResetCombination()
    {
        buttonList.Clear();
        buttonList.AddRange(buttonListSave);

        currentMemory -= 5;

        // Stop the player's memory from going below 0
        if (currentMemory < 0)
        {
            currentMemory = 0;
        }

        UpdateMemoryMetre();

        RemovePlayerInputUI();
        ShowComboUI();

        playerCanInput = true;
    }

    void RemovePlayerInputUI()
    {
        // Clear UI elements
        for (int i = 0; i < playerInputPanel.transform.childCount; i++)
        {
            Destroy(playerInputPanel.transform.GetChild(i).gameObject);
        }
    }

    void UpdateMemoryMetre()
    {
        memoryMetreSlider.value = currentMemory;
    }
}
