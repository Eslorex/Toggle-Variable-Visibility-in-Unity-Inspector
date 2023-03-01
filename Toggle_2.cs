using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_2 : MonoBehaviour
{
    [System.Serializable]
    public class MyCategory
    {
        public float myFloat;
        public int myInt;
    }

    public MyCategory category1;
    public MyCategory category2;
}
