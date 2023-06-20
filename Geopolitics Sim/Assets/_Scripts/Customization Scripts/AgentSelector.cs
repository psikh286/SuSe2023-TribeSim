using System;
using UnityEngine;

public class AgentSelector : MonoBehaviour
{
    public GameObject selectedAgent; // The currently selected agent

    public static Action<bool, GameObject> OnAgentStatusChanged;

    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        // Check if the left mouse button was clicked
        if (!Input.GetMouseButtonDown(0)) return;
        
        // Create a ray from the mouse cursor on screen in the direction of the camera
        var ray = _cam.ScreenPointToRay(Input.mousePosition);

        // Perform the raycast
        if (!Physics.Raycast(ray, out var hit, 100, 1 << 8)) return;
        
        // Deselect the currently selected agent, if there is one
        if (selectedAgent != null)
        {
            selectedAgent.GetComponent<randomCharacter>().Deselect();
            OnAgentStatusChanged?.Invoke(false, selectedAgent);
        }

        // Select the new agent
        selectedAgent = hit.transform.gameObject;
        selectedAgent.GetComponent<randomCharacter>().Select();
        OnAgentStatusChanged?.Invoke(true, selectedAgent);
    }

    public void TriggerDeselect()
    {
        selectedAgent.GetComponent<randomCharacter>().Deselect();
        OnAgentStatusChanged?.Invoke(false, selectedAgent);
    }
}
