using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BobbingEffect : MonoBehaviour
{
    public float bobbingSpeed; // Speed of the bobbing effect
    public float bobbingAmount; // How much the agent bobs up and down

    private float defaultY; // The default y position of the agent
    private float timer = 0; // Timer to keep track of the bobbing effect

    private void Start()
    {
        // Store the default y position of the agent
        defaultY = transform.localPosition.y;
        bobbingSpeed = Utility.RandomFloat(0.01f, 0.05f);
        bobbingAmount = Utility.RandomFloat(0.1f, 0.2f);
    }

    private void Update()
    {
        // Calculate the new y position for the bobbing effect
        float newY = defaultY + Mathf.Sin(timer) * bobbingAmount;
        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);

        // Increase the timer by the bobbing speed
        timer += bobbingSpeed;
    }

}
