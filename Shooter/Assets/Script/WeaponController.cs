using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Transform _weapon0;
    [SerializeField] Vector3 _weapon0ActivePosition;
    [SerializeField] Vector3 _weapon0PassivePosition;

    [SerializeField] Transform _weapon1;
    [SerializeField] Vector3 _weapon1ActivePosition;
    [SerializeField] Vector3 _weapon1PassivePosition;

    [SerializeField] Transform _weapon2;
    [SerializeField] Vector3 _weapon2ActivePosition;
    [SerializeField] Vector3 _weapon2PassivePosition;

    [SerializeField] KeyCode _triggerKey = KeyCode.C;

    [SerializeField] private int _weaponIndex = 0;

    private Quaternion localRotation;

    private bool _canChange = true;

    private void Start()
    {
        localRotation = _weapon0.localRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_triggerKey) && _canChange)
        {
            _canChange = false;
            _weaponIndex += 1;
            if (_weaponIndex > 2)
            {
                _weaponIndex = 0;
            }

            switch (_weaponIndex)
            {
                case 0:
                    _weapon0.gameObject.SetActive(true);
                    _weapon0.localPosition = _weapon0ActivePosition;
                    _weapon0.localRotation = localRotation;
                    StartCoroutine(Takeoff(_weapon2));
                    Invoke("TakeOffWeapon2", 1);
                    break;
                case 1:
                    _weapon1.gameObject.SetActive(true);
                    _weapon1.localPosition = _weapon1ActivePosition;
                    _weapon1.localRotation = localRotation;
                    StartCoroutine(Takeoff(_weapon0));
                    Invoke("TakeOffWeapon0", 1);
                    break;
                case 2:
                    _weapon2.gameObject.SetActive(true);
                    _weapon2.localPosition = _weapon2ActivePosition;
                    _weapon2.localRotation = localRotation;
                    StartCoroutine(Takeoff(_weapon1));
                    Invoke("TakeOffWeapon1", 1);
                    break;
            }
        }

    }

    private void TakeOffWeapon0()
    {
        _weapon0.gameObject.SetActive(false);
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
