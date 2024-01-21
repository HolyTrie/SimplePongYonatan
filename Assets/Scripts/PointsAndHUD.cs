using System.Collections;
using TMPro;
using UnityEngine;

public class PointsAndHUD : MonoBehaviour
{
    [SerializeField] private TextMeshPro pointText;
    private ScoreTracker st;
    [SerializeField] private bool player1 = false;
    private int _points = 0;
    private bool guard = false;

    private void Awake() {
        st = GetComponentInParent<ScoreTracker>();
        UpdateHUD();
    }
    public int Points
    {
        get
        {
            return _points;
        }
        set
        {
            _points = value;
            UpdateHUD();
            if(player1)
            {
                st.Score1 = _points;
            }
            else
            {
                st.Score2 = _points;
            }
        }
    }

    private void UpdateHUD()
    {
        pointText.text = _points.ToString();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(!guard)
        {
            guard = true;
            if(other.CompareTag("Ball"))
            {
                StartCoroutine(IncrementPoints());
            }
        }
        
    }
    IEnumerator IncrementPoints(int amount = 1)
    {
        Points += amount;
        yield return new WaitForSeconds(1f);
        guard = false;
    }
}