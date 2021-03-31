using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private float interactionRange;

    [SerializeField]
    private LayerMask interactLayer;
    
    private Transform _player;
    
    private void Start()
    {
        _player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if(_player.gameObject.activeSelf == false)
            return;
        
        if (Vector3.Distance(transform.position, _player.position) < interactionRange)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out RaycastHit hit, 150, interactLayer))
                {
                    Interact();
                }
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }

    public virtual void Interact()
    {
        Debug.Log("Interaction with " + gameObject.name);
    }
}
