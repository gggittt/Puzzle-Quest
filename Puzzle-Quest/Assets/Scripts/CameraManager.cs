using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraManager : MonoBehaviour
{
    
    [SerializeField] private float _emptySpaceSize = 1f;
    public void SetupCamera(int width, int height)
    {
        Camera.main.transform.position = new Vector3((width - 1) / 2f, (height - 1) / 2f, -10f);

        float aspectRatio = Screen.width / Screen.height;

        float verticalSize = height / 2f + _emptySpaceSize;

        float horizontalSize = (width / 2f + _emptySpaceSize) / aspectRatio;

        Camera.main.orthographicSize = (verticalSize > horizontalSize) ? verticalSize : horizontalSize;

    }

}


