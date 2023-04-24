using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isPaused;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] List<Note> notesFound = new List<Note>();
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }else if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
    }
    public bool isGamePaused()
    {
        return isPaused;
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.visible = true;
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = true;
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void AddNote(Note note) {

        notesFound.Add(note);
    
    }
}
