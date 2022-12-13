using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UVFlashLightSource : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private List<Material> _UVMaterials;

    void Update()
    {
        foreach (Material uvMaterial in _UVMaterials)
        {
            uvMaterial.SetVector("_LightPosition", _light.transform.position);
            uvMaterial.SetVector("_LightDirection", -_light.transform.forward);
            uvMaterial.SetFloat("_LightAngle", _light.spotAngle);
        }
    }
}
