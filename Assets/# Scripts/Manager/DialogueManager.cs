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
    public DialogueRunner DialogueRunner { get { return dialogueRunner; } }

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

    // Dialogue Options
    public void OpenShopDialogue()
    {
        dialogueRunner.StartDialogue("OpenShopDialogue");
    }

    public void CloseShopDialogue()
    {
        dialogueRunner.StartDialogue("CloseShopDialogue");
    }

    public void PlayerStartSleep()
    {
        dialogueRunner.StartDialogue("PlayerSleep");
    }

    public void PlayerEndSleep()
    {
        dialogueRunner.StartDialogue("PlayerEndSleep");
    }

    public void PlayDialogue(string node)
    {
        dialogueRunner.StartDialogue(node);
    }

    [YarnCommand("disallow_movement")]
    public void MovementAllowed(bool allow)
    {
        dialogueOn = allow;
    }

}
