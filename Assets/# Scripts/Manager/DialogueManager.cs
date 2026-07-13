using UnityEngine;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    /// <summary>
    /// Allows the DialogueManager to call methods, use properties, etc.
    /// </summary>
    public static DialogueManager Instance { get; private set; }

    [Header("Dialogue Variables")]
    [SerializeField] private DialogueRunner dialogueRunner;


    // Private Variables
    private bool dialogueOn = false;

    // Public Properties
    public bool DialogueOn { get { return dialogueOn; } }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    public void OpenShopDialogue()
    {
        dialogueRunner.StartDialogue("OpenShopDialogue");
    }

    public void CloseShopDialogue()
    {
        dialogueRunner.StartDialogue("CloseShopDialogue");
    }

    [YarnCommand("disallow_movement")]
    public void MovementAllowed(bool allow)
    {
        dialogueOn = allow;
    }

}
