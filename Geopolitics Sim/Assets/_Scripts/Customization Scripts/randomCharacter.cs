using System.Collections;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class randomCharacter : MonoBehaviour
{
    public TextMeshPro nameTMP;
    private MeshRenderer meshRenderer;
    private Color defaultOutline;

    private string jobDescription;
    public string thoughtDescription;

    public string[] firstNames = new string[]
{
    "Liam", "Noah", "Oliver", "Elijah", "Lucas", "Mason", "Logan", "Mateo", "Muhammad", "Aarav",
    "Arjun", "Sai", "Yusuf", "Ahmed", "Ali", "Chen", "Li", "Zhang", "Wang", "Liu",
    "Carlos", "Jose", "Miguel", "Juan", "Alejandro", "Sofia", "Isabella", "Valentina", "Camila", "Valeria",
    "Fatima", "Zainab", "Maria", "Aisha", "Khadija", "Sakura", "Hana", "Yui", "Rio", "Mei",
    "Johannes", "Luca", "Finn", "Max", "Paul", "Mohamed", "Adam", "Rayan", "Amine", "Nasser"
};

    public string[] lastNames = new string[]
    {
    "Smith", "Johnson", "Brown", "Taylor", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez",
    "Gonzalez", "Perez", "Sanchez", "Rivera", "Torres", "Nguyen", "Tran", "Pham", "Huynh", "Hoang",
    "Li", "Wang", "Zhang", "Liu", "Chen", "Yang", "Huang", "Zhao", "Wu", "Zhou",
    "Silva", "Santos", "Ferreira", "Pereira", "Oliveira", "Costa", "Rodrigues", "Martins", "Jesus", "Souza",
    "Patel", "Singh", "Shah", "Kumar", "Desai", "Khan", "Ali", "Hussain", "Ahmed", "Begum"
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
        meshRenderer = GetComponent<MeshRenderer>();
        Color color = new Color(Utility.RandomFloat(0, 1), Utility.RandomFloat(0, 1), Utility.RandomFloat(0, 1));
        meshRenderer.material.SetColor("_BaseColor", color);
        defaultOutline = meshRenderer.material.GetColor("_OutlineColor");

        string jobPrompt = "Describe what an agent exploring the environment might be doing in less than 10 words.";
        string thoughtPrompt = "Imagine what an agent might be thinking while exploring a new environment in less than 10 words.";
        _ = generateJobDescriptionAsync(jobPrompt);
        _ = generateThoughtDescriptionAsync(thoughtPrompt);

    }

    public void Select()
    {
        // Show the agent's name
        nameTMP.gameObject.SetActive(true);
        meshRenderer.material.SetColor("_OutlineColor", Color.white);
        meshRenderer.material.SetColor("_RimColor", Color.black);
        // Perform other selection actions...
    }

    public void Deselect()
    {
        // Hide the agent's name
        nameTMP.gameObject.SetActive(false);
        meshRenderer.material.SetColor("_OutlineColor", defaultOutline);
        meshRenderer.material.SetColor("_RimColor", Color.white);

        // Perform other deselection actions...
    }

    public async Task AICharacterAsync(string prompt)
    {
        var api = new OpenAIClient();
        var messages = new List<Message>
        {
            new Message(Role.System, "You are an AI model trained to generate creative and contextually appropriate responses."),
            new Message(Role.Assistant, "I'm here to help generate text for a game agent."),
            new Message(Role.User, prompt),
        };
        var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
        var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
    }

    public async Task generateJobDescriptionAsync(string prompt)
    {
        var api = new OpenAIClient();
        var messages = new List<Message>
        {
            new Message(Role.System, "You are an AI model trained to generate creative and contextually appropriate responses."),
            new Message(Role.Assistant, "I'm here to help generate text for a game agent."),
            new Message(Role.User, prompt),
        };
        var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
        var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
        jobDescription = result;
        Debug.Log(this.gameObject.name + " : " + jobDescription);
    }
    public async Task generateThoughtDescriptionAsync(string prompt)
    {
        var api = new OpenAIClient();
        var messages = new List<Message>
        {
            new Message(Role.System, "You are an AI model trained to generate creative and contextually appropriate responses."),
            new Message(Role.Assistant, "I'm here to help generate text for a game agent."),
            new Message(Role.User, prompt),
        };
        var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
        var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
        thoughtDescription = result;
        Debug.Log(this.gameObject.name + " : " + thoughtDescription);

    }
}
