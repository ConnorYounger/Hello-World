using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExercisePicker : MonoBehaviour
{
    [Header("UI Elements")]
    public Button btnCycleLeft;
    public Button btnCycleRight;
    public Button btnExercise;
    public TMP_Text textExercise;

    [Header("Exercise Scenes")]
    public string[] exercises;

    private List<string> exerciseNames = new List<string>();
    private int exerciseIndex;

    private void Start()
    {
        PopulateExercises();
        exerciseIndex = 0;
        textExercise.text = exerciseNames[exerciseIndex];

        btnCycleLeft.onClick.AddListener(delegate { UpdateExercise(-1); });
        btnCycleRight.onClick.AddListener(delegate { UpdateExercise(1); });

        btnExercise.onClick.AddListener(LoadExercise);
    }

    private void Update()
    {
        if (exerciseIndex == 0)
        {
            btnCycleLeft.interactable = false;
        }
        else if (exerciseIndex == exercises.Length)
        {
            btnCycleRight.interactable = false;
        }
        else
        {
            btnCycleLeft.interactable = true;
            btnCycleRight.interactable = true;
        }
    }

    private void LoadExercise()
    {
        SceneManager.LoadScene(exercises[exerciseIndex]);
    }

    private void UpdateExercise(int i)
    {
        exerciseIndex = exerciseIndex + i;
        textExercise.text = exerciseNames[exerciseIndex];
    }

    private void PopulateExercises()
    {
        exerciseNames.Add("Reach for the sky");
        exerciseNames.Add("Workout");
        exerciseNames.Add("The little one said");
        exerciseNames.Add("Jelly on a plate");
        exerciseNames.Add("Open, shut them");
        exerciseNames.Add("Popstar");
        exerciseNames.Add("Off you go");
        exerciseNames.Add("Copycat");
        exerciseNames.Add("Monkey monkey");
        exerciseNames.Add("One small step");
    }
}
