﻿using UnityEngine;
using UnityEngine.UI;
using System.IO;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using System.Collections;

public class UIMakerScript : MonoBehaviour
{

    //http://chikkooos.blogspot.com/2015/03/new-ui-implementation-using-c-scripts.html

    private const int LayerUI = 5;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject CreateCanvas(Transform parent)
    {
        // create the canvas
        GameObject canvasObject = new GameObject("Canvas");
        canvasObject.layer = LayerUI;

        RectTransform canvasTrans = canvasObject.AddComponent<RectTransform>();

        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.pixelPerfect = true;

        CanvasScaler canvasScal = canvasObject.AddComponent<CanvasScaler>();
        canvasScal.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScal.referenceResolution = new Vector2(300, 200);

        GraphicRaycaster canvasRayc = canvasObject.AddComponent<GraphicRaycaster>();

        canvasObject.transform.SetParent(parent);

        return canvasObject;
    }

    public GameObject CreateEventSystem(Transform parent)
    {
        GameObject esObject = new GameObject("EventSystem");

        EventSystem esClass = esObject.AddComponent<EventSystem>();
        esClass.sendNavigationEvents = true;
        esClass.pixelDragThreshold = 5;

        StandaloneInputModule stdInput = esObject.AddComponent<StandaloneInputModule>();
        stdInput.horizontalAxis = "Horizontal";
        stdInput.verticalAxis = "Vertical";

        esObject.transform.SetParent(parent);

        return esObject;
    }

    public GameObject CreatePanel(Transform parent)
    {
        GameObject panelObject = new GameObject("Panel");
        panelObject.transform.SetParent(parent);

        panelObject.layer = LayerUI;

        RectTransform trans = panelObject.AddComponent<RectTransform>();
        trans.anchorMin = new Vector2(0, 0);
        trans.anchorMax = new Vector2(1, 1);
        trans.anchoredPosition = new Vector2(0, 0);
        trans.offsetMin = new Vector2(0, 0);
        trans.offsetMax = new Vector2(0, 0);
        trans.localPosition = new Vector3(0, 0, 0);
        trans.sizeDelta = new Vector2(0, 0);
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        CanvasRenderer renderer = panelObject.AddComponent<CanvasRenderer>();

		panelObject.AddComponent<Image> ().color = Color.black;

        //image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");

        return panelObject;
    }

    public GameObject CreateText(Transform parent, float x, float y,
                                      float w, float h, string message, int fontSize)
    {
        GameObject textObject = new GameObject("Text");

		textObject.AddComponent<CanvasRenderer>();

        textObject.transform.SetParent(parent);

        textObject.layer = LayerUI;

        var trans = textObject.AddComponent<RectTransform>();
		trans.sizeDelta = new Vector2(w,h);
        trans.anchoredPosition3D = new Vector3(0, 0, 0);
        trans.anchoredPosition = new Vector2(x, y);
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        trans.localPosition.Set(0, 0, 0);

        var text = textObject.AddComponent<Text>();
        text.supportRichText = true;
        text.text = message;
        text.fontSize = fontSize;
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        text.alignment = TextAnchor.MiddleCenter;
        text.horizontalOverflow = HorizontalWrapMode.Overflow;
		text.color = Color.green;

		//trans.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, 34);

        return textObject;
    }

    public GameObject CreateButton(Transform parent, float x, float y, float w, float h, string message,
                                        UnityAction eventListner)
    {

        GameObject buttonObject = new GameObject("Button");

        buttonObject.transform.SetParent(parent);

        buttonObject.layer = LayerUI;

        RectTransform trans = buttonObject.AddComponent<RectTransform>();
        SetSize(trans, new Vector2(w, h));
        trans.anchoredPosition3D = new Vector3(0, 0, 0);
        trans.anchoredPosition = new Vector2(x, y);
        trans.localScale = new Vector3(.50f, .50f, 1.0f);
        trans.localPosition.Set(0, 0, 0);

        buttonObject.AddComponent<CanvasRenderer>();

		buttonObject.AddComponent<Image>().color = Color.red;

        Button button = buttonObject.AddComponent<Button>();
        button.interactable = true;
        button.onClick.AddListener(eventListner);

        GameObject textObject = CreateText(buttonObject.transform, 0, 0, 0, 34,
                                                   message, 24);

        return buttonObject;
    }

    private static void SetSize(RectTransform trans, Vector2 size)
    {
        Vector2 currSize = trans.rect.size;
        Vector2 sizeDiff = size - currSize;
		trans.offsetMin = trans.offsetMin -
		new Vector2 (sizeDiff.x * trans.pivot.x,
				sizeDiff.y * trans.pivot.y);
        
		trans.offsetMax = trans.offsetMax +
                                  new Vector2(sizeDiff.x * (1.0f - trans.pivot.x),
				sizeDiff.y * (1.0f - trans.pivot.y));
    }
}