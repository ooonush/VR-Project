using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UVFlashLightSource : MonoBehaviour
{
    [SerializeField] private Material _UVShader;
    [SerializeField] private Light _light;
    
    void Update()
    {
        _UVShader.SetVector("_LightPosition", _light.transform.position);
        _UVShader.SetVector("_LightDirection", -_light.transform.forward);
        _UVShader.SetFloat("_LightAngle", _light.spotAngle);
    }
}
