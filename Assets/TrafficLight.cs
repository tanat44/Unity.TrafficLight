using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public GameObject Bottom;
    public GameObject Middle;
    public GameObject Top;
    public Material BlackMaterial;
    public Material GrayMaterial;
    public Material RedMaterial;
    public Material GreenMaterial;
    public Material YellowMaterial;

    public int CurrentIndex;
    void Start()
    {
        SetLight(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ++CurrentIndex;
            if (CurrentIndex > 2)
                CurrentIndex = 2;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            --CurrentIndex;
            if (CurrentIndex < 0)
                CurrentIndex = 0;
        }

        SetLight(CurrentIndex);

    }

    void SetLight(int value)
    {
        if (value == 0)
        {
            ChangeMaterial(Bottom, RedMaterial);
            ChangeMaterial(Middle);
            ChangeMaterial(Top);
        }
        else if (value == 1)
        {
            ChangeMaterial(Bottom);
            ChangeMaterial(Middle, YellowMaterial);
            ChangeMaterial(Top);
        }
        else if (value == 2)
        {
            ChangeMaterial(Bottom);
            ChangeMaterial(Middle);
            ChangeMaterial(Top, GreenMaterial);
        }
    }

    void ChangeMaterial(GameObject go, Material newMaterial = null)
    {
        var renderer = go.GetComponent<Renderer>();
        var emission = go.GetComponent<ParticleSystem>().emission;
        if (newMaterial)
        {
            renderer.material = newMaterial;
            emission.enabled = true;
        }
        else
        {
            renderer.material = GrayMaterial;
            emission.enabled = false;
        }
    }
}
