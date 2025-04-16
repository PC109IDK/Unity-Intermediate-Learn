using PrimeTween;
using UnityEngine;
using NaughtyAttributes;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int price = 5;


    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 1, 0);
    }
    void PrintMessage(int i)
    {
        Debug.Log($"{name} knows that money is {i} | {transform.rotation}");

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void OnEnable()
    {
        GameManager.Instance.OnMoneyChanged.AddListener(PrintMessage);
        
        
        Tween.PositionY(transform, transform.position.y + 0.25f, 1f,cycles: 9999, CycleMode.Yoyo);

        

    }

    void OnDisable()
    {
        GameManager.Instance.OnMoneyChanged.RemoveListener(PrintMessage);
    }

    public void Collect()
    {
        GameManager.Instance.Money = price;

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ICollectable>(out ICollectable item))
        {
            item.Collect();
        }
    }

    [Button("RotQT")]
    public void Quaternion_Identity()
    {
        transform.rotation = Quaternion.identity;
    }
}
