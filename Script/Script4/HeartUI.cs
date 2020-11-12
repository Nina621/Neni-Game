using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Sprite [] Heartsprite;

    public Nensi Nensi;

    public Image Heart;

    // Use this for initialization
    void Start()
    {
        Nensi = GameObject.FindGameObjectWithTag("Nensi").GetComponent<Nensi>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Nensi.ourHealth > 6)
            Nensi.ourHealth = 6;

        if (Nensi.ourHealth < 0)
            Nensi.ourHealth = 0;

        Heart.sprite = Heartsprite[Nensi.ourHealth];
    }
}