using UnityEngine;
using System.Collections;

public class BoostPickup : PickupAbstract
{
    GameObject play;

    void Start()
    {
        ChangeColor();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            //Color randColor = colorPicker.Picker();
            //play = collision.collider.gameObject;
            //collision.collider.GetComponent<TrailRenderer>().material.color = randColor;
            //partManager.NewSurface(PartManager.Showing.trail);
            //collision.collider.GetComponent<TrailRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;

                        collision.collider.GetComponent<CharControler>().speed = 60;

            collision.collider.GetComponent<CharControler>().methodName();

            Debug.Log("Text");

            Destroy(gameObject);
        }
    }
    public override void Triggers()
    {
        //Necessary override
    }



}
