using UnityEngine;
using System.Collections;

public interface IMoveComponent 
{
	void Move();
	void Stop();
    void LookAt(Transform target);
}
