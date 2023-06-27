using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _actions;
    [SerializeField] private TMP_Text _thoughts;
    [SerializeField] private TMP_Text _name;
    
    [SerializeField] private TMP_Text _hunger;
    [SerializeField] private TMP_Text _thirst;
    [SerializeField] private TMP_Text _energy;
    
    [SerializeField] private TMP_Text _speed;
    [SerializeField] private TMP_Text _agility;
    [SerializeField] private TMP_Text _lazyness;
    [SerializeField] private TMP_Text _charisma;
    [SerializeField] private TMP_Text _intellect;
    
    

    private FoodAgentTree _selectedAgent;
    private randomCharacter _selectedCharacter;

    private void OnEnable() => AgentSelector.OnAgentStatusChanged += OnAgentStatusChanged;
    private void OnDisable() => AgentSelector.OnAgentStatusChanged -= OnAgentStatusChanged;

    private void OnAgentStatusChanged(bool state, GameObject agentObject)
    {
        if(!agentObject.transform.parent.TryGetComponent(out FoodAgentTree agent)) return;

        if (state)
        {
            agent.OnAgentAct += OnAgentAct;

            _selectedCharacter = agentObject.GetComponent<randomCharacter>();

            _name.text = _selectedCharacter.nameTMP.text;
            _speed.text = $"{agent.Speed}";

            _selectedAgent = agent;
        }
        else
        {
            agent.OnAgentAct -= OnAgentAct;
            
            _name.text = "???";
            _speed.text = "?";
            _thoughts.text = "???";

            _selectedCharacter = null;
            _selectedAgent = null;
        }
    }

    private void OnAgentAct(string text)
    {
        _actions.text = text;
    }

    private void Update()
    {
        if (_selectedAgent && _selectedCharacter)
        {
            _hunger.text = _selectedAgent.HungerRemaining.ToString("0.##");
            _thirst.text = _selectedAgent.HungerRemaining.ToString("0.##");
            _energy.text = _selectedAgent.HungerRemaining.ToString("0.##");
            _thoughts.text = _selectedCharacter.thoughtDescription;
        }
        else
        {
            _hunger.text = "?";
            _thirst.text = "?";
            _energy.text = "?";
        }
    }
}
