using UnityEngine;

public class AgentSurvival : MonoBehaviour
{
    public float hunger; // The agent's hunger level
    public float thirst; // The agent's thirst level
    public float energy; // The agent's energy level

    private void Update()
    {
        
        // Calculate the survival chance
        float survivalChance = Mathf.Min(hunger, thirst, energy);

        // If the survival chance is zero, the agent dies
        if (survivalChance <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Here you can add code to handle the agent's death
        Debug.Log(gameObject.name + " has died.");
    }
}
