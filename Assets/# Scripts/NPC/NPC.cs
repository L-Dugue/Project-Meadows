using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("NPC Attributes")]
    [SerializeField] private string yarnSpinnerNode;

    public virtual void PlayDialogue()
    {
        DialogueManager.Instance.PlayDialogue(yarnSpinnerNode);
    }
}
