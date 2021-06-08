using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{
    public List<SimonSaysInputs> possibleButtonInputs;

    public int maxMemory = 100;
    private int currentMemory = 0;

    public int startingNumb = 2;
    public int maxNumb = 7;
    private int difficulty;

    public List<string> buttonList;
    private List<string> buttonListSave;

    public GameObject comboPanel;
    public GameObject playerInputPanel;
    public GameObject inputButtonPrefab;

    public float fadeInMultiplier = 1;

    private bool playerHasWon;
    public bool startCombo;

    void Start()
    {
        // Assign Lists
        buttonList = new List<string>();
        buttonListSave = new List<string>();

        GenerateNewCombination();
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
        }
    }

    // When the player wins
    void PlayerWin()
    {
        currentMemory = maxMemory;

        playerHasWon = true;

        Debug.Log("Win");
    }

    void Update()
    {
        if (!playerHasWon)
        {
            PlayerInput();
        }
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
    }

    void RemoveComboUI()
    {
        startCombo = false;

        for (int i = 0; i < comboPanel.transform.childCount; i++)
        {
            comboPanel.transform.GetChild(i).gameObject.SetActive(false);

            //AddPlayerInputButton(comboPanel.transform.GetChild(i).GetComponent<Image>().sprite);
        }
    }

    void AddPlayerInputButton(Sprite sprite)
    {
        for(int i = 0; 0 < buttonListSave.Count; i++)
        {
            if(i == playerInputPanel.transform.childCount)
            {
                GameObject button = Instantiate(inputButtonPrefab, comboPanel.transform.position, comboPanel.transform.rotation);
                button.transform.SetParent(comboPanel.transform);

                button.GetComponent<Image>().sprite = sprite;
            }
        }
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
        buttonList.RemoveAt(0);

        // Check to see if the combo is finished
        if(buttonList.Count == 0)
        {
            CombinationFinished();

            currentMemory += 10;
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
        if(currentMemory < 0)
        {
            currentMemory = 0;
        }

        ShowComboUI();
    }
}
