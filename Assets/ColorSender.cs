using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSender : MonoBehaviour
{

    private Color color;
    private GameObject target;
    public float speed = 5f;

    public GameObject Target
    {
        get => target;
        set => target = value;
    }
    public Color Color
    {
        get => color;
        set => color = value;
    }


    private void Update()
    {
        if(target != null)
        {
            Vector3 targetPos = target.transform.position;
            Vector3 dir = (targetPos - transform.position).normalized;

            transform.position += (dir * Time.deltaTime * speed);

        }
    }



}
