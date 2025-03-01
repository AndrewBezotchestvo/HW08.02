using UnityEngine;

public class PlayerRotations : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private float _sensityvity;

    private int _minVertical = -45;
    private int _maxVertical = 45;

    private float _mouseX;
    private float _mouseY;

    private float _rotationX;
    private float _rotationY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false; //скрыть курсор
        Cursor.lockState = CursorLockMode.Locked; //блокировка курсора
    }

    // Update is called once per frame
    void Update() 
    {
        _mouseX = Input.GetAxis(MouseX);
        _mouseY = Input.GetAxis(MouseY);

        _rotationY = _mouseX * _sensityvity * Time.deltaTime;
        //transform.parent.Rotate(Vector3.up * _rotationY); //вращение по оси Y
        
        _rotationX -= _mouseY * Time.deltaTime * _sensityvity;

        _rotationX = Mathf.Clamp(_rotationX, _minVertical, _maxVertical);

        transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.parent.localRotation = Quaternion.Euler(0, transform.parent.eulerAngles.y + _rotationY, 0);
        //transform.parent.Rotate(0, _rotationY, 0);

    }
}
