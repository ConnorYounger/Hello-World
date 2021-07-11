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

        btnCycleLeft.onClick.AddListener(ExerciseDown);
        btnCycleRight.onClick.AddListener(ExerciseUp);

        btnExercise.onClick.AddListener(LoadExercise);
    }

    private void LoadExercise()
    {
        SceneManager.LoadScene(exercises[exerciseIndex]);
    }

    private void ExerciseUp()
    {
        if (exerciseIndex != exercises.Length)
        {
            exerciseIndex = exerciseIndex + 1;
            textExercise.text = exerciseNames[exerciseIndex];
        }
    }

    private void ExerciseDown()
    {
        if (exerciseIndex != 0)
        {
            exerciseIndex = exerciseIndex - 1 ;
            textExercise.text = exerciseNames[exerciseIndex];
        }
    }

    private void PopulateExercises()
    {
        exerciseNames.Add("Reach for the sky");
        exerciseNames.Add("Workout");
        exerciseNames.Add("The little one said");
        exerciseNames.Add("Jelly on a plate");
        exerciseNames.Add("Open, shut them");
        //exerciseNames.Add("Popstar");
        //exerciseNames.Add("Off you go");
        //exerciseNames.Add("Copycat");
        //exerciseNames.Add("Monkey monkey");
        //exerciseNames.Add("One small step");
    }
}
