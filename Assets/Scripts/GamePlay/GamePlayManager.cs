using System.Collections;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance { get; private set; }
    
    [SerializeField] LevelManager _levelManager;
    [SerializeField] private Camera _camera;

    

    [SerializeField] private float moveDuration = 1.0f;

    

    [SerializeField] BaseMenuButton[] MenuButtons;
    [SerializeField] BaseMenuButton START_BUTTON,SETTING_BUTTON,INFO_BUTTON;


    // Setting Details
    [SerializeField] GameObject SettingDetails;
    private bool isSettingDetailsOpen=false;



    [SerializeField] GameObject InfoDetails;
    private bool isInfoDetailsOpen = false;

    public void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ActiveButtons();
       

        
    }
    public void ActiveButtons() {
        foreach (var button in MenuButtons ) {
            button.isClickable = true;
        }
    }
    public void DeActiveButtons() {
        foreach (var button in MenuButtons)
        {
            button.isClickable = false;
        }
    }

    public void OpenSettingDetails() {
        if (isSettingDetailsOpen)
        {
            SettingDetails.GetComponent<Animator>().SetTrigger("Close");
        }
        else { SettingDetails.GetComponent<Animator>().SetTrigger("Open"); }
        
        isSettingDetailsOpen = !isSettingDetailsOpen;

    }

    public void OpenInfoDetails()
    {
        if (isInfoDetailsOpen)
        {
            InfoDetails.GetComponent<Animator>().SetTrigger("Close");
        }
        else { InfoDetails.GetComponent<Animator>().SetTrigger("Open"); }

        isInfoDetailsOpen = !isInfoDetailsOpen;

    }



    
}
