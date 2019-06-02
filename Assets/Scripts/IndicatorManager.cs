using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : Singleton<IndicatorManager>
{
    public RectTransform labelContainer;
    public Indicator IndicatorPrefab;
    public Indicator AddIndicator(GameObject target,
    Color color,Sprite sprite = null ){
        var newIndicator = Instantiate(IndicatorPrefab);
        newIndicator.target = target.transform;

        newIndicator.color = color;

        if(sprite != null){
            newIndicator.GetComponent<Image>().sprite = sprite;
        }

        newIndicator.transform.SetParent(labelContainer,false);
        return newIndicator;
    }
}
