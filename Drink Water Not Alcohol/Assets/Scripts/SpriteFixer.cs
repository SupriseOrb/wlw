using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFixer : MonoBehaviour
{
    void Awake()
    {
        transform.position = new Vector3(transform.position.x, 
                                            transform.position.y, 
                                            transform.position.y * 0.01f);
                                            
    }
}
