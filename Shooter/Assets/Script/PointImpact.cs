using UnityEngine;

public class PointImpact : MonoBehaviour
{
    [SerializeField] private int _timeDie;
    void Start()
    {
        Destroy(gameObject, _timeDie);
    }

}
