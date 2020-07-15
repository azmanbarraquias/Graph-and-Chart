using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wedge
{
    public string title;

    [Range(1f, 100f)]
    public float value;

    public Color color;

}
