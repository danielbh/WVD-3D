using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class Debuff : MonoBehaviour, IDebuffComponent {

    [HideInInspector]
    public EnemyController controller;

    EnemyMovement movement;
    EnemyAttack attack;
    Animator animator;

    bool frozen = false;

    // Only readable outside of class because if not
    // something could be marked frozen but not have the effects
    // of being frozen.
    public bool Frozen {
        get
        {
            return frozen;
        }
        private set
        {
            frozen = value;
        }
    }

    void OnEnable()
    {
        controller.SetDebuffComponent(this);

        movement = GetComponent<EnemyMovement>();
        attack = GetComponent<EnemyAttack>();
        animator = GetComponent<Animator>();
    }

    public void Freeze(float duration)
    {
        controller.Freeze();
        frozen = true;
        Invoke("Unfreeze", duration);
    }

    public void Unfreeze()
    {
        controller.Unfreeze();
        frozen = false;
    }

    #region IAttackComponent implementation

    public void ToggleAnimator(bool value)
    {
        animator.enabled = value;
    }

    public void ToggleMovement(bool value)
    {
        // You need to use movementEnabled instead of default
        // enabled because the enemies will slide from inertia
        // if frozen while moving.
        movement.movementEnabled = value;
    }

    public void ToggleAttacking(bool value)
    {
        attack.enabled = value;
    }
   
    #endregion
}
