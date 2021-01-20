using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    
    public GameObject ship;
    Text textUI;
    private bool blinking;
    public bool isTrue;
   


    // Start is called before the first frame update
    void Start(){
        textUI = GetComponent<Text>();
        ship = GameObject.Find("craft_racer");
    }

    // Update is called once per frame
    void Update(){
        if (isTrue == false){
            BlinkingText();
            isTrue = true;
        }
    }

    void BlinkingText(){
        blinking = ship.GetComponent<PhysicsEngine>().netForceCheck;
        if (blinking){
            StartCoroutine(BlinkBalanced());
        }
        else{
            StartCoroutine(BlinkUnbalanced());
        }
    }


    IEnumerator BlinkBalanced(){   // When the Forces are balanced, this code will display the success message.
        while (true){
            textUI.text = " ";
            yield return new WaitForSeconds(1f);
            textUI.color = Color.yellow;
            textUI.text = "Balanced Force, Success!";
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator BlinkUnbalanced(){// When the Forces are unbalanced, this code will display the error message.
        while (true){
            textUI.text = " ";
            yield return new WaitForSeconds(0.5f);
            textUI.color = Color.red;
            textUI.text = "Unbalanced Force Detected";
            yield return new WaitForSeconds(0.5f);
        }
    }
}