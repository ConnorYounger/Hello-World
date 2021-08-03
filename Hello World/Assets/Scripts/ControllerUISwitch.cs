using UnityEngine;

public class ControllerUISwitch : MonoBehaviour
{
    public GameObject xBox;
    public GameObject ps;

    void Start()
    {
        UpdateControllerUI();
    }

    public void UpdateControllerUI()
    {
        if (PlayerPrefs.GetString("ControlType") == "Xbox")
        {
            xBox.SetActive(true);
            ps.SetActive(false);
        }
        else if (PlayerPrefs.GetString("ControlType") == "PS")
        {
            xBox.SetActive(false);
            ps.SetActive(true);
        }
    }
}
