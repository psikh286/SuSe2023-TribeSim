using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class randomCharacter : MonoBehaviour
{
    public TextMeshPro nameTMP;

    public string[] firstNames = new string[]
   {
        "John", "Jane", "Bob", "Alice", "Tom", "Emily", "Jack", "Sarah", "James", "Emma",
        "Robert", "Olivia", "Michael", "Ava", "William", "Isabella", "David", "Sophia", "Joseph", "Mia",
        "Charles", "Charlotte", "Thomas", "Amelia", "Henry", "Harper", "George", "Evelyn", "Richard", "Abigail"
   };

    public string[] lastNames = new string[]
    {
        "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson",
        "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White",
        "Lopez", "Lee", "Gonzalez", "Harris", "Clark", "Lewis", "Robinson", "Walker", "Perez", "Hall"
    };

    private void Start()
    {
        // Assign a random name
        string firstName = firstNames[Random.Range(0, firstNames.Length)];
        string lastName = lastNames[Random.Range(0, lastNames.Length)];
        string name = firstName + " " + lastName;
        gameObject.name = name;
        nameTMP.text = name;

        // Fetch the agent's MeshRenderer and assign a random color
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Color color = new Color(Utility.RandomFloat(0, 1), Utility.RandomFloat(0, 1), Utility.RandomFloat(0, 1));
        meshRenderer.material.SetColor("_BaseColor", color);
    }

}
