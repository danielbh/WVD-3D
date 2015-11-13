using UnityEngine;
using System.Collections;

public interface IDebuffComponent {
    void ToggleAnimator(bool value);
    void ToggleMovement(bool value);
    void ToggleAttacking(bool value);
}
