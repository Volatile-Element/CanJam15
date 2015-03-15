using UnityEngine;
using System.Collections;

public class MazeSpawner : MonoBehaviour
{
    public GameObject straight;
    public GameObject flickerLight;
    public GameObject wallPickup;
    public GameObject cornerPickup;
    public GameObject startPoint;
    public GameObject endPoint;
    public GameObject player;

    public PartManager partManager;
    public GameManager gameManager;

    int[,] mazeBase;

    public int wallPickupLimit;
    public int cornerPickupLimit;
    public int flickeringLightLimit;
    public int height;
    public int width;
    int seed;

    bool hasStart;
    bool hasEnd;

    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
		partManager = FindObjectOfType<PartManager> ();

        //int height = 46;
        //int width = 46;
        //int seed = Random.seed

        seed = gameManager.seed;
        MazeGenerator mazeGenerator = new MazeGenerator();

        mazeBase = mazeGenerator.CreateMaze(seed, width, height, 10);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject spawnedWall;

                if (mazeBase[x, y] > 0)
                {
                    spawnedWall = (GameObject)Instantiate(straight, new Vector3(x, 0.5f, y), Quaternion.identity);

                    if (mazeBase[x, y] == 1)
                    {
                        partManager.listStraights.Add(spawnedWall);
                        spawnedWall.GetComponent<Renderer>().material.color = partManager.colorStraights;
                        spawnedWall.transform.parent = gameObject.transform;
                    }
                    else if (mazeBase[x, y] == 2)
                    {
                        spawnedWall.GetComponent<Renderer>().material.color = partManager.colorCorners;
                        spawnedWall.name = "Corner";
                        partManager.listCorners.Add(spawnedWall);
                        partManager.listAll.Add(spawnedWall);
                        spawnedWall.transform.parent = gameObject.transform;
                    }
                    else if (mazeBase[x, y] == 3)
                    {
                        spawnedWall.GetComponent<Renderer>().material.color = partManager.colorStraights;
                        spawnedWall.name = "Straight";
                        partManager.listStraights.Add(spawnedWall);
                        partManager.listAll.Add(spawnedWall);
                        spawnedWall.transform.parent = gameObject.transform;
                    }
                }
                else
                {
                    if (!hasStart)
                    {
                        spawnedWall = (GameObject)Instantiate(startPoint, new Vector3(x, 0.5f, y), Quaternion.identity);
                        spawnedWall.name = "Start Point";
                        hasStart = true;
                        player.transform.position = spawnedWall.transform.position;
                        spawnedWall.transform.parent = gameObject.transform;
                        continue;
                    }
                    else if (Random.Range(0, 1000) > 990 && flickeringLightLimit > 0)
                    {
                        spawnedWall = (GameObject)Instantiate(flickerLight, new Vector3(x, 1f, y), Quaternion.identity);
                        spawnedWall.name = "Flicker Light";
                        flickeringLightLimit--;
                        spawnedWall.transform.parent = gameObject.transform;
                        continue;
                    }
                    else if (Random.Range(0, 1000) > 990 && wallPickupLimit > 0)
                    {
                        spawnedWall = (GameObject)Instantiate(wallPickup, new Vector3(x, 0.5f, y), Quaternion.identity);
                        spawnedWall.name = "Wall Pickup";
                        wallPickupLimit--;
                        spawnedWall.transform.parent = gameObject.transform;
                        continue;
                    }
                    else if (Random.Range(0, 1000) > 990 && cornerPickupLimit > 0)
                    {
                        spawnedWall = (GameObject)Instantiate(cornerPickup, new Vector3(x, 0.5f, y), Quaternion.identity);
                        spawnedWall.name = "Corner Pickup";
                        cornerPickupLimit--;
                        spawnedWall.transform.parent = gameObject.transform;
                        continue;
                    }
                }


            }
        }

        for (int x = width - 1; x > 0; x--)
        {
            for (int y = height - 1; y > 0; y--)
            {
                GameObject endSpawn;

                if (mazeBase[x, y] == 0 && !hasEnd)
                {
                    endSpawn = (GameObject)Instantiate(endPoint, new Vector3(x, 0.5f, y), Quaternion.identity);
                    endSpawn.name = "End Point";
                    hasEnd = true;
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
