using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class EnemyController {

	public IMoveComponent moveComponent;
	public IAttackComponent attackComponent;
    public IDebuffComponent debuffComponent;

	public void SetMoveComponent (IMoveComponent component) {
		moveComponent = component;
	}

	public void SetAttackComponent (IAttackComponent component) {
		attackComponent = component;
	}

    public void SetDebuffComponent(IDebuffComponent component)
    {
        debuffComponent = component;
    }

    public void Move (Transform target, Vector3 self, float minDist) {

        //  If not moving character will continue to turn to face the player
        moveComponent.LookAt(target.transform);

        if (Vector3.Distance(target.position, self) > minDist) {
			moveComponent.Move();
		} else {
            moveComponent.Stop();
		}
	}

    public void Attack(float timer, float timeBetweenAttacks, bool playerInRange, bool ranged) {
		if(timer >= timeBetweenAttacks && playerInRange )
		{
			if (ranged) {
				attackComponent.RangedAttack();
			} else {
				attackComponent.MeleeAttack();
			}
		}
	}

    public void Freeze()
    {
        debuffComponent.ToggleAnimator(false);
        debuffComponent.ToggleMovement(false);
        debuffComponent.ToggleAttacking(false);
    }

    public void Unfreeze()
    {
        debuffComponent.ToggleAnimator(true);
        debuffComponent.ToggleMovement(true);
        debuffComponent.ToggleAttacking(true);
    }
}
