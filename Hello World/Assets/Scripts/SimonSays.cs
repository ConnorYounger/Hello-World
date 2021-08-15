using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class SimonSays : MonoBehaviour
{
    public List<SimonSaysInputs> possibleButtonInputs;

    public int maxMemory = 5;
    public int maxPacience = 5;
    private int currentPacience;
    private int currentMemory = 0;
    public int startingNumb = 2;
    public int maxNumb = 7;
    private int difficulty;

    public float failInputTime = 1;
    private float failInputTimer;

    private List<SimonSaysInputs> buttonList;
    private List<SimonSaysInputs> buttonListSave;

    public Animator animator;

    [Header("UI Elements")]
    public Canvas uICanvas;
    public GameObject comboPanel;
    public GameObject playerInputPanel;
    public GameObject inputButtonPrefab;
    public GameObject winUI;
    public GameObject loseUI;

    public bool controllerSprites = true;

    public Slider memoryMetreSlider;

    private bool playerHasWon;
    private bool startCombo;
    private bool correctInput;
    public bool playerCanInput = true;

    private MiniGameInputs controls;

    public ParentNarrative parent;

    [Header("Discovery Player")]
    public bool discoveryMode;
    public DiscoveryPlayer discoveryPlayer;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip[] sucessSounds;
    public AudioClip[] failSounds;

    public AudioClip[] correctInputSounds;
    public AudioClip trillSound;

    private int currentInput;

    private ExerciseSoundEffectsManager soundManager;

    [Header("Particles")]
    public ParticleSystem[] cryParticles;

    private void Awake()
    {
        controls = new MiniGameInputs();

        SetInputActions();
    }
    
    void SetInputActions()
    {
        controls.SimonSays.AnyInputCon.performed += ctx => PlayerAnyInput(true);
        controls.SimonSays.AnyInputKey.performed += ctx => PlayerAnyInput(false);
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

        //
        controls.SimonSays.KClick1.performed += ctx => PlayerInput(controls.SimonSays.Click1);
        controls.SimonSays.KClick2.performed += ctx => PlayerInput(controls.SimonSays.Click2);

    }

    void Start()
    {
        // Assign Lists
        buttonList = new List<SimonSaysInputs>();
        buttonListSave = new List<SimonSaysInputs>();

        memoryMetreSlider.maxValue = maxMemory;
        currentPacience = maxPacience;

        if(GameObject.Find("SoundManager").GetComponent<ExerciseSoundEffectsManager>())
            soundManager = GameObject.Find("SoundManager").GetComponent<ExerciseSoundEffectsManager>();

        playerHasWon = true;
    }

    public void StartExercise()
    {
        playerHasWon = false;

        GenerateNewCombination();
    }

    private void Update()
    {
        FailCoolDownTimer();
    }

    void FailCoolDownTimer()
    {
        if(failInputTimer > 0)
        {
            failInputTimer -= 1 * Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        controls.SimonSays.Enable();
    }

    private void OnDisable()
    {
        controls.SimonSays.Disable();
    }

    #region playerInputs
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
        if(playerCanInput && !playerHasWon && action.name == buttonList[0].inputName && failInputTimer <= 0)
        {
            correctInput = true;
        }
    }

    void PlayerAnyInput(bool con)
    {
        if (playerCanInput && !playerHasWon && failInputTimer <= 0)
        {
            Invoke("CalculateInput", 0.1f);
        }

        if (con)
        {
            controllerSprites = true;
        }
        else
        {
            controllerSprites = false;
        }

        // Update
    }
    #endregion

    #region combiniationMethods
    // Generate a new combo list
    void GenerateNewCombination()
    {
        // Clear current combos in the list
        buttonList.Clear();
        buttonListSave.Clear();

        currentInput = 0;

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
        if (scriptableObject && scriptableObject.controllerInputSprite)
        {
            if(PlayerPrefs.GetString("ControlType") == "Xbox")
                button.GetComponent<Image>().sprite = scriptableObject.controllerInputSprite;
            else if(PlayerPrefs.GetString("ControlType") == "PS")
                button.GetComponent<Image>().sprite = scriptableObject.PSControllerInputSprite;
            else
                button.GetComponent<Image>().sprite = scriptableObject.keyboardInputSprite;
        }
    }

    // When the player has sucessfully finished the combo
    void CombinationFinished()
    {
        // Check to see if the player has won
        if (currentMemory >= maxMemory)
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
    #endregion

    // When the player wins
    void PlayerWin()
    {
        if (uICanvas)
        {
            uICanvas.enabled = false;
        }

        if(soundManager)
            soundManager.PlayWinSound();

        currentMemory = maxMemory;
        UpdateMemoryMetre();

        playerHasWon = true;

        winUI.SetActive(true);

        if (parent)
        {
            parent.PlayWinNarrative();
        }

        if (discoveryMode)
        {
            discoveryPlayer.exerciseIndex = 1.1f;

            discoveryPlayer.SavePlayer();
        }

        EventSystem.current.SetSelectedGameObject(GameObject.Find("MainMenuButton"));
    }

    void CalculateInput()
    {
        if (playerCanInput && failInputTimer <= 0 && !playerHasWon)
        {
            playerCanInput = false;

            // Check to see if the input matches the correct button in the combo
            if (correctInput)
            {
                RemoveInput();
            }
            else
            {
                if (animator)
                    StartCoroutine("Flail");

                CheckForLose();
            }
        }
    }

    void CheckForLose()
    {
        currentPacience -= 1;

        if (soundManager)
            soundManager.PlayFailSound();

        // Stop the player's memory from going below 0
        if (currentPacience < 0)
        {
            currentPacience = 0;
        }

        if (currentPacience <= 0)
        {
            Lose();
        }
        else
        {
            parent.PlayFailNarrativeElement();
            ResetCombination();
        }
    }

    void Lose()
    {
        Debug.Log("Player has lost");

        if (soundManager)
        {
            soundManager.PlayLoseSound();
            soundManager.FadeOutMusic();
        }

        if (soundManager)
            soundManager.PlayBabyCrySound();

        uICanvas.enabled = false;
        loseUI.SetActive(true);

        if (parent)
        {
            parent.PlayLoseNarrative();
        }

        animator.Play("Cry");

        if (cryParticles.Length > 0)
        {
            foreach (ParticleSystem particle in cryParticles)
            {
                particle.Play();
            }
        }

        EventSystem.current.SetSelectedGameObject(GameObject.Find("RestartButton"));
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
            currentMemory += 1;

            if (parent && currentMemory < maxMemory)
            {
                parent.NarrativeElement(parent.sucessDialougeTexts[currentMemory - 1]);
            }

            UpdateMemoryMetre();

            StartCoroutine("CorrectCombination");
        }
        else
            playerCanInput = true;

        if (startCombo)
        {
            RemoveComboUI();
        }

        currentInput++;

        if (audioSource && correctInputSounds.Length > 0)
        {
            if(correctInputSounds[currentInput - 1] != null)
            {
                audioSource.clip = correctInputSounds[currentInput - 1];
                audioSource.Play();
            }
        }
    }

    IEnumerator CorrectCombination()
    {
        if (animator)
            StartCoroutine("PlayAnimation");

        yield return new WaitForSeconds(1);

        if (audioSource)
        {
            audioSource.clip = trillSound;
            audioSource.Play();
        }

        yield return new WaitForSeconds(2);

        if (soundManager)
            soundManager.PlaySucessSound();

        CombinationFinished();

        playerCanInput = true;
    }

    IEnumerator PlayAnimation()
    {
        int rand = Random.Range(1, 6);

        animator.SetInteger("moveState", rand);

        yield return new WaitForSeconds(0.5f);

        animator.SetInteger("moveState", 0);
    }

    IEnumerator Flail()
    {
        animator.SetInteger("moveState", 6);

        yield return new WaitForSeconds(0.5f);

        animator.SetInteger("moveState", 0);
    }

    // When the player inputs the wrong button
    void ResetCombination()
    {
        currentInput = 0;

        failInputTimer = failInputTime;

        buttonList.Clear();
        buttonList.AddRange(buttonListSave);

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

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
