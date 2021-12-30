using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public GameObject mainCube;
    int height;

    void Start()
    {
        mainCube = GameObject.Find("mainCube");

    }

    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        mainCube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);
    }

    public void YukseklikAzalt()
    {
        height--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Collector"&&other.gameObject.GetComponent<CollectibleObj>().GetisCollect()==false)
        {
            height += 1;
            other.gameObject.GetComponent<CollectibleObj>().IsCollected();
            other.gameObject.GetComponent<CollectibleObj>().IndexAyarla(height);
            other.gameObject.transform.parent = mainCube.transform;

        }
    }
}
