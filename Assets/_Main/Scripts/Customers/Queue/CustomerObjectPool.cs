using UnityEngine;

public class CustomerObjectPool : MonoBehaviour
{
    [SerializeField] private Customer prefab;
    [SerializeField] private int customerAmount;

    public ObjectPool<Customer> Clients { get; private set; }

    private void Awake()
    {
        Clients = new ObjectPool<Customer>(Instantiate,Activate,Deactivate, customerAmount, true);
    }

    private Customer Instantiate()
    {
        return Instantiate(prefab,transform);
    }

    private void Activate(Customer client)
    {
        client.gameObject.SetActive(true);
    }

    private void Deactivate(Customer client)
    {
        client.gameObject.SetActive(false);
    }
}
