using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameUI.OnFaithFull += OpenDoor;
    }

    private void OnDisable()
    {
        GameUI.OnFaithFull -= OpenDoor;
    }

    void OpenDoor()
    {
        animator.Play("Open");
    }
}
