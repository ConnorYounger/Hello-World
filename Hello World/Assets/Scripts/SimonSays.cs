using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    public string[] possibleButtonInputs;

    public float memoryValue;

    public int startingNumb = 2;
    public int maxNumb = 7;
    private int difficulty;

    public List<string> buttonList;

    void Start()
    {
        buttonList = new List<string>();

        GenerateNewCombination();
    }

    void GenerateNewCombination()
    {
        buttonList.Clear();

        for(int i = 0; i < startingNumb + difficulty; i++)
        {
            int rand = Random.Range(0, possibleButtonInputs.Length);

            buttonList.Add(possibleButtonInputs[rand]);
        }
    }

    void CombinationFinished()
    {
        if(difficulty == maxNumb - startingNumb)
        {
            Debug.Log("Win");
        }
        else
        {
            difficulty++;

            GenerateNewCombination();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            CombinationFinished();
        }
    }
}
