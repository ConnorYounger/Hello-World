using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{
    public Button menuBtn;

    private void Start()
    {
        menuBtn.onClick.AddListener(delegate { SceneManager.LoadScene("F_Menu"); });
    }
}