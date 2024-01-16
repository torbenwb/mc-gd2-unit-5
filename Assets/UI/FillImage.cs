using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FillImage : MonoBehaviour, IIntListener
{
    Image image;
    void Awake() => image = GetComponent<Image>();
    public void IntUpdate(IntWrapper intWrapper)
    {
        image.fillAmount = intWrapper.Ratio;
    }
}
