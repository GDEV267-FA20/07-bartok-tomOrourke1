using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    public GameObject[] holders;
    public Color[] colors;

    public bool createHolders = false;


    private void Start()
    {
        StartSender(Random.Range(0, holders.Length));


    }

    void StartSender(int x)
    {
        holders[x].GetComponent<ColorHolder>().SpawnColorSender();

    }

    public GameObject GetTarget(ColorHolder holder)
    {
        GameObject holderk = holder.gameObject;
        bool nextHolder = true;
        while(nextHolder)
        {
            int x = Random.Range(0, holders.Length);
            if (holderk != holders[x])
            {
                holderk = holders[x];
                nextHolder = false;
            }
        }

        if (holderk == null)
            return null;
        return holderk;
    }

    public Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Length)];
    }




    public bool CheckColors()
    {
        Color previous = holders[0].GetComponent<ColorHolder>().Colors;
        bool colorCheck = true;
        for(int i = 0; i < holders.Length; i++)
        {
            if(holders[i].GetComponent<ColorHolder>().Colors != previous)
            {
                colorCheck = false;
            }
            previous = holders[i].GetComponent<ColorHolder>().Colors;
        }
        return colorCheck;
    }
}
