# Memory-Matching-Game
Project 3- Memory Matching Game, OOP/ WPF GUI

Main idea:
Firstly, I use 20 buttons to represent the buttons used for matching pair, instead of using images. 
I intialiated the image of buttons without clicking any controlling buttons by giving the properties at xaml file
with Dynamic Resources. Then when the player clicked the start button, the image will be changed to using bitmapimage
as it could be easily to change the image when the player clicking the buttons, i.e. change to the picture when the
tiles are filped.

Then the tag of the button will be matched, and then the bool variable will mark if they are paired or not. If they 
are paired, it will turn to True. After that, the count of the succeed pair will increase. When the count becomes
10, the message of the end of the game will appear. 


Principles of software design

I take the advantage of C#, which is OOP. I used the access modifers, constructer for Matching. And I also used
observer design pattern in which the project comprises different event handler.
