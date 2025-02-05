using UnityEngine;

public class TimingBarController : MonoBehaviour
{
    public Transform Indicator;
    public Transform greenZone;

    public float moveSpeed = 0.1f;
    private bool movingRight = true;
    private bool isStopped = false;

    private bool gameEnded = false;

    void Update()
    {
        if (!gameEnded)
        {
            if (!isStopped)
            {
                MoveIndicator();

                if (Input.GetMouseButtonDown(0))
                {
                    isStopped = true;
                    CheckSuccess();
                }
            }
        }
    }

    void MoveIndicator()
    {
        float moveAmount = moveSpeed * Time.deltaTime;

        if (movingRight)
        {
            Indicator.localPosition += new Vector3(moveAmount, 0, 0);
            if (Indicator.localPosition.x >= 0.5f)
                movingRight = false;
        }
        else
        {
            Indicator.localPosition -= new Vector3(moveAmount, 0, 0);
            if (Indicator.localPosition.x <= -0.5f)
                movingRight = true;
        }
    }

    void CheckSuccess()
    {
        float distance = Mathf.Abs(Indicator.position.x - greenZone.position.x);

        if (distance < 0.5f)
        {
            EndGame();
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        isStopped = true;
    }
}