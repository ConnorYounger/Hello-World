using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    public string[] possibleButtonInputs;

    public int maxMemory = 100;
    private int currentMemory = 0;

    public int startingNumb = 2;
    public int maxNumb = 7;
    private int difficulty;

    public List<string> buttonList;
    private List<string> buttonListSave;

    private bool playerHasWon;

    void Start()
    {
        buttonList = new List<string>();
        buttonListSave = new List<string>();

        GenerateNewCombination();
    }

    void GenerateNewCombination()
    {
        buttonList.Clear();
        buttonListSave.Clear();

        for(int i = 0; i < startingNumb + difficulty; i++)
        {
            int rand = Random.Range(0, possibleButtonInputs.Length);

            buttonList.Add(possibleButtonInputs[rand]);
        }

        buttonListSave.AddRange(buttonList);
    }

    void CombinationFinished()
    {
        if(currentMemory >= maxMemory)
        {
            currentMemory = maxMemory;

            Debug.Log("Win");
        }
        else
        {
            if(difficulty < maxNumb - startingNumb)
            {
                difficulty++;
            }

            GenerateNewCombination();
        }
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
        if (Input.anyKeyDown)
        {
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

    void RemoveInput()
    {
        buttonList.RemoveAt(0);

        if(buttonList.Count == 0)
        {
            CombinationFinished();

            currentMemory += 10;
        }
    }

    void ResetCombination()
    {
        buttonList.Clear();
        buttonList.AddRange(buttonListSave);

        currentMemory -= 5;

        if(currentMemory < 0)
        {
            currentMemory = 0;
        }
    }
}
