using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _satelliteRemainingImage;
    [SerializeField] private Sprite[] _satRemainingArray;

    public void SatellitesRemaining(int currentValue)
    {
        _satelliteRemainingImage.sprite = _satRemainingArray[currentValue];
    }



}
