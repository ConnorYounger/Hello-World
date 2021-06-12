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

    private List<string> buttonList;
    private List<string> buttonListSave;

    [Header("UI Elements")]
    public GameObject comboPanel;
    public GameObject playerInputPanel;
    public GameObject inputButtonPrefab;
    public GameObject winUI;

    public Slider memoryMetreSlider;

    private bool playerHasWon;
    private bool startCombo;

    public InputAction inputAction;
    public List<InputActionMap> inputActionMap;
    public InputActionAsset inputActionMapAsset;
    public MiniGameInputs miniGameInputs;

    MiniGameInputs controls;

    void Start()
    {
        // Assign Lists
        buttonList = new List<string>();
        buttonListSave = new List<string>();

        memoryMetreSlider.maxValue = maxMemory;

        GenerateNewCombination();

        SetInputActions();
    }

    void SetInputActions()
    {
        inputActionMap = new List<InputActionMap>();

        //for(int i = 0; i < inputActionMapAsset.FindActionMap("SimonSays").actions.Count; i++)
        //{
        //    inputActionMap.Add(inputActionMapAsset.FindActionMap("SimonSays").actions[i].actionMap);
        //}

        inputActionMap.Add(inputActionMapAsset.FindActionMap("SimonSays").actions[0].actionMap);
    }

    private void Awake()
    {
        controls = new MiniGameInputs();

        //controls.SimonSays.Click1.performed += ctx => TestThingy();
        controls.SimonSays.AnyInput.performed += ctx => TestThingy(controls.SimonSays.AnyInput);
        //controls.SimonSays.AnyInput.performed += ctx => TestThingy2(controls.SimonSays.AnyInput);
    }

    private void OnEnable()
    {
        controls.SimonSays.Enable();
    }

    private void OnDisable()
    {
        controls.SimonSays.Disable();
    }

    public void TestThingy(InputAction action)
    {
        foreach(InputAction iaction in inputActionMapAsset)
        {
            if(action.name == iaction.name)
            {
                Debug.Log("Better Works" + iaction.name);
            }

            Debug.Log(iaction);
        }

        if(action.name == inputAction.name)
        {
            Debug.Log("Actually Works");
        }

        //if (action == inputActionMapAsset.FindAction(inputAction.name))
        //{
        //    Debug.Log("Actualy Works");
        //}
    }

    public void TestThingy2(InputAction action)
    {
        foreach (InputBinding iaction in inputActionMapAsset.actionMaps[0].bindings)
        {
            foreach (InputBinding bi in action.bindings)
            {
                if (bi.name == iaction.name)
                {
                    Debug.Log("Actually Works");
                }
            }
        }

        Debug.Log(action);

        Debug.Log("Wokrs I think");
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

            buttonList.Add(possibleButtonInputs[rand].inputName);

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

    void Update()
    {
        if (!playerHasWon)
        {
            //PlayerInput();
        }

        //if (inputActionMapAsset.FindActionMap("SimonSays").Contains())
        //{

        //}
    }

    void PlayerInput()
    {
        // Check to see if there is an input from the player
        if (Input.anyKeyDown)
        {
            // Check to see if the input matches the correct button in the combo
            if (Input.GetButtonDown(buttonList[0]))
            {
                RemoveInput();
            }
            else
            {
                ResetCombination();
            }
        }

        //if(controls.SimonSays.)
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
