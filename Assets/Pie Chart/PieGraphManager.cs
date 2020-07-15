using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PieGraphManager : MonoBehaviour
{
    [Header("Setup")]
    public Image wedgePrefabs;

    [Space]
    public Wedge[] wedges;

    private void Start()
    {
        ClearAll();
        CreateGraph();
    }

    public void CreateGraph()
    {
        float total = wedges.Sum(w => w.value);
        float zRotation = 0;

        foreach (Wedge wedge in wedges)
        {
            Image newWedge = Instantiate(wedgePrefabs);

            newWedge.name = wedge.title;

            Transform child = newWedge.transform.GetChild(0);

            newWedge.transform.SetParent(transform, false);

            child.GetComponent<TextMeshProUGUI>().text = wedge.title;

            newWedge.color = wedge.color;

            newWedge.fillAmount = wedge.value / total;

            newWedge.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));

            child.rotation = Quaternion.Euler(0.0f, 0.0f, newWedge.transform.rotation.z);

            zRotation -= newWedge.fillAmount * 360f;
        }
    }

    public void ClearAll()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

}


