using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class MainBehaviour : MonoBehaviour {

	public GameObject backgroundCubePrefab;

	private int amount = 512; // must be a cubic power;

	private GameObject[] cubes;
	private List<Vector3[]> confs = new List<Vector3[]>();
	private int confIndex = 0;

	private float speed = 10f;


	void Start() {
		CreateCubes();

		confs.Add (GetScatteredPositions ());
		confs.Add (GetXebiaLogoPositions ());
		confs.Add (GetRandomPositions ());

		NextConfiguration ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			NextConfiguration();
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position = transform.position - Vector3.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position = transform.position - Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
		}
	}

	void CreateCubes() {
		cubes = new GameObject[amount];
		for (var i = 0; i < amount; i++) { cubes[i] = CreateCube(); }
	}

	void NextConfiguration() {
		Debug.Log ("applying configuration index: " + (confIndex));
		ApplyPosition (confs [confIndex++]);
		if (confIndex >= confs.Count ())
			confIndex = 0;
	}


	Vector3[] GetXebiaLogoPositions() {
		int[,] p = {{ 1,  2}, { 1,  3}, { 1,  4}, { 1,  5}, { 1,  6}, { 1, 19}, { 1, 20}, { 1, 21}, { 1, 22}, { 1, 23}, { 1, 32}, { 1, 33}, { 1, 45}, { 1, 46}, { 2,  3}, { 2,  4}, { 2,  5}, { 2,  6}, { 2,  7}, { 2, 18}, { 2, 19}, { 2, 20}, { 2, 21}, { 2, 22}, { 2, 32}, { 2, 33}, { 2, 45}, { 2, 46}, { 3,  4}, { 3,  5}, { 3,  6}, { 3,  7}, { 3,  8}, { 3, 17}, { 3, 18}, { 3, 19}, { 3, 20}, { 3, 21}, { 3, 32}, { 3, 33}, { 3, 45}, { 3, 46}, { 4,  4}, { 4,  5}, { 4,  6}, { 4,  7}, { 4,  8}, { 4,  9}, { 4, 16}, { 4, 17}, { 4, 18}, { 4, 19}, { 4, 20}, { 4, 32}, { 4, 33}, { 5,  5}, { 5,  6}, { 5,  7}, { 5,  8}, { 5,  9}, { 5, 10}, { 5, 15}, { 5, 16}, { 5, 17}, { 5, 18}, { 5, 19}, { 5, 24}, { 5, 32}, { 5, 33}, { 5, 36}, { 5, 37}, { 5, 38}, { 5, 39}, { 5, 45}, { 5, 46}, { 5, 51}, { 5, 52}, { 5, 53}, { 5, 54}, { 5, 57}, { 6,  6}, { 6,  7}, { 6,  8}, { 6,  9}, { 6, 10}, { 6, 14}, { 6, 15}, { 6, 16}, { 6, 17}, { 6, 18}, { 6, 23}, { 6, 24}, { 6, 25}, { 6, 26}, { 6, 27}, { 6, 28}, { 6, 32}, { 6, 33}, { 6, 34}, { 6, 35}, { 6, 36}, { 6, 37}, { 6, 38}, { 6, 39}, { 6, 40}, { 6, 45}, { 6, 46}, { 6, 50}, { 6, 51}, { 6, 52}, { 6, 53}, { 6, 54}, { 6, 55}, { 6, 56}, { 6, 57}, { 6, 58}, { 7,  7}, { 7,  8}, { 7,  9}, { 7, 10}, { 7, 11}, { 7, 12}, { 7, 13}, { 7, 14}, { 7, 15}, { 7, 16}, { 7, 17}, { 7, 22}, { 7, 23}, { 7, 24}, { 7, 26}, { 7, 27}, { 7, 28}, { 7, 29}, { 7, 32}, { 7, 33}, { 7, 34}, { 7, 35}, { 7, 38}, { 7, 39}, { 7, 40}, { 7, 41}, { 7, 45}, { 7, 46}, { 7, 49}, { 7, 50}, { 7, 51}, { 7, 54}, { 7, 55}, { 7, 56}, { 7, 57}, { 7, 58}, { 8,  8}, { 8,  9}, { 8, 10}, { 8, 11}, { 8, 12}, { 8, 13}, { 8, 14}, { 8, 15}, { 8, 16}, { 8, 17}, { 8, 21}, { 8, 22}, { 8, 28}, { 8, 29}, { 8, 30}, { 8, 32}, { 8, 33}, { 8, 34}, { 8, 39}, { 8, 40}, { 8, 41}, { 8, 45}, { 8, 46}, { 8, 48}, { 8, 49}, { 8, 50}, { 8, 56}, { 8, 57}, { 8, 58}, { 9,  9}, { 9, 10}, { 9, 11}, { 9, 12}, { 9, 13}, { 9, 14}, { 9, 15}, { 9, 21}, { 9, 22}, { 9, 28}, { 9, 29}, { 9, 30}, { 9, 32}, { 9, 33}, { 9, 40}, { 9, 41}, { 9, 45}, { 9, 46}, { 9, 48}, { 9, 49}, { 9, 56}, { 9, 57}, { 9, 58}, {10, 10}, {10, 11}, {10, 12}, {10, 13}, {10, 14}, {10, 15}, {10, 21}, {10, 22}, {10, 23}, {10, 24}, {10, 25}, {10, 26}, {10, 27}, {10, 28}, {10, 29}, {10, 30}, {10, 32}, {10, 33}, {10, 40}, {10, 41}, {10, 45}, {10, 46}, {10, 48}, {10, 49}, {10, 56}, {10, 57}, {10, 58}, {11,  9}, {11, 10}, {11, 11}, {11, 12}, {11, 13}, {11, 14}, {11, 15}, {11, 21}, {11, 22}, {11, 32}, {11, 33}, {11, 40}, {11, 41}, {11, 45}, {11, 46}, {11, 48}, {11, 49}, {11, 56}, {11, 57}, {11, 58}, {12,  8}, {12,  9}, {12, 10}, {12, 11}, {12, 12}, {12, 13}, {12, 14}, {12, 15}, {12, 16}, {12, 21}, {12, 22}, {12, 23}, {12, 28}, {12, 29}, {12, 30}, {12, 32}, {12, 33}, {12, 34}, {12, 39}, {12, 40}, {12, 41}, {12, 45}, {12, 46}, {12, 49}, {12, 50}, {12, 55}, {12, 56}, {12, 57}, {12, 58}, {13,  7}, {13,  8}, {13,  9}, {13, 10}, {13, 11}, {13, 12}, {13, 13}, {13, 14}, {13, 15}, {13, 16}, {13, 17}, {13, 18}, {13, 22}, {13, 23}, {13, 24}, {13, 25}, {13, 26}, {13, 27}, {13, 28}, {13, 29}, {13, 32}, {13, 33}, {13, 34}, {13, 35}, {13, 36}, {13, 37}, {13, 38}, {13, 39}, {13, 40}, {13, 41}, {13, 45}, {13, 46}, {13, 49}, {13, 50}, {13, 51}, {13, 52}, {13, 53}, {13, 54}, {13, 55}, {13, 56}, {13, 57}, {13, 58}, {14,  6}, {14,  7}, {14,  8}, {14,  9}, {14, 10}, {14, 11}, {14, 14}, {14, 15}, {14, 16}, {14, 17}, {14, 18}, {14, 19}, {14, 22}, {14, 23}, {14, 24}, {14, 25}, {14, 26}, {14, 27}, {14, 28}, {14, 32}, {14, 33}, {14, 34}, {14, 35}, {14, 36}, {14, 37}, {14, 38}, {14, 39}, {14, 40}, {14, 45}, {14, 46}, {14, 50}, {14, 51}, {14, 52}, {14, 53}, {14, 54}, {14, 55}, {14, 56}, {14, 57}, {14, 58}, {15,  5}, {15,  6}, {15,  7}, {15,  8}, {15,  9}, {15, 10}, {15, 15}, {15, 16}, {15, 17}, {15, 18}, {15, 19}, {15, 20}, {15, 33}, {15, 36}, {15, 37}, {15, 38}, {15, 39}, {15, 45}, {15, 46}, {15, 51}, {15, 52}, {15, 53}, {15, 54}, {16,  4}, {16,  5}, {16,  6}, {16,  7}, {16,  8}, {16,  9}, {16, 16}, {16, 17}, {16, 18}, {16, 19}, {16, 20}, {17,  3}, {17,  4}, {17,  5}, {17,  6}, {17,  7}, {17,  8}, {17, 17}, {17, 18}, {17, 19}, {17, 20}, {17, 21}, {18,  2}, {18,  3}, {18,  4}, {18,  5}, {18,  6}, {18,  7}, {18, 18}, {18, 19}, {18, 20}, {18, 21}, {18, 22}, {19,  1}, {19,  2}, {19,  3}, {19,  4}, {19,  5}, {19,  6}, {19, 19}, {19, 20}, {19, 21}, {19, 22}, {19, 23}};
		Vector3[] xebiapositions = new Vector3[p.GetLength (0)];
		for (var i = 0; i < p.GetLength (0); i++) {
			xebiapositions [i] = new Vector3 (30 - p [i, 1], 20 - p [i, 0], -20);
		}
		return xebiapositions;
	}

	Vector3[] GetRandomPositions() {
		Vector3[] randomPositions = new Vector3[512];
		for (int i = 0; i < 512; i++) {
			randomPositions [i] = new Vector3 (Random.Range (-150.0F, 150.0F), Random.Range (-150.0F, 150.0F), Random.Range (-150.0F, 150.0F));
		}
		return randomPositions;
	}

	Vector3[] GetScatteredPositions() {
		var p = new Vector3[amount];
		int cubicRoot = (int)Mathf.Pow(amount, 1f/3f);
		int i = 0;
		for (int x = 0; x < cubicRoot; x++) {
			for (int y = 0; y < cubicRoot; y++) {
				for (int z = 0; z < cubicRoot; z++) {
					p[i++] = new Vector3((x - cubicRoot / 2) * 20, (y - cubicRoot / 2) * 20, (z - cubicRoot / 2) * 20);
				}
			}
		}
		return p;
	}

	GameObject CreateCube() {
		var cube = GameObject.Instantiate<GameObject>(backgroundCubePrefab);
		cube.transform.parent = this.transform;
		cube.transform.localPosition = Vector3.zero;
		return cube;
	}

	void ApplyPosition(Vector3[] positions) {
		for (var i = 0; i < cubes.Length; i++) {
			GameObject c = cubes[i];
			bool isVisible = i < positions.Length && Vector3.Magnitude(positions[i]) > 1;
			if (isVisible) {
				StartCoroutine(Animate (c, positions[i], 3f));
			}
			SetVisiblity(c, isVisible);
		}
	}

	void SetVisiblity(GameObject obj, bool state) {
		foreach (Renderer r in obj.GetComponentsInChildren<Renderer> ())
			r.enabled = state;

		if (!state) {
			obj.transform.position = Vector3.zero;
		}
	}

	IEnumerator Animate(GameObject obj, Vector3 targetPosition, float totalTime) {
		Vector3 startPosition = obj.transform.position;
		float t = 0;
		while (t < totalTime) {
			t += Time.deltaTime;
			obj.transform.position = Vector3.Lerp (startPosition, targetPosition, t / totalTime);
			yield return null;
		}
	}

}
