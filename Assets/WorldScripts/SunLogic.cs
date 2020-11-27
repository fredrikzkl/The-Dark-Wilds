using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLogic : MonoBehaviour
{

    //Referances
    [SerializeField] public Light Sun;
    [SerializeField] public LightingPreset Preset;

    [SerializeField, Range(0, 24)] private float TimeOfDay;

    // Update is called once per frame
    void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 24; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
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
