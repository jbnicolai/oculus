using UnityEngine;
using System.Collections;

public class BackgroundCubeBehaviour : MonoBehaviour {


	private float frequency = 1.0f;
	private float magnitude = 0.5f;

	private Vector3 axis;

	private Vector3 startPosition;

	void Start () {
		startPosition = this.transform.position;
		this.transform.localScale *= .75f;

	}

	void Update () {
		// local y rotate
		this.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 45f);

        // local y position sine move
        transform.position = startPosition + Vector3.up * Mathf.Sin (Time.time * frequency) * magnitude;
	}
}
