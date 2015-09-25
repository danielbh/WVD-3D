using UnityEngine;
using System.Collections.Generic;

using UnityEngine;
using System.Collections;

public interface IMoveComponent {
	void Move (Vector3 worldMovVec);
	void FaceDir(Quaternion rotation);
}
