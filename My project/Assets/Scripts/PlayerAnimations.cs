using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Animator animator;
    private const string IS_WALKING = "IsWalking";

    private void OnEnable()
    {
        player.onStatusChanged += ChangeAnimation;   
    }
    private void Disable()
    {
        player.onStatusChanged -= ChangeAnimation;
    }

    private void ChangeAnimation(bool isWalking)
    {
        animator.SetBool(IS_WALKING, isWalking);
    }
    
}
