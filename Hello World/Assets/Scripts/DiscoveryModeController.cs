using UnityEngine;
using UnityEngine.UI;

public class DiscoveryModeController : MonoBehaviour
{
    #region Variables
    public float exerciseIndex;
    public Button btnBack;
    public Button btnNext;

    [Header("Stage Cards")]
    public Image stage1In;
    public Image stage1Out;
    public Image stage2In;
    public Image stage2Out;
    public Image stage3In;
    public Image stage3Out;
    public Image stage4In;
    public Image stage4Out;
    public Image stage5In;
    public Image stage5Out;
    public Image stage6In;
    public Image stage6Out;

    #endregion

    private void Start()
    {
        //LoadPlayer();
        UpdateMilestones();
    }

    private void UpdateMilestones()
    {
        Debug.Log("um run");
        switch (exerciseIndex)
        {
            case 1.1f:
                stage2In.enabled = true;
                break;
            case 2.1f:
                stage3In.enabled = true;
                break;
            case 3.1f:
                stage4In.enabled = true;
                break;
            case 4.1f:
                stage5In.enabled = true;
                break;
            case 5.1f:
                stage6In.enabled = true;
                break;
            default:
                Debug.Log("default run");
                stage1In.enabled = true;
                break;
        }
    }

    private void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        exerciseIndex = data.exerciseIndex;
    }
}
