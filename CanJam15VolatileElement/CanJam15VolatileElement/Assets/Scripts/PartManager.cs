using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartManager : MonoBehaviour 
{

<<<<<<< HEAD
	ColorPicker cp;
=======
    ColorPicker cp;
>>>>>>> Matt

    public Color colorCorners, colorStraights, colorDoors, colorJunctions, colorTraps;

    public List<GameObject> listCorners = new List<GameObject>();
    public List<GameObject> listStraights = new List<GameObject>();
    public List<GameObject> listDoors = new List<GameObject>();
    public List<GameObject> listJunctions = new List<GameObject>();
    public List<GameObject> listTraps = new List<GameObject>();

    public enum Showing { corners, straights, doors, junctions, traps };
    Showing whatsShowing;

    Showing previousSurface;

    bool isPersistant = false;

	// Use this for initialization
	void Start () 
    {
<<<<<<< HEAD
		cp = GameObject.Find("ColorPicker").GetComponent<ColorPicker>();
=======
        cp = GameObject.Find("ColorPicker").GetComponent<ColorPicker>();

>>>>>>> Matt
        colorCorners = cp.Picker();
        colorStraights = cp.Picker();
        colorDoors = cp.Picker();
        colorJunctions = cp.Picker();
        colorTraps = cp.Picker();
	}

    public void NewObject(GameObject passedObject, Showing passedShowing)
    {
        

        if (passedShowing == Showing.corners)
        {
            passedObject.GetComponent<Renderer>().material.color = colorCorners;
            passedObject.GetComponent<Renderer>().material.SetColor("_Emission", colorCorners);

            listCorners.Add(passedObject);
        }
        else if (passedShowing == Showing.straights)
        {
            passedObject.GetComponent<Renderer>().material.color = colorStraights;
            passedObject.GetComponent<Renderer>().material.SetColor("_Emission", colorStraights);

            listStraights.Add(passedObject);
        }
        else if (passedShowing == Showing.doors)
        {
            passedObject.GetComponent<Renderer>().material.color = colorDoors;
            passedObject.GetComponent<Renderer>().material.SetColor("_Emission", colorDoors);

            listDoors.Add(passedObject);
        }
        else if (passedShowing == Showing.junctions)
        {
            passedObject.GetComponent<Renderer>().material.color = colorJunctions;
            passedObject.GetComponent<Renderer>().material.SetColor("_Emission", colorJunctions);

            listJunctions.Add(passedObject);
        }
        else if (passedShowing == Showing.traps)
        {
            passedObject.GetComponent<Renderer>().material.color = colorTraps;
            passedObject.GetComponent<Renderer>().material.SetColor("_Emission", colorTraps);
        }
    }

    void NewSurface(Showing passedShow)
    {
        if (passedShow == Showing.corners)
        {
            previousSurface = whatsShowing;
            whatsShowing = Showing.corners;
        }
        else if (passedShow == Showing.straights)
        {
            previousSurface = whatsShowing;
            whatsShowing = Showing.straights;
        }
        else if (passedShow == Showing.doors)
        {
            previousSurface = whatsShowing;
            whatsShowing = Showing.doors;
        }
        else if (passedShow == Showing.junctions)
        {
            previousSurface = whatsShowing;
            whatsShowing = Showing.junctions;
        }
        else if (passedShow == Showing.traps)
        {
            previousSurface = whatsShowing;
            whatsShowing = Showing.traps;
        }

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
}
