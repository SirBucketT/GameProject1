using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] Animator playerAnimator;

    void Start()
    {
        AttackCollision attackCollision = playerAnimator.GetBehaviour<AttackCollision>();

        if (attackCollision != null && playerData != null)
        {
            attackCollision.SetPlayerData(playerData);
        }
    }
}
