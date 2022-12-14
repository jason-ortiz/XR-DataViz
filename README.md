# XR Data Viz
## Intro
This Unity project allows a user to view USD assets using XR devices like the Meta Quest 2. View IEEE VIS LDAV 2022 Poster and Summary paper here: https://virtual.ieeevis.org/year/2022/poster_a-ldav-posters-1003.html

## Setup
### Prereqs
* Unity 2020.3.26f1 with:
  * Android Build Support (Android SDK & NDK tools; OpenJDK)
  * Universal Windows Platform Build Support
  * Windows Build Support (IL2CPP)
* Download and unzip USD files from `/lus/grand/projects/visualization/ortizj/FourStitchedUsds.zip`
* If using a Meta Quest, download and install the Oculus App (under *Link Cable* in https://store.facebook.com/quest/setup/ or directly from https://www.oculus.com/download_app/?id=1582076955407037)
  * Use a compatible USB-C cable: https://store.facebook.com/help/quest/articles/headsets-and-accessories/oculus-link/oculus-link-compatibility/

### Install
1. Clone this project, then ["Add an existing project from disk"](https://docs.unity3d.com/hub/manual/AddProject.html#add-an-existing-project-from-your-disk) with Unity Hub
1. Under `Project` tab, open `Assets`->`Scenes`->`DataViz`
1. Open `Assets`->`AI_Data`->`firstQtr_prefab.prefab` and in the `Inspector` tab, click the "..." button and choose the location of `firstQtr.usd` file downloaded before, then click the refresh button/icon. ![](Screenshots/Screenshot1.png)
1. Repeat this for `secondQtr_prefab`, `thirdQtr_prefab`, and `fourthQtr_prefab`.
1. In the `Hierarchy` tab, expand the `Playables` GameObject, then multi-select the four child prefabs
1. In the `Inspector` tab, click the `Overrides` drop-down list and then click "Revert all" so that the updated USD paths are used instead. Then uncheck the `Active` GameObject box so that all four prefabs are inactive. ![](Screenshots/Screenshot2.png)
1. To validate, select the `Playables` GameObject, open `Window`->`Sequencing`->`Timeline`, and click the `play` button. You should see the data animating and the timeline playing.

## Play in XR
For now, this app has been tested only on a Meta Quest 2 tethered via USB-C. Assuming the Oculus app is installed on your machine and you have added your Quest device, simply press the main `Play` button of the Unity editor to send it to your Quest.

### Controls
- Left grip reverses the animiation when pointing at data
- Left thumbstick controls user XZ translation
- Right grip plays/pauses the animation when pointing at data
- Right stick rotates user
