using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestView : View {

    private Button closeButton;
    protected override void Awake()
    {
        base.Awake();
        closeButton = transform.Find("Show/Close").GetComponent<Button>();
        closeButton.onClick.AddListener(OnCloseClick);
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void Show()
    {
        base.Show();
        Debug.Log("Show");
    }

    private void OnCloseClick()
    {
        Debug.Log("Close");
    }
}
