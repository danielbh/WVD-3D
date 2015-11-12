using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class Debuff : MonoBehaviour {

    EnemyMovement movement;
    EnemyAttack attack;
    Animator animator;

    void OnEnable()
    {
        movement = GetComponent<EnemyMovement>();
        attack = GetComponent<EnemyAttack>();
        animator = GetComponent<Animator>();
    }

    public void Freeze(float duration)
    {
        animator.enabled = false;
        movement.immobilized = true;
        attack.attackDisabled = true;
        Invoke("Unfreeze", duration);
    }

    public void Unfreeze()
    {
        // animator.enabled = true;
        //movement.immobilized = false;
       // attack.attackDisabled = false;
    }
}
