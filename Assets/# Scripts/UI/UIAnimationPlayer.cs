using UnityEngine;

public class UIAnimationPlayer : MonoBehaviour
{
    [Header("Animation Clips To Play")]
    [SerializeField] private AnimationClip playerSleepClip;

    [Header("Animator")]
    [SerializeField] private Animation animation;


    public void PlaySleepUIAnimation()
    {
        animation.Play(playerSleepClip.name);
    }

    public void OnSleepAnimationStop()
    {
        DialogueManager.Instance.PlayerEndSleep();
    }
}
