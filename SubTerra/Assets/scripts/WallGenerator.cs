using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WallGenerator : MonoBehaviour {

	public const int WALL = 1;
	public const int ROOM = 0;

	public int width;
	public int height;

	public int maxWallWidth;

	public string seed;
	public bool useRandomSeed;

	[Range(0,100)]
	public int randomFillPercent;

	int[,] map;

	// Use this for initialization
	void Start () {
		GenerateWall ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateWall() {
		map = new int[width, height];

		RandomFillWall ();

		MeshGenerator meshGen = GetComponent<MeshGenerator> ();
		meshGen.GenerateMesh (map, WALL);
	}

	bool IsInMapRange(int x, int y) {
		return x >= 0 && x < width && y >= 0 && y < height;
	}

	void RandomFillWall() {
		if (useRandomSeed) {
			seed = Time.time.ToString();
		}

		System.Random pseudoRandom = new System.Random (seed.GetHashCode ());
		int x = 0;
		while(x < width) {
			int wallHeight = pseudoRandom.Next ((int)((randomFillPercent/100) * height), height);
			int repeatWall = pseudoRandom.Next (x, x + maxWallWidth);

			while (x < repeatWall && x < width) {
				for (int y = 0; y < height; y++) {
					if (y < wallHeight) {
						map [x, y] = WALL;
					} else {
						map [x, y] = ROOM;
					}

				}
				x++;
			}
		}
	}

	Vector3 CoordToWorldPoint(Coord tile) {
		return new Vector3 (-width / 2 + .5f + tile.tileX, -2, -height / 2 + .5f + tile.tileY);
	}

	struct Coord {
		public int tileX;
		public int tileY;

		public Coord(int x, int y){
			tileX = x;
			tileY = y;
		}
	}
}
