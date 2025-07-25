using System.Collections;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance { get; private set; }
    
    [SerializeField] LevelManager _levelManager;
    

    

    

    

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
