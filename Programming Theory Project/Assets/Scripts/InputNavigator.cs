using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace edeastudio
{
    public class InputNavigator : MonoBehaviour
    {
        EventSystem system;
        GameObject lastSelectedGameObject;
        GameObject currentSelectedGameObject_Recent;

        void Start()
        {
            system = EventSystem.current;// EventSystemManager.currentSystem;

        }
        // Update is called once per frame
        void Update()
        {
            GetLastGameObjectSelected();

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                //  Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

                Selectable next;
 
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
                    if (next == null)
                        next = lastSelectedGameObject.GetComponent<Selectable>();
                }
                else
                {
                    next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
                    if (next == null)
                        next = system.firstSelectedGameObject.GetComponent<Selectable>();
                }

                if (next != null)
                {
                    InputField inputfield = next.GetComponent<InputField>();
                    if (inputfield != null)
                        inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

                    system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
                }
                //else Debug.Log("next nagivation element not found");

            }
        }

        public void ExitApplication()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
        }

        private void GetLastGameObjectSelected()
        {
            if (system.currentSelectedGameObject != currentSelectedGameObject_Recent)
            {
                lastSelectedGameObject = currentSelectedGameObject_Recent;
                currentSelectedGameObject_Recent = system.currentSelectedGameObject;
            }
        }

    }
}