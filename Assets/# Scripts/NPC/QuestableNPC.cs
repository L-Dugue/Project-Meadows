using UnityEngine;
using Yarn.Unity;

public class QuestableNPC : NPC
{
    [Header("Quest Attributes")]
    [SerializeField] private PlayerCurrency playerCurrency;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] ItemBluePrint itemToRemove;

    [YarnCommand("CallQuest")]
    public void TryTakeVoidFlower()
    {
        if (playerInventory.RemoveItemFromInventory(itemToRemove))
        {
            DialogueManager.Instance.DialogueRunner.VariableStorage.SetValue("$givenVoidFlower", true);
           
        }
    }

    [YarnCommand("CompleteQuest")]
    public void CompleteQuest(int gemsToGive)
    {
        playerCurrency.SellItem(gemsToGive);
    }

    public override void PlayDialogue()
    {
        base.PlayDialogue();
    }
}
