﻿using UnityEngine;

[ExecuteInEditMode]
public class PixelDensityCamera : MonoBehaviour {

	public float pixelsToUnits = 100;

	private Camera camera;

	void Awake()
	{
		camera = GetComponent<Camera>();
	}

	void Update () {

		camera.orthographicSize = Screen.height / pixelsToUnits / 2;
	}
}