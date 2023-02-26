using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	public Transform target; // the object to rotate around
	public float speed; // the speed of rotation
	public Planets planet; // the speed of rotation
	
	void Start() {
		if (target == null) 
		{
			target = this.gameObject.transform;
			Debug.Log ("RotateAround target not specified. Defaulting to parent GameObject");
		}
	}

	// Update is called once per frame
	void Update () {
		// RotateAround takes three arguments, first is the Vector to rotate around
		// second is a vector that axis to rotate around
		// third is the degrees to rotate, in this case the speed per second
		transform.RotateAround(target.transform.position,target.transform.up,speed * Time.deltaTime);
	}
}

public enum Planets
{
	Mercury,
	Venus,
	Earth,
	Mars,
	Jupiter,
	Saturn,
	Uranus,
	Neptune
}

// public int DaysInYear(Planets planet)
// {
// 	switch(planet)
// 	{
// 		case Planets.Mercury:
// 			return 88;
// 		case Planets.Venus:
// 			return 225;
// 		case Planets.Earth:
// 			return 365;
// 		case Planets.Mars:
// 			return 687;
// 		case Planets.Jupiter:
// 			return 4333;
// 		case Planets.Saturn:
// 			return 10759;
// 		case Planets.Uranus:
// 			return 30685;
// 		case Planets.Neptune:
// 			return 60190;
// 		default:
// 			return 0;
// 	}
// }