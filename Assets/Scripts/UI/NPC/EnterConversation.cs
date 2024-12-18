using UnityEngine;
using UnityEngine.Serialization;

public class EnterConversation : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    [SerializeField] GameObject dialogueStarter;
    public DialogueManager dialogueManager;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (dialogueStarter.activeSelf)
            {
                dialogueTrigger.TriggerDialogue();
                HideDialogueStarter();
            }
            else
            {
                dialogueManager.DisplayNextSentence();
            }
        }
    }

    void HideDialogueStarter()
    {
        dialogueStarter.SetActive(false);
    }
}
