using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _satelliteRemainingImage;
    [SerializeField] private Sprite[] _satRemainingArray;
    [SerializeField] private GameObject _alertText;

    private void Start()
    {
        StartCoroutine(AlertFlicker());
    }

    public void SatellitesRemaining(int currentValue)
    {
        _satelliteRemainingImage.sprite = _satRemainingArray[currentValue];

        if (currentValue == 0)
        {
            Debug.Log("currentValue == 1");
            _satelliteRemainingImage.enabled = false;
        }
    }

    IEnumerator AlertFlicker()
    {
        while (true)
        {
            _alertText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _alertText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
