using UnityEngine;

public class AgentSelector : MonoBehaviour
{
    //public AgentUI agentUI; // The script that controls the UI
    private GameObject selectedAgent; // The currently selected agent

    private void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse cursor on screen in the direction of the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Deselect the currently selected agent, if there is one
                if (selectedAgent != null)
                {
                    selectedAgent.GetComponent<randomCharacter>().Deselect();
                }
                // Check if an agent was clicked
                if (hit.transform.CompareTag("Agent"))
                {
                    // Deselect the currently selected agent, if there is one
                    if (selectedAgent != null)
                    {
                        selectedAgent.GetComponent<randomCharacter>().Deselect();
                    }

                    // Select the new agent
                    selectedAgent = hit.transform.gameObject;
                    Debug.Log(selectedAgent.name);
                    selectedAgent.GetComponent<randomCharacter>().Select();

                    // Update the UI
                    //agentUI.UpdateUI(selectedAgent.GetComponent<Agent>());
                }
            }
        }
    }
}
