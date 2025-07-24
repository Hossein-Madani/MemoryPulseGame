using UnityEngine;
using UnityEngine.UI;

public class BaseMenu : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;



    [SerializeField] Button InfoButton;
    [SerializeField] Button PlayButton;
    [SerializeField] Button SettingButton;

    [SerializeField] Animator InfoAnimator;
    [SerializeField] Animator SettingAnimator;
    [SerializeField] Animator BaseMenuAnimator;
    

    public void InfoAction(bool active) {
        SoundManager.instance.PlaySound(SoundManager.SoundNames.ButtonClick1);
        InfoAnimator.SetTrigger(active? "Open" : "Close");
        InfoButton.enabled = active ? false : true;
    }
    public void SettingAction(bool active) {
        SoundManager.instance.PlaySound(SoundManager.SoundNames.ButtonClick1);
        SettingAnimator.SetTrigger(active ? "Open" : "Close");
        SettingButton.enabled=active? false : true;
    }
    public void BaseMenuAction(bool active)
    {
       
        BaseMenuAnimator.SetTrigger(active ? "Open" : "Close");
        PlayButton.enabled = active ? true : false;
    }
    public void PlayAction() {  BaseMenuAction(false); levelManager.ResetLevel(); }

}
