using UnityEngine;

public class PyramidBuilder : MonoBehaviour
{
    public GameObject prefab; // Przypisz prefab, który chcesz użyć, w Inspektorze
    public int initialSize = 5; // Początkowy rozmiar kwadratu (ilość prefabów na każdym boku)
    public float spacing = 1.0f; // Odległość między prefabami
    public float offset = 1.0f; // Przesunięcie na osi X i Z

    void Start()
    {
        Vector3 startPosition = transform.position;
        int size = initialSize;
        GameObject previousPrefab = null;

        for (int floor = 0; floor < initialSize; floor++)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    float xOffset = i * spacing + floor * offset;
                    float zOffset = j * spacing + floor * offset;
                    Vector3 prefabPosition = new Vector3(startPosition.x + xOffset, startPosition.y + (floor * spacing), startPosition.z + zOffset);

                    GameObject currentPrefab = Instantiate(prefab, prefabPosition, Quaternion.identity);
                    
                    if (previousPrefab != null)
                    {
                        ConnectWithSpringJoint(previousPrefab, currentPrefab);
                    }

                    previousPrefab = currentPrefab;
                }
            }

            size--;
        }
    }

    void ConnectWithSpringJoint(GameObject prefab1, GameObject prefab2)
    {
        SpringJoint springJoint = prefab1.AddComponent<SpringJoint>();
        springJoint.connectedBody = prefab2.GetComponent<Rigidbody>(); // Sprawdź, czy prefab ma komponent Rigidbody
        springJoint.spring = 500.0f; // Dostosuj wartość sprężystości, jeśli to konieczne
        springJoint.damper = 5.0f; // Dostosuj tłumienie, jeśli to konieczne
    }
}
