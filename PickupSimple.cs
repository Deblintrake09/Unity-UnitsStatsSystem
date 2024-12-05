using UnityEngine;

public class PickupSimple : MonoBehaviour
{
    public PowerUp powerUp;

    void OnTriggerEnter(Collider other)
    {
        var visitable = other.GetComponent<IVisitable>();
        if (visitable != null)
        {
            visitable.Accept(powerUp);
            Destroy(gameObject);
        }
    }
}