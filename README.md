# Local Multiplayer
[![Unity 2021.1+](https://img.shields.io/badge/unity-2020.1%2B-blue.svg)](https://unity3d.com/get-unity/download)
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://github.com/qhenshaw/CharacterMovement/blob/main/LICENSE.md)

Local Multiplayer is a feature set that allows players to join and configure character data in one scene and then play in another.
The system uses `ScriptableObject` assets to store joined/ready players and then reconstruct their input devices and spawn characters.

## System Requirements
- mob-sakai's Git Dependency Resolver must be installed before importing this package. 
- Unity 2021.1+. Will likely work on earlier versions but this is the version I tested with.

## Installation
Use the Package Manager and use Add package from git URL, in the following order:
```
https://github.com/mob-sakai/GitDependencyResolverForUnity.git
https://github.com/qhenshaw/CharacterMovement.git
```
You may have to unfocus and then focus the Unity Editor window to get it to compile dependencies.

## Usage
Install the Character Select sample to see the system in action.  
**The `LocalMultiplayer` scene MUST be added to the Build Settings scene list before playing.**
