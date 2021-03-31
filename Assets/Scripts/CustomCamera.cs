using UnityEngine;

[RequireComponent(typeof(CustomCamera))]
public class CustomCamera : MonoBehaviour
{
    [SerializeField] private Transform _objectToFollow;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _objectToFollow.position;
    }

    private void Update()
    {
        Vector3 newPosition = _objectToFollow.position + _offset;
        transform.position = newPosition;
    }
}