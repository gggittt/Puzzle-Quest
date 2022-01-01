using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SampleTest : MonoBehaviour
{


    public void SomeMethod()
    {
        transform.localPosition = Vector3.back;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.back, 4f);
        
    }

}


