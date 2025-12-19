using UnityEngine;
using TMPro;
using UnityEditor;
public class UIController : MonoBehaviour
{
    [SerializeField] private UIController _controller;
    [SerializeField] private RectTransform LeavesPanel;
    [SerializeField] private GameObject[] leavesstopped;
    bool isClosed = true;
    void Start()
    {
        //left -373
        //right 1895
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeavesPunelButton()
    {
        
        if (isClosed)
        {
            //LeavesPanel.transform.localPosition = new Vector3(0, 1520, 0);
            leavesstopped[0].transform.localPosition = new Vector3(-641, leavesstopped[0].transform.localPosition.y, leavesstopped[0].transform.localPosition.z);
            isClosed = false;
        }
        else
        {
            //LeavesPanel.transform.localPosition = new Vector3(-373, 1895, 0);

            leavesstopped[0].transform.localPosition = new Vector3(-1014, leavesstopped[0].transform.localPosition.y, leavesstopped[0].transform.localPosition.z);
            isClosed = true;
        }
        
    }
}
