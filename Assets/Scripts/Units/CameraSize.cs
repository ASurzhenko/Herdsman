using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public enum ScreenCodes
    {
        Normal,
        IphoneX,
        Ipad
    };
    Camera myCamera;
    private ScreenCodes CurrentWorkingSize;
    private void Start() {
        CurrentWorkingSize = GetCurrentScreenType();
        myCamera = GetComponent<Camera>();
        if(CurrentWorkingSize == ScreenCodes.IphoneX)
            myCamera.orthographicSize = 4.1f;
        else if(CurrentWorkingSize == ScreenCodes.Ipad)
        {
            myCamera.transform.position += new Vector3(2, 0, 0);
        }   
    }
    public ScreenCodes GetCurrentScreenType()
    {
        float x = Screen.width;
        float y = Screen.height;

        float ratio = x / y;

        if (ratio > 1.8f)
        {
            // iPhoneX
            return ScreenCodes.IphoneX;
        }
        else if (ratio < 1.5f)
        {
            // ipad
            return ScreenCodes.Ipad;
        }
        else
        {
            // normal
            return ScreenCodes.Normal;
        }
    }
}
