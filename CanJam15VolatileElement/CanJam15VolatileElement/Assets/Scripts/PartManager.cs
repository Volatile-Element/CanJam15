using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartManager : MonoBehaviour 
{
	ColorPicker cp;

    public Color colorCorners, colorStraights, colorDoors, colorJunctions, colorTraps;

    public List<GameObject> listCorners = new List<GameObject>();
    public List<GameObject> listStraights = new List<GameObject>();
    public List<GameObject> listDoors = new List<GameObject>();
    public List<GameObject> listJunctions = new List<GameObject>();
    public List<GameObject> listTraps = new List<GameObject>();

    public List<GameObject> listAll = new List<GameObject>();

    public enum Showing { corners, straights, doors, junctions, traps, trail };
    Showing whatsShowing, previousSurface;

    bool isPersistant = false;
    bool isShowing = false;

	// Use this for initialization
	void Awake () 
    {
		cp = GameObject.Find("ColorPicker").GetComponent<ColorPicker>();
		
        colorCorners = cp.Picker();
        colorStraights = cp.Picker();
        colorDoors = cp.Picker();
        colorJunctions = cp.Picker();
        colorTraps = cp.Picker();
	}

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            RowShower();
        }

        if (Input.GetKeyDown("l"))
        {
            if (isShowing == false)
            {
                foreach (GameObject go in listAll)
                {
                    go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                }

                isShowing = true;
            }
            else if (isShowing == true)
            {
                foreach (GameObject go in listAll)
                {
                    go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                }

                isShowing = false;
            }
        }

        if (Input.GetKeyDown("m"))
        {
            if (GameObject.Find("Player").GetComponent<TrailRenderer>().shadowCastingMode == UnityEngine.Rendering.ShadowCastingMode.On)
            {
                GameObject.Find("Player").GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
            else if (GameObject.Find("Player").GetComponent<TrailRenderer>().shadowCastingMode == UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly)
            {
                GameObject.Find("Player").GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
        }
    }

    public void RowShower()
    {
        StartCoroutine(Wait());

        isShowing = true;
    }

    IEnumerator Wait()
    {
        foreach (GameObject go in listAll)
        {
            go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void NewObject(GameObject passedObject, Showing passedShowing)
    {
        if (passedShowing == Showing.corners)
        {
            //ColorChange(colorCorners, passedObject);

            listCorners.Add(passedObject);
        }
        else if (passedShowing == Showing.straights)
        {
           // ColorChange(colorStraights, passedObject);

            listStraights.Add(passedObject);
        }
        else if (passedShowing == Showing.doors)
        {
            //ColorChange(colorDoors, passedObject);

            listDoors.Add(passedObject);
        }
        else if (passedShowing == Showing.junctions)
        {
            //ColorChange(colorJunctions, passedObject);

            listJunctions.Add(passedObject);
        }
        else if (passedShowing == Showing.traps)
        {
            //ColorChange(colorTraps, passedObject);

            listTraps.Add(passedObject);
        }
    }

    void ColorChange(Color temp, GameObject passedObject)
    {
        passedObject.GetComponent<Renderer>().material.color = temp;
        passedObject.GetComponent<Renderer>().material.SetColor("_Emission", temp);
    }

    public void NewSurface(Showing passedShow)
    {
        previousSurface = whatsShowing;
        whatsShowing = passedShow;

        UpdateSurface();
    }


    void UpdateSurface()
    {
        if (previousSurface == Showing.corners)
        {
            ResetCorners();
        }
        else if (previousSurface == Showing.straights)
        {
            ResetStraights();
        }
        else if (previousSurface == Showing.doors)
        {
            ResetDoors();
        }
        else if (previousSurface == Showing.junctions)
        {
            ResetJunctions();
        }
        else if (previousSurface == Showing.traps)
        {
            ResetTraps();
        }
        else if (previousSurface == Showing.trail)
        {
            ResetTrail();
        }

        if (isPersistant == false)
        {
            if (whatsShowing == Showing.corners)
            {
                UpdateCorners();
            }
            else if (whatsShowing == Showing.straights)
            {
                UpdateStraights();
            }
            else if (whatsShowing == Showing.doors)
            {
                UpdateDoors();
            }
            else if (whatsShowing == Showing.junctions)
            {
                UpdateJunctions();
            }
            else if (whatsShowing == Showing.traps)
            {
                UpdateTraps();
            }
            else if (whatsShowing == Showing.trail)
            {
                UpdateTrail();
            }
        }
    }

    void UpdateCorners()
    {
        foreach (GameObject go in listCorners)
        {
            go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }

    void UpdateStraights()
    {
        foreach (GameObject go in listStraights)
        {
            go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }

    void UpdateDoors()
    {
        foreach (GameObject go in listDoors)
        {
            go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }

    void UpdateJunctions()
    {
        foreach (GameObject go in listJunctions)
        {
            go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }

    void UpdateTraps()
    {
        foreach (GameObject go in listTraps)
        {
            go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }

    void UpdateTrail()
    {
        GameObject.Find("Player").GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
    }


    void ResetCorners()
    {
        foreach (GameObject go in listCorners)
        {
            go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
    }

    void ResetStraights()
    {
        foreach (GameObject go in listStraights)
        {
            go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
    }

    void ResetDoors()
    {
        foreach (GameObject go in listDoors)
        {
            go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
    }

    void ResetJunctions()
    {
        foreach (GameObject go in listJunctions)
        {
            go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
    }

    void ResetTraps()
    {
        foreach (GameObject go in listTraps)
        {
            go.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
    }

    void ResetTrail()
    {
        GameObject.Find("Player").GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
    }
}
