using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLogic : MonoBehaviour
{

    //Referances
    [SerializeField] public Light Sun;
    [SerializeField] public LightingPreset Preset;

    //Brukes for å endre farge til månen
    public bool EnableBloodmoon = true;
    public Material MoonMaterial;

    //10 Minutter
    public float SecondsInADay = 300;

    [SerializeField, Range(0, 300)] private float TimeOfDay;

    void Start()
    {
        MoonMaterial.SetColor("_Color", Color.white);
        MoonMaterial.SetColor("_EmissionColor", Color.white);
    }


    // Update is called once per frame
    void Update()
    {
        if (Preset == null || Sun == null)
            return;

        if (Application.isPlaying)
        {
            
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= SecondsInADay; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / SecondsInADay);
        }
        else
        {
            UpdateLighting(TimeOfDay / SecondsInADay);
        }

        if((TimeOfDay > 0 && TimeOfDay < 10) && EnableBloodmoon)
        {
            if(MoonMaterial != null)
            {
                MoonMaterial.SetColor("_Color",Color.black);
                MoonMaterial.SetColor("_EmissionColor", Color.red);
            }
            else
            {
                Debug.Log("Moon material not defined. No bloodmoon :(");
            }
            GetComponent<SunLogic>().enabled = false;
        }
    }

    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        
        if (Sun != null)
        {
            Sun.color = Preset.DirectionalColor.Evaluate(timePercent);

            Sun.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 85f, 0));
        }

    }
}
