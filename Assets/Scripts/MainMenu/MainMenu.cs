using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public int selector = 0;
    public GameObject[] selectables;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        selectables[selector].GetComponent<SpriteRenderer>().color = Color.red;
        if (Input.GetKeyDown(KeyCode.S))
        {
            selectables[selector].GetComponent<SpriteRenderer>().color = Color.black;
            selector++;

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            selectables[selector].GetComponent<SpriteRenderer>().color = Color.black;
            selector--;
        }
        if (selector < 0)
        {
            selector = selectables.Length - 1;
        }
        if (selector > selectables.Length - 1)
        {
            selector = 0;
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            switch (selector)
            {
                case 0:
                    SceneManager.LoadSceneAsync(0);
                    break;
                case 1:
                    Saver loader;
                    BinaryFormatter binForm = new BinaryFormatter();
                    using (FileStream stream = new FileStream(@"C:\Users\WillowPunch\Desktop\save.dat", FileMode.Open))
                    {
                        loader = (Saver)binForm.Deserialize(stream);
                    }
                    Loading(loader);
                    SceneManager.LoadSceneAsync(loader.SceneInt);
                    break;
                case 2:
                    Application.Quit();
                    break;
            }
        }
    }

    void Loading(Saver loader)
    {
        SceneParameters.Health = loader.Health;
        SceneParameters.MaxHealth = loader.MaxHealth;
        SceneParameters.BalconyExit = loader.BalconyExit;
        SceneParameters.CharacterDoor = loader.CharacterDoor;
        SceneParameters.CharacterDoorKey = loader.CharacterDoorKey;
        SceneParameters.CheckBomb = loader.CheckBomb;
        SceneParameters.weaponIndex = loader.weaponIndex; 
    }
}
