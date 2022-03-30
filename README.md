# Purpose

Trying to reproduce the WebGL issue introduced with iOS 15.4: flickering UI-Images

## Usage

* run the tester (on a iOS device 15.4)!
* from time to time tap anywhere on the screen (not the button at the bottom) >> this stops / restarts the animations with each tap
* after ~40s (on my device) the flickering starts
* Hit the button at the bottom "Remove Canvas" >> this removes the 2nd Canvas containing the top-UI
* Flickering should stop

_The button can only be clicked once during the test! (edited)_

## Content

* Canvas with RenderMode: Screen Space Camera
* A number of UI-Images with no Sprite-Atlas to keep the DrawCalls high
* Tweens on the UI-Images including position, scaling and rotation
* Animators on each GameObject (flipping the card) playing in a loop
* Restructuring the Siblings permanently (SetAsLastSibling())
* Canvas Group
* Added PointerDown-Listener
* added back + frontside >> toggling enabled-state of nested GameObjects
* added TMPro Text
* added second canvas

## Observations

When we have 2 Canvases AND we Toggle the enabled-property of Animators >> the flickering starts