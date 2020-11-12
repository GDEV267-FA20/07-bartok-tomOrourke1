using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHolder : MonoBehaviour
{
    private Color color;
    public Color Colors
    {
        get => color;
        set => color = value;
    }

    private GameObject target;
    private ColorManager colManager;

    public GameObject colorSender;

    private GameObject currentSender;

    private void Awake()
    {
       color = GetComponent<SpriteRenderer>().color;
       if(colManager == null)
        {
            colManager = FindObjectOfType<ColorManager>();
        }
    }



    public void SpawnColorSender()
    {
        if (colManager.CheckColors())
            return;

        Color tempCol = colManager.GetRandomColor();

        currentSender = Instantiate(colorSender);
        currentSender.transform.position = transform.position;
        currentSender.GetComponent<ColorSender>().Color = tempCol;
        currentSender.GetComponent<SpriteRenderer>().color = tempCol;
        currentSender.GetComponent<ColorSender>().Target = colManager.GetTarget(this);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == currentSender)
        {
            return;
        }
        

        ColorSender sender = other.gameObject.GetComponent<ColorSender>();
        color = sender.Color;
        SpawnColorSender();
        Destroy(sender.gameObject);

        //color = colManager.GetRandomColor();
        //color = other.GetComponent<ColorSender>().Color;
        GetComponent<SpriteRenderer>().color = color;
    }


}
