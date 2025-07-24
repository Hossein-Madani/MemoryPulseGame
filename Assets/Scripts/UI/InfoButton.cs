using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InfoButton : MonoBehaviour
{
    private Animator animator;
    //public Action action;
    public bool isClickable = true;

    public bool isClicked = false;

    [SerializeField] Animator InfoDetails;
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
                InfoDetails.SetTrigger("Open");
                isClicked = true;

            }
            else
            {
                animator.SetTrigger("UnClicked");
                InfoDetails.SetTrigger("Close");
                isClicked = false;
            }



        }
    }

    public void StartGame()
    {
        //  DeActiveButtons();
        //  CameraController.Instance.ShakeCamera();
     //   CameraController.Instance.MoveCamera(true);

    }


    private void OnMouseEnter()
    {
        if (isClickable && !isClicked)
        {

            CameraController.Instance.ShakeCamera();
            animator.SetTrigger("Hovered"); // Or SetTrigger("Hover") if using trigger
            SoundManager.instance.PlaySound(SoundManager.SoundNames.ButtonHover);



        }
    }


    private void OnMouseExit()
    {
        if (isClickable && !isClicked)
        {
            animator.SetTrigger("UnHovered");
        }
    }
}