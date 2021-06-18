# Word-Draw

<ol>
  
  
  <li>
    Set a background image. Created UI buttons for pausing the game, for showing total score and current picture score, for hint and for going to next picture.
  </li>
  <br />
  <li>
    Added some help text at the top and an astronaut character to make it more interactive. Added a ‘bobbing’ animation to all the objects for the sensation of an outerspace-like environment.
  </li>
  <br />
  <img src="readme_assets/tutorial_img_1.png" width="70%">
  <br />
  <br />
  <br />
  
  <li>
    Added panels for displaying picture, to show answer that is being formed, and for an inventory where the letters to be selected will be formed.
  </li>
  <br />
  <img src="readme_assets/tutorial_img_2.png" width="70%">
  <br />
  <br />
  <br />
  
  
  <li>
    Added a main menu.
  </li>
  <br />
  <img src="readme_assets/tutorial_img_3.png" width="70%">
  <br />
  <br />
  <br />
  
  
  <li>
    Added a panel for when game is paused.
  </li>
  <br />
  <img src="readme_assets/tutorial_img_4.png" width="70%">
  <br />
  <br />
  <br />
  
  
  <li>
    Created a folder where picture files are to be submitted.
    <ul>
      <li>
        The code parses through all png files in that folder, and adds them to a picture-list. The picture-list is then accessed randomly.
      </li>
      <li>
        The corresponding image is shown on the picture-panel (purple). Buttons with letters in the picture’s word as button-text are generated in random order in the inventory-panel (orange).
      </li>
    </ul>
  </li>
  <br />
  <img src="readme_assets/tutorial_img_5.png" width="70%">
  <br />
  <br />
  <br />
  
  
  <li>
    When the buttons in the inventory-panel are clicked, the letter in them is appended to the end of a string which is shown on the shelf-panel (translucent black).
  </li>
  <br />
  <li>
    When all the buttons are finished:
    <ul>
      <li>
        If the spelling is correct, 3 stars are awarded as the current score.
      </li>
      <li>
        If the spelling is two-thirds correct, 2 stars are awarded.
      </li>
      <li>
        If the spelling is one-third correct, 1 star is awarded.
      </li>
    </ul>
  </li>
  <br />
  <img src="readme_assets/tutorial_img_6.png" width="70%">
  <br />
  <br />
  <img src="readme_assets/tutorial_img_7.png" width="70%">
  <br />
  <br />
  <br />
  
  
  <li>
    The NEXT button is enabled.
  </li>
  <br />
  <li>
    If the spelling is not fully correct, the help text above turns red and shows the correct spelling. The word is not removed from the picture-list.
  </li>
  <br />
  <li>
    If it is correct, it turns green and congratulates the player. The word is removed from the picture-list.
  </li>
  <br />
  <li>
    When the next button is pressed, the current score and shelf-panel is cleared. The next picture’s information is loaded onto the inventory-panel and picture-panel. However, if the picture is last, the game ends, and the user is prompted to leave to the menu.
  </li>
  <br />
  <li>
    If the user doesn’t select any letter for 30 seconds, the correct letter is highlighted by green.
  </li>
  <br />
  <img src="readme_assets/tutorial_img_8.png" width="70%">
  <br />
  <br />
  <br />
  
  
</ol>
