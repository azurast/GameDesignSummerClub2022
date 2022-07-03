using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
    MeshRenderer mr= GetComponent<MeshRenderer>();
    Material mat = mr.material;
    Vector2 offset = mat.mainTextureOffset;
    offset.x += Time.deltaTime;

    mat.mainTextureOffset = offset;
    }
}
