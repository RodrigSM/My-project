using UnityEngine;

public class TrocarDeCor : MonoBehaviour
{
    public Color[] cores;

    void Start()
    {
        if (cores.Length == 0)
        {
            Debug.LogWarning("Crie uma ou mais cores na lista.");
            return;
        }

        Color c = cores[Random.Range(0, cores.Length)];

        GetComponent<Renderer>().material.color = c;
    }
}
