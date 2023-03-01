using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	static public GameObject target; // the target that the camera should look at
	static public float size; // the size of the camera

	void Start () {
		size = target.transform.localScale.x*2+10;
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			Vector3 lookDirection = target.transform.position - transform.position;
			lookDirection.Normalize();

			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 5 * Time.deltaTime);
			Camera.main.orthographicSize = Mathf.SmoothStep(Camera.main.orthographicSize, size, 10 * Time.deltaTime);
		}
	}
}
