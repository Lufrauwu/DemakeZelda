using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{
    [SerializeField] private GameObject _wolfPlayer = default;
    [SerializeField] private GameObject _linkPlayer = default;
    [SerializeField] private GameObject _wolfCamera = default;
    [SerializeField] private GameObject _linkCamera = default;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_wolfPlayer.activeSelf)
            {
                _wolfCamera.SetActive(false);
                _wolfPlayer.SetActive(false);
                _linkCamera.SetActive(true);
                _linkPlayer.SetActive(true);
                _linkPlayer.transform.position = _wolfPlayer.transform.position;
            }
            else
            {
                _linkCamera.SetActive(false);
                _linkPlayer.SetActive(false);
                _wolfCamera.SetActive(true);
                _wolfPlayer.SetActive(true);
                _wolfPlayer.transform.position = _linkPlayer.transform.position;
            }
        }
    }
}
