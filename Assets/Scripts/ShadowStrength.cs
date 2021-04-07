using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowStrength : MonoBehaviour
{
    public Slider StrengthBar;

    private float maxStrength = 7;
    public float currentStrenth;

    public static ShadowStrength instance;

    private WaitForSeconds regenTick = new WaitForSeconds(0.05f);
    private Coroutine regen;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentStrenth = maxStrength;
        StrengthBar.maxValue = maxStrength;
        StrengthBar.value = maxStrength;
    }

    public bool UseStrength(float amount)
    {
        if (currentStrenth - amount >= 0)
        {
            currentStrenth -= amount;
            StrengthBar.value = currentStrenth;

            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStrength());
            return true;
        }
        else return false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RegenStrength()
    {
        yield return new WaitForSeconds(1);

        while(currentStrenth < maxStrength)
        {
            currentStrenth += maxStrength / 100;
            StrengthBar.value = currentStrenth;
            yield return regenTick;
        }
        regen = null;
    }
}
