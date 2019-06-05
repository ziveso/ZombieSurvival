using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public bool visible = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = this.visible;
    }

}
