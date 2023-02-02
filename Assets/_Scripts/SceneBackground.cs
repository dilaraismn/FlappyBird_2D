using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneBackground : MonoBehaviour
{
    [SerializeField] private float bgMoveSpeed;
    private RawImage _rawImage;

    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
    }

    private void Update()
    {
        if (!UIManager.isGameStarted) return;
        if (Player.isPause) return;
        _rawImage.material.mainTextureOffset += new Vector2(bgMoveSpeed * Time.deltaTime, 0);
    }
}
