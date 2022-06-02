using UnityEngine;

public class ActivateWolfVision : MonoBehaviour
{
    [SerializeField] private GameObject _secret = default;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _secret.SetActive(!_secret.activeSelf);
        }
    }
}
