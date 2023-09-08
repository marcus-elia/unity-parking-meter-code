using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnocentEntity : MonoBehaviour
{
    private Transform carTransform;
    private float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(carTransform.position, transform.position) < radius)
        {
            gameObject.SetActive(false);
            ScoreManager.score -= 1;
        }
    }
    public void SetCarTransform(Transform t)
    {
        carTransform = t;
    }
    public void SetRadius(float r)
    {
        radius = r;
    }
}
