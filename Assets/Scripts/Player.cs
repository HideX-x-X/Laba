using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] 
    private Material goMaterial;
    
    [SerializeField]
    private LayerMask walkLayer;

    [SerializeField]
    private AudioClip runSound;
    [SerializeField]
    private AudioClip idleSound;

    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;
    private Material _initialMaterial;
    private NavMeshAgent _agent;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        _initialMaterial = _meshRenderer.material;
    }

    private void Update()
    {
        if (_agent.hasPath)
        {
            if (_audioSource.clip != runSound)
            {
                _audioSource.clip = runSound;
                _audioSource.Play();
            }
            
            _meshRenderer.material = goMaterial;
        }
        else
        {
            _meshRenderer.material = _initialMaterial;
            
            if (_audioSource.clip != idleSound)
            {
                _audioSource.clip = idleSound;
                _audioSource.Play();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 150, walkLayer))
            {
                _agent.SetDestination(hit.point);
                //.Log(hit.point);
            }
        }
    }
}
