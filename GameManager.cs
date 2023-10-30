using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public static int speedLevel = 0;
	public static int shipCrashes = 0;
	
	public GUISkin layout;
	
	GameObject asteroid;
	GameObject spaceship;

	void Start() {
    	asteroid = GameObject.FindGameObjectWithTag("Asteroid");
    	spaceship = GameObject.FindGameObjectWithTag("Player");
	}

	public static void LevelUp() {
    	speedLevel++;
	}

	public static void Crash() {
		speedLevel = 0;
    	shipCrashes++;
	}

	void OnGUI() {
    	GUI.skin = layout;

		GUIContent speedContent = new GUIContent("Speed\n" + speedLevel);
    	GUIContent crashContent = new GUIContent("Impacts\n" + shipCrashes);

		Vector2 speedSize = GUI.skin.label.CalcSize(speedContent);
		Vector2 crashSize = GUI.skin.label.CalcSize(crashContent);

		float posY = Screen.height * 0.1f;

		float speedPosX = Screen.width * 0.15f;
		float crashPosX = Screen.width - speedPosX - crashSize.x;

    	GUI.Label(new Rect(speedPosX, posY, speedSize.x, speedSize.y), speedContent);
    	GUI.Label(new Rect(crashPosX, posY, crashSize.x, crashSize.y), crashContent);
	}
}