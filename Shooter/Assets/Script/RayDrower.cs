using UnityEngine;
using System;
using UnityEngine.UIElements;

public class RayDrower : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _clock;
    [SerializeField] private float _clockSpeed;

    private Ray _ray1;
    private Ray _ray2;

    private Vector3 _mousePosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _clock.Rotate(0, 0, _clockSpeed * Time.deltaTime);
        _mousePosition = Input.mousePosition;
        _mousePosition.z = 0;
        _ray1 = _cam.ScreenPointToRay(_mousePosition);
        _ray2 = new Ray(_startPosition.position, _targetPosition.position);

        Debug.DrawRay(_ray1.origin, _ray1.direction * _distance, Color.red);
        Debug.DrawRay(_ray2.origin, _ray2.direction * _distance, Color.red);



        RaycastHit hit1;
        RaycastHit hit2;

        if (Physics.Raycast(_ray1, out hit1))
        {
            if (Physics.Raycast(_ray2, out hit2))
            {
                // Если пересечение есть, вы можете получить информацию о нем
                Transform objectHit1 = hit1.transform;
                Transform objectHit2 = hit2.transform;

                Debug.Log(hit1.distance);
                 
                if (objectHit1.name == objectHit2.name)
                {
                    byte r = Convert.ToByte(UnityEngine.Random.Range(0, 255));
                    byte g = Convert.ToByte(UnityEngine.Random.Range(0, 255));
                    byte b = Convert.ToByte(UnityEngine.Random.Range(0, 255));
                    objectHit1.GetComponent<MeshRenderer>().material.color = new Color32(r, g, b, 128);
                }
            }
        }
    }
}
