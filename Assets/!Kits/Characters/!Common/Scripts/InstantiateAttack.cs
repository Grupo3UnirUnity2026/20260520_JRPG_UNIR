using UnityEngine;

public class InstantiateAttack : MonoBehaviour
{
    private CharacterController2D characterController;

    internal void Shoot()
    {
        this.characterController = GetComponentInParent<CharacterController2D>();

        this.characterController?.ShootOnAttackAnimation();

    }

}
