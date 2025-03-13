using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(LineRenderer))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private PointImpact _bullet;
    [SerializeField] private Transform _startPointRay;
    [SerializeField] private Transform _countBottonCountText;

    [SerializeField] private int _typeOfGun;
    [SerializeField] private float _bulletDelay = 0.1f;
    [SerializeField] private TMP_Text _distanseText;

    private LineRenderer _lineRenderer;

    private float _bulletTime = 0;

    private RaycastHit _raycastHit;
    private Ray _ray;
    private Camera _camera;
    private PointImpact _tempPointImpact;

    private float _objectDistanse;

    

    private int _countBullets;

    private void Start()
    {
        _camera = GetComponentInParent<Camera>();
        _lineRenderer = GetComponentInParent<LineRenderer>();
        _lineRenderer.positionCount = 2;
        _lineRenderer.startWidth = 0.1f;
        _lineRenderer.endWidth = 0.1f;
    }

    private void Update()
    {

        RaycastHit distanceHit;
        Ray distanceRay = new Ray(_startPointRay.position, _camera.transform.forward);
        if (Physics.Raycast(distanceRay, out distanceHit))
        {
            // Если луч попал в объект, выводим расстояние до него
            _objectDistanse = distanceHit.distance;
            _distanseText.text = $"диствнция до объекта {Mathf.Round(_objectDistanse)}";          
        }
        else
        {
            _distanseText.text = $"диствнция до объекта {Mathf.Infinity}";
        }
       

            if (_typeOfGun == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        if (_typeOfGun == 2)
        {
            _bulletTime += Time.deltaTime;
            if (Input.GetMouseButton(0) && _bulletTime > _bulletDelay)
            {
                _bulletTime = 0;
                Shoot();
            }
        }

        if (_typeOfGun == 3)
        {
            if (Input.GetMouseButton(0))
            {
                _lineRenderer.enabled = true;
                Vector3 targetPosition = LaserShoot();
                if (targetPosition != Vector3.zero)
                {
                    _lineRenderer.SetPosition(0, _startPointRay.position);
                    _lineRenderer.SetPosition(1, targetPosition);
                    _lineRenderer.material.color = Random.ColorHSV();
                }
                
            }
            else
            {
                _lineRenderer.enabled = false;
            }
        }
    }

    private void Shoot()
    {
        _ray = new Ray(_startPointRay.position, _camera.transform.forward);

        if (Physics.Raycast(_ray, out _raycastHit))
        {
            _tempPointImpact = Instantiate(_bullet);
            _tempPointImpact.transform.position = _raycastHit.point;
        }

        Debug.DrawRay(_ray.origin, _ray.direction * 1000);
    }

    private Vector3 LaserShoot()
    {
        _ray = new Ray(_startPointRay.position, _camera.transform.forward);
        Debug.DrawRay(_ray.origin, _ray.direction * 1000);

        if (Physics.Raycast(_ray, out _raycastHit))
        {
            return _raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private Vector3 GetRandomVector()
    {
        return Vector3.zero;
    }
}
