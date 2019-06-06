using UnityEngine;
using UnityEngine.UI;

public class CounterSpawn : MonoBehaviour
{
    public static Text CounterText;

    private static int counter;
    private static bool isCounting = false;
    private Canvas canvas;
    // Start is called before the first frame update
    private void Start()
    {
        CounterText = GetComponentsInChildren<Text>()[1];
        canvas = GetComponent<Canvas>();
    }

    private void FixedUpdate()
    {
        if (isCounting)
        {
            canvas.enabled = true;
            if (counter % 10 == 0)
            {
                SetText((counter / 60).ToString());
            }

            if (counter == 0)
            {
                isCounting = false;
            }
            else
            {
                counter--;
            }
        }
        else
        {
            canvas.enabled = false;
        }
    }

    private void SetText(string text)
    {
        CounterText.text = text + " !";
    }

    /**
     *  Count is the second how many second you want to count
     **/
    public static void SetCounter(int count)
    {
        counter = count * 60;
        isCounting = true;
    }

    public static int GetCounter()
    {
        return counter / 60;
    }
}
