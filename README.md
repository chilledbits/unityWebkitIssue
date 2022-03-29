# Purpose

Trying to reproduce the WebGL issue introduced with iOS 15.4: flickering UI-Images

## Content

* Canvas with RenderMode: Screen Space Camera
* A number of UI-Images with no Sprite-Atlas to keep the DrawCalls high
* Tweens on the UI-Images including position, scaling and rotation
* Animators on each GameObject (flipping the card) playing in a loop
* Restructuring the Siblings permanently (SetAsLastSibling())
* Canvas Group
* Occlusion Culling activated (even though it doesn't affect UI)
