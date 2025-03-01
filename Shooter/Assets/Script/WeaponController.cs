using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Transform _weapon1;
    [SerializeField] Vector3 _weapon1ActivePosition;
    [SerializeField] Vector3 _weapon1PassivePosition;

    [SerializeField] Transform _weapon2;
    [SerializeField] Vector3 _weapon2ActivePosition;
    [SerializeField] Vector3 _weapon2PassivePosition;

    [SerializeField] KeyCode _triggerKey = KeyCode.C;

    private int _weaponIndex = 1;

    private Quaternion localRotation;

    private bool _canChange = true;

    private void Start()
    {
        localRotation = _weapon1.localRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_triggerKey) && _canChange)
        {
            _canChange = false;
            _weaponIndex += 1;
            if (_weaponIndex > 1)
            {
                _weaponIndex = 0;
            }

            switch (_weaponIndex)
            {
                case 0:
                    _weapon1.gameObject.SetActive(true);
                    _weapon1.localPosition = _weapon1ActivePosition;
                    _weapon1.localRotation = localRotation;
                    StartCoroutine(Takeoff(_weapon2));
                    Invoke("TakeOffWeapon2", 1);
                    break;
                case 1:
                    _weapon2.gameObject.SetActive(true);
                    _weapon2.localPosition = _weapon2ActivePosition;
                    _weapon2.localRotation = localRotation;
                    StartCoroutine(Takeoff(_weapon1));
                    Invoke("TakeOffWeapon1", 1);
                    break;
            }
        }

    }

    private void TakeOffWeapon1()
    {
        _weapon1.gameObject.SetActive(false);
    }
    private void TakeOffWeapon2()
    {
        _weapon2.gameObject.SetActive(false);
    }

    IEnumerator Takeoff(Transform weapon)
    {
        for (int i = 0; i <= 100; i++)
        {
            weapon.localPosition = new Vector3(weapon.localPosition.x, weapon.localPosition.y - 0.05f, weapon.localPosition.z - 0.02f);
            weapon.localRotation = new Quaternion(weapon.localRotation.x - 0.05f, weapon.localRotation.y, weapon.localRotation.z, 1);
            yield return new WaitForSeconds(0.001f);
        }

        _canChange = true;
    }



}
