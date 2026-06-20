using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    [Header("UI")]
    [SerializeField] private GameObject doorCanvas;

    [Header("Door")]
    [SerializeField] private Animator animator;

    private bool opened = false;

    private void Start()
    {
        HidePrompt();

        if (animator == null)
            { animator = GetComponent<Animator>(); }
    }

    public void Interact()
    {
        if (opened) return;

        opened = true;

        HidePrompt();

        animator.SetTrigger("Open");
    }

    public void ShowPrompt()
    {
        if (!opened)
            { doorCanvas.SetActive(true); }
    }

    public void HidePrompt()
    {
        doorCanvas.SetActive(false);
    }

    public void FinishOpening()
    {
        animator.SetBool("IsOpen", true);
    }
}
