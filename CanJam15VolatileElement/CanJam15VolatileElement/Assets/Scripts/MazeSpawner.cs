using UnityEngine;
using System.Collections;

public class MazeSpawner : MonoBehaviour
{
	public GameObject straight;
	public GameObject corner;
	public GameObject junction;

	int[,] mazeBase;


	// Use this for initialization
	void Start ()
	{
		int height = 46;
		int width = 46;

		MazeGenerator mazeGenerator = new MazeGenerator ();

		mazeBase = mazeGenerator.CreateMaze (101, width, height, 10);

		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				GameObject spawnedWall;

				if (mazeBase[x, y] > 0)
				{
					spawnedWall = (GameObject)Instantiate (straight, new Vector3(x, 0, y), Quaternion.identity);

					if (mazeBase[x,y] == 1)
						spawnedWall.GetComponent<Renderer>().material.color = Color.red;
					else if (mazeBase[x,y] == 2)
						spawnedWall.GetComponent<Renderer>().material.color = Color.green;
					else if (mazeBase[x,y] == 3)
						spawnedWall.GetComponent<Renderer>().material.color = Color.blue;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
