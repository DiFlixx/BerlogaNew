using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
   
    Material bgMaterial;
    public float scrollSpeed;
    public bool isMoving = true;
   
        
    // Start is called before the first frame update
    void Start()
    {
        bgMaterial = GetComponent<Renderer>().material;
    }

      void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 offset = new Vector2(scrollSpeed * Time.time, 0);
            bgMaterial.mainTextureOffset = offset;
        }
      
    }

    
}
