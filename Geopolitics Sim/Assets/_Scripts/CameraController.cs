using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform view1; // The first view
    public Transform view2; // The second view
    public float transitionTime = 2.0f; // The time it takes to transition from one view to the other
    public AgentSelector agentSelector; // Reference to the AgentSelector script
    public float followSpeed = 5f; // The speed at which the camera follows the selected agent
    public Vector3 offset; // The offset between the camera and the agent
    public Vector3 rotation; // The rotation of the camera when following an agent

    private bool isFollowing; // Whether the camera is currently following an agent

    public float restartTimer = 60f;

    private void Start()
    {
        //StartCoroutine(restartGame());
    }
    private void Update()
    {
        // If an agent is selected and the camera is following, move towards the agent
        if (isFollowing && agentSelector.selectedAgent != null)
        {
            Vector3 targetPosition = agentSelector.selectedAgent.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(rotation);
        }
    }

    // Call this method to toggle whether the camera is following an agent
    public void ToggleFollow()
    {
        isFollowing = !isFollowing;
    }

    public void StopFollow()
    {
        isFollowing = false;
    }

    public void MoveToView1()
    {
        // Start the transition to the first view
        StartCoroutine(MoveToView(view1.position, view1.rotation));
    }

    public void MoveToView2()
    {
        // Start the transition to the second view
        StartCoroutine(MoveToView(view2.position, view2.rotation));
    }

    private IEnumerator MoveToView(Vector3 targetPosition, Quaternion targetRotation)
    {
        // The initial position and rotation
        Vector3 initialPosition = transform.position;
        Quaternion initialRotation = transform.rotation;

        // The time since the transition started
        float elapsedTime = 0.0f;

        // While the transition is not complete
        while (elapsedTime < transitionTime)
        {
            // Update the position and rotation
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / transitionTime);
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / transitionTime);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Set the final position and rotation
        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }

    IEnumerator restartGame()
    {
        yield return new WaitForSeconds(restartTimer);
        SceneManager.LoadScene(1);
    }
}
