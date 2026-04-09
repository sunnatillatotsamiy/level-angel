using UnityEngine;

public class IceFloor : MonoBehaviour
{
    [SerializeField] private float friction = 0f;
    private PhysicsMaterial2D iceMaterial;

    void Start()
    {
        iceMaterial = new PhysicsMaterial2D();
        iceMaterial.friction = friction;
        iceMaterial.bounciness = 0f;
        GetComponent<Collider2D>().sharedMaterial = iceMaterial;
    }
}