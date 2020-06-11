using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    Vector2 mouseLook;
    Vector2 smoothV;
    
    public float sencetivity = 5.0f;
    public float smoothing = 2.0f;
    
    GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
      var md = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
      md = Vector2.Scale(md, new Vector2(sencetivity * smoothing, sencetivity * smoothing));
      
      smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1.0f / smoothing);
      smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1.0f / smoothing);
      
      mouseLook+=smoothV;
      mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);


      transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
      character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

    }
}
