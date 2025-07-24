using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BaseMenuButton : MonoBehaviour
{
    private Animator animator;
    public Action action;
    public bool isClickable = true;
    public enum ButtonTypes {Start,Setting,Info }
    public ButtonTypes type;
    public bool isClicked=false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (isClickable)
        {
            if (!isClicked)
            {
                animator.SetTrigger("Clicked");
                action?.Invoke();
                isClicked = true;

            }
            else { 
            
            }

                /*
                switch (type)
                {
                    case ButtonTypes.Start: break;
                    case ButtonTypes.Setting: break;
                    case ButtonTypes.Info: break;
                    default: break;
                }*/
                
        }
    }

    private void OnMouseEnter()
    {
        if (isClickable)
        {
            
              //  CameraController.Instance.ShakeCameraFunction();
                animator.SetTrigger("Hovered"); // Or SetTrigger("Hover") if using trigger
                SoundManager.instance.PlaySound(SoundManager.SoundNames.ButtonHover);
            
            
            
        }
    }
   

    private void OnMouseExit()
    {
        if (isClickable)
        {
            animator.SetTrigger("UnHovered");
        }
    }
}