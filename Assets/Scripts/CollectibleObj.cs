using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObj : MonoBehaviour
{
    bool isCollect;
    int index;
    public Collector collector;

    void Start()
    {
        isCollect = false;
    }

    
    void Update()
    {
        if (isCollect == true)
        {

            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.CompareTag("Obstacle"))
        {
            collector.YukseklikAzalt();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public bool GetisCollect()
    {
        return isCollect;
    }

    public void IsCollected()
    {
        isCollect = true;
    }

    public void IndexAyarla(int index)
    {
        this.index = index;
    }

}
