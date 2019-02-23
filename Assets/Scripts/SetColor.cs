using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetColor : MonoBehaviour, IPointerClickHandler {

    public Color color;

    public void OnPointerClick(PointerEventData eventData)
    {
        PaintFillTool.ColorToSet = color;
    }

    // Use this for initialization
    void Start () {
        this.GetComponent<Renderer>().material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
