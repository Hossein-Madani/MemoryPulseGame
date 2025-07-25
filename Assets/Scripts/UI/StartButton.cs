using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
public class StartButton : MonoBehaviour
{
    private Animator animator;
  //public Action action;
    public bool isClickable = true;
   
    public bool isClicked = false;
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
              
                isClicked = true;
                StartGame();

            }
            else
            {
                animator.SetTrigger("UnClicked");
                isClicked = false;
            }

           

        }
    }

    public void UnSelect() {
        isClickable = true;
        animator.SetTrigger("UnClicked");
        animator.SetTrigger("UnHovered");
        isClicked = false;
    }
    public void StartGame() {
        isClickable = false;
        //  DeActiveButtons();
        //  CameraController.Instance.ShakeCamera();

        CameraController.Instance.MoveCamera(true);
       
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