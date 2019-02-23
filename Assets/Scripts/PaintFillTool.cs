using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class   PaintFillTool : MonoBehaviour, IPointerClickHandler {

    public static Color ColorToSet;

    Material Material;
    Texture2D Image;
    Texture2D ImageCopy;

    // Use this for initialization
    void Start () {
        Image = GetComponent<Renderer>().sharedMaterial.mainTexture as Texture2D;
        ImageCopy = new Texture2D(Image.width, Image.height, Image.format, Image.mipmapCount > 1);
        ImageCopy.LoadRawTextureData(Image.GetRawTextureData());


	}

    // Update is called once per frame
    void Update()
    {

    }


    private void OnApplicationQuit()
    {
        Image.LoadRawTextureData(ImageCopy.GetRawTextureData());
        Image.Apply();
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);


        GameObject pointerPosition = new GameObject();
        pointerPosition.transform.position = hit.point;
        pointerPosition.transform.SetParent(hit.collider.transform);

        int newx = (int)(Image.width * (pointerPosition.transform.localPosition.x + 0.5f));
        int newY = (int)(Image.height * (pointerPosition.transform.localPosition.y + 0.5f));
        Destroy(pointerPosition);

        ImageUtilss.FloodFillArea(Image, newx, newY, ColorToSet);
        Image.Apply();
    }    
}
