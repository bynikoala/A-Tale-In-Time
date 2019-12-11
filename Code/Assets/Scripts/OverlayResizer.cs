using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayResizer : MonoBehaviour
{
    private Rect overlayRect;
    public Canvas parentCanvas;
    // Start is called before the first frame update
    void Start()
    {
        overlayRect = this.GetComponent<RectTransform>().rect;
    }

    // Update is called once per frame
    void Update()
    {
        Rect currentsize = parentCanvas.gameObject.GetComponent<RectTransform>().rect;

        overlayRect.height = currentsize.height;
        overlayRect.width = currentsize.width;

        this.GetComponent<RectTransform>().sizeDelta = new Vector2(overlayRect.width, overlayRect.height);
    }
}
