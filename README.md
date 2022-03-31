# Purpose

Trying to reproduce the WebGL issue introduced with iOS 15.4: flickering UI-Images

Live testcase: 
https://romanwache.de/uploads/webkitbug/


## Usage

* run the tester (on a iOS device 15.4)!
* after ~40s tap anywhere on the screen (not the "remove canvas"-button at the bottom) >> this stops / restarts all animations with each tap
* now the flickering should start while the animations are off
* Hit the button at the bottom "Remove Canvas" >> this removes the 2nd Canvas containing the top-UI (FPS Counter)
* Flickering should stop

_The button can only be clicked once during the test!_

## Content

* Canvas with RenderMode: Screen Space Camera
* A number of UI-Images with no Sprite-Atlas to keep the DrawCalls high
* DOTweens on the UI-Images including position, scaling and rotation
* Animators on each GameObject (flipping the card) playing in a loop
* Restructuring the Siblings permanently (SetAsLastSibling())
* Added PointerDown-Listener
* added back + frontside >> toggling enabled-state of nested GameObjects
* added TMPro Text
* added second canvas
* added global Animation ON/OFF toggle >> this started the flickering

## Observations

When we have 2 Canvases AND we stop the Animations happening on screen >> the flickering starts
