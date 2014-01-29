### Overview

**Party Poopers** is a game created in Unity 4.3.3 for the Global Game Jam 2014 @ the SCAD Atlanta site.

For an overview of the game itself:

http://globalgamejam.org/2014/games/party-poopers

### Possibly Useful Beginning Things Learned During the Making of This Game

* Unity 4.3.3 2D features (Sprites w/ animation and 2D physics)
* InControl integration for game controllers. It is a *wonderful* thing.
* Rotation of a character and applied 2D Physics movement using analog stick output.
* (Hacky) Bitmap font rendering using UIToolkit in conjunction with 2D Sprites

Learn from my mistakes.

### Technical Notes

Currently, the game only works if wired controllers are plugged in before the game is launched. The tested environment was OSX 10.8 using a mixture of Xbox 360 and Playstation 4 controllers.

### Credits

#### TEAM UTERI

Who  | What
------------- | -------------
Renee Blair | Art
Jessica Gore | Music, SFX and Video
Holly Nunez | Game Wife and Lead Snack Provider
Valerie Nunez | Art, Character Design
Rose Peng  | Art, Character Animation
Rob Solomon  | Programming
Sasi Viriyayuthakorn | Art

### Libraries

This code uses portions of the following Unity libraries:
* **InControl** - https://github.com/pbhogan/InControl
* **UIToolkit** - https://github.com/prime31/UIToolkit

If you get errors opening the final scene, delete the existing "UI" object in the Hierarchy and then drag the "UI" prefab from the Library into the root. I don't know why this works, but it does.

### License

All code and assets written outside of the included libraries are released under a [Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported](http://creativecommons.org/licenses/by-nc-sa/3.0/) license.
