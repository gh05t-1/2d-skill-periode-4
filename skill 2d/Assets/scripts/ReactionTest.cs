using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionTest : MonoBehaviour
{
    enum State { idle, wait, play, stop };
    State myState = State.idle;

    float time;
    float startTimeThreshold;

    [SerializeField] Button StartButton;
    [SerializeField] Button StopButton;
    [SerializeField] Button ContinueButton;
    [SerializeField] TextMeshProUGUI Stopwatch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartButton.onClick.AddListener(ClickStartButton);
        StopButton.onClick.AddListener(ClickStopButton);
        ContinueButton.onClick.AddListener(ClickContinueButton);

        UpdateUI();
        Stopwatch.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (myState == State.wait)
        {
            time += Time.deltaTime;
            Stopwatch.text = time.ToString("F3");
            if (time > startTimeThreshold)
            {
                time = 0;
                myState = State.play;
                UpdateUI();
            }
        }

        if (myState == State.play)
        {
            time += Time.deltaTime;
            Stopwatch.text = time.ToString("F3");

        }
    }
    private void ClickStartButton()
    {
        Debug.Log("op start geklikt");
        myState = State.wait;
        time = 0;
        startTimeThreshold = Random.Range(4, 10);  // willekeurige tijd tussen 4–10 sec
        UpdateUI();
    }
    private void ClickStopButton()
    {
        myState = State.stop;
        UpdateUI();
    }
    private void ClickContinueButton()
    {
        myState = State.idle;
        time = 0;
        Stopwatch.text = "";
        UpdateUI();
    }
    private void UpdateUI()
    {
        StartButton.gameObject.SetActive(myState == State.idle);
        StopButton.gameObject.SetActive(myState == State.play);
        ContinueButton.gameObject.SetActive(myState == State.stop);
    }
}
