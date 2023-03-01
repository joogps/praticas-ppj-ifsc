using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PlanetBehavior : MonoBehaviour {

	public Transform target; // the object to rotate around
	public Planets planet; // the current planet
	
	void Awake() {
		if (target != null) {
			Transform targetTransform = target.transform;
			float offset = planet.BaseOffset();
			transform.RotateAround(targetTransform.position, targetTransform.up, offset);
		}
	}

	void Update () {
		if (target != null) {
			Transform targetTransform = target.transform;

			float revolutionSpeed = 60;
			if (Time.timeSinceLevelLoad > 360/revolutionSpeed) {
				float planetSpeed = (365/(float)planet.DaysInYear() * 360)/300;
				if (Time.timeSinceLevelLoad < 360/revolutionSpeed+6) {
					revolutionSpeed = Mathf.SmoothStep(planetSpeed, revolutionSpeed, 1-(Time.timeSinceLevelLoad-360/revolutionSpeed)/6);
				} else {
					revolutionSpeed = planetSpeed;
				}
			}
			transform.RotateAround(targetTransform.position, targetTransform.up, -(revolutionSpeed * Time.deltaTime));
		}

		Transform selfTransform = this.gameObject.transform.transform;
		float rotationSpeed = 24/(float)planet.HoursInDay()*60;
		transform.RotateAround(selfTransform.position, selfTransform.up, rotationSpeed * Time.deltaTime);
	}

	void OnMouseOver() {
		if (GetComponent<Outline>() != null) {
			GetComponent<Outline>().enabled = true;
		} else {
			Outline outline = gameObject.AddComponent<Outline>();
			outline.enabled = true;
			outline.OutlineColor = new Color(1, 1, 1, 0.5f);
			outline.OutlineWidth = 1.0f;
		}
	}

	void OnMouseExit() {
		gameObject.GetComponent<Outline>().enabled = false;
	}

	void OnMouseDown () {
		LookAtTarget.target = gameObject;
		LookAtTarget.size = gameObject.transform.localScale.x+2;
		UIBehavior.tooltip.text = gameObject.name.ToUpper();
	}
}

public enum Planets
{
	Sun,
	Mercury,
	Venus,
	Earth,
	Mars,
	Jupiter,
	Saturn,
	Uranus,
	Neptune,
	Pluto,
	Moon
}

static class PlanetsMethods
{
	public static int DaysInYear(this Planets planet)
	{
		switch(planet)
		{
			case Planets.Sun:
				return 0;
			case Planets.Mercury:
				return 88;
			case Planets.Venus:
				return 225;
			case Planets.Earth:
				return 365;
			case Planets.Mars:
				return 687;
			case Planets.Jupiter:
				return 4333;
			case Planets.Saturn:
				return 10759;
			case Planets.Uranus:
				return 30685;
			case Planets.Neptune:
				return 60190;
			case Planets.Pluto:
				return 90560;
			case Planets.Moon:
				return 27;
			default:
				return 0;
		}
	}

	public static int HoursInDay(this Planets planet)
	{
		switch(planet)
		{
			case Planets.Sun:
				return 24*7;
			case Planets.Mercury:
				return 1408;
			case Planets.Venus:
				return 5832;
			case Planets.Earth:
				return 24;
			case Planets.Mars:
				return 25;
			case Planets.Jupiter:
				return 10;
			case Planets.Saturn:
				return 11;
			case Planets.Uranus:
				return 17;
			case Planets.Neptune:
				return 16;
			case Planets.Pluto:
				return 153;
			case Planets.Moon:
				return 24;
			default:
				return 0;
		}
	}

	public static int BaseOffset(this Planets planet)
	{
		switch(planet)
		{
			case Planets.Sun:
				return 0;
			case Planets.Mercury:
				return 185;
			case Planets.Venus:
				return 350;
			case Planets.Earth:
				return 80;
			case Planets.Mars:
				return 35;
			case Planets.Jupiter:
				return 275;
			case Planets.Saturn:
				return 225;
			case Planets.Uranus:
				return 350;
			case Planets.Neptune:
				return 265;
			case Planets.Pluto:
				return 350;
			case Planets.Moon:
				return 0;
			default:
				return 0;
		}
	}
}