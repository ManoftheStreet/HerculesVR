using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WindowsMR.Input;

public class UIimageManager : MonoBehaviour
{
    public GameObject Arrow;

    public GameObject[] constellationImages;

    public GameObject ground;

    public Transform g;
    
    GameObject viewer;

    public float rotSpeed = 1f; 

    Vector3 springRot;
    Vector3 summerRot;
    Vector3 autumnRot;
    Vector3 winterRot;
    Vector3 southRot;
    Vector3 northRot;

    Quaternion startRot;
    Quaternion spring;
    Quaternion summer;
    Quaternion autumn;
    Quaternion winter;
    Quaternion south;
    Quaternion north;

    bool obj = false;
    bool springRotating = false;
    bool summerRotating = false;
    bool autumnRotating = false;
    bool winterRotating = false;
    bool southRotating = false;
    bool northRotating = false;

    Transform Arrowposition;

    void Start()
    {
        viewer = GameObject.Find("ConstellationViewer");
        springRot = new Vector3(51.412f, -70.8f, 15.227f);
        summerRot = new Vector3(-22.14f, 17.86f, 49.477f);
        autumnRot = new Vector3(-52.95f, 86.797f, 2.558f);
        winterRot = new Vector3(8.628f, 186.566f, -52.504f);
        southRot = new Vector3(0f, 0f, 125f);
        northRot = new Vector3(0f, 0f, 53f);

        startRot = g.rotation;
        spring = Quaternion.Euler(springRot);
        summer = Quaternion.Euler(summerRot);
        autumn = Quaternion.Euler(autumnRot);
        winter = Quaternion.Euler(winterRot);
        south = Quaternion.Euler(southRot);
        north = Quaternion.Euler(northRot);

    }

    // Update is called once per frame
    void Update()
    {
        if (southRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, south, step);

            if (Quaternion.Angle(g.rotation, south) < 0.1f)
            {
                southRotating = false;
            }
        }
        else if (northRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, north, step);

            if (Quaternion.Angle(g.rotation, north) < 0.1f)
            {
                northRotating = false;
            }
        }
        else if (springRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, spring, step);

            if(Quaternion.Angle(g.rotation, spring) < 0.1f)
            {
                springRotating = false;
            }
        }
        else if (summerRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, summer, step);

            if (Quaternion.Angle(g.rotation, summer) < 0.1f)
            {
                summerRotating = false;
            }
        }
        else if (autumnRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, autumn, step);

            if (Quaternion.Angle(g.rotation, autumn) < 0.1f)
            {
                autumnRotating = false;
            }
        }
        else if (winterRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, winter, step);

            if (Quaternion.Angle(g.rotation, winter) < 0.1f)
            {
                winterRotating = false;
            }
        }
    }
    public void RemoveGround()
    {
        if (!obj)
        {
            ground.SetActive(true);
            obj = true;
        }
        else
        {
            ground.SetActive(false);
            obj = false;
        }
    }
    public void SouthernRot()
    {
        southRotating = true;
    }
    public void northernRot()
    {
        northRotating = true;
    }

    public void ConstellationImage(int index)
    {
        for(int i = 0; i < constellationImages.Length; i++)
        {
            if(i == index)
            {
                if (constellationImages[i].activeSelf)
                {
                    //constellationImages[i].SetActive(false);
                }
                else
                {
                    //constellationImages[i].SetActive(true);
                    Arrow.transform.rotation = 
                        Quaternion.LookRotation(Arrow.transform.position - constellationImages[i].transform.position);
                }
            }
            else
            {
                // constellationImages[i].SetActive(false);
            }
        }
    }
    
}
