using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class ToAndFro : MonoBehaviour
{
    Vector3 differenceVectorAB;
    float distance;
    Vector3 direction;
    bool FromAToB = true;
    float time = 0;
    float duration;
    float speed;
    [SerializeField] TextMeshProUGUI Stopwatch;
    [SerializeField] Transform A;
    [SerializeField] Transform B;
    [SerializeField] Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distance = differenceVectorAB.magnitude;
        player.position = A.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (FromAToB)
        {
            differenceVectorAB = B.position - A.position;
        }
        else
        {
            differenceVectorAB = A.position - B.position;
        }
        distance = differenceVectorAB.magnitude;
        duration = distance / 1;
        direction = differenceVectorAB.normalized;

        player.position += direction * Time.deltaTime;
        time += Time.deltaTime;
        Stopwatch.text = time.ToString("F3");

        if (time > duration)
        {
            time = 0;
            //inverteer de variabele FromAtoB
            FromAToB = !FromAToB;
        }

    }
}
