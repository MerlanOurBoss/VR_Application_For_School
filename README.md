# VR Application For School

An educational VR application for school lessons, built with Unity. Students run physics and chemistry experiments in a virtual classroom and assemble a computer network, guided by a voice assistant that speaks Kazakh.

📁 [Project materials on Google Drive](https://drive.google.com/file/d/1YYM1aucenOZT2IMj_lC3mtZWu1Nmds7M/view?pli=1)

## What's inside

The application has two scenes in `Assets/Scenes`:

| Build index | Scene | Purpose |
|:---:|---|---|
| 0 | `SampleScene` | Virtual laboratory |
| 1 | `ComputerNetworks` | Computer networking practical |

### Virtual laboratory

- **Mass and momentum:** cubes of different masses and a push whose force is set with a slider.
- **Falling in a vacuum:** a feather falls slowly in air and without resistance inside the vacuum zone.
- **Chemistry:** liquids can be poured between flasks and mix by color. A reaction can produce smoke or fire, and acidity is checked with a tester.
- **Fire safety:** a fire is put out with an extinguisher that has a limited charge.
- **Whiteboard:** write with a marker, change its color, and erase what you wrote.

The player's hands physically interact with objects and buttons in the scene.

### Computer networking practical

A voice assistant with on-screen text guides the student step by step and responds to correct and incorrect actions:

1. Take the cable from the desk and connect it to the external network.
2. Connect the other end of the cable to the router.
3. Connect the router to the switch.
4. Connect the computers to the switch, choosing the connection type (straight-through or crossover). The stand shows the T-568A and T-568B wiring schemes.
5. Use the arrow pointer to find the computer with the required IP address, assign a VLAN, and connect it.

The goal is to connect 24 computers within the time limit (300 seconds by default). The scene also includes a simulated command prompt with a `ping` command. IP addresses are randomly generated and the `ping` output is simulated: the application sends no real network requests.

## Tech stack

- Unity **2021.3.16f1**, Universal Render Pipeline 12.1.8, C#
- XR Interaction Toolkit 2.0.4, XR Plugin Management 4.2.0
- OpenXR 1.5.3, Oculus XR Plugin 3.2.2
- TextMesh Pro, Post Processing

Configured XR providers:

| Platform | Providers | Devices |
|---|---|---|
| Windows | Oculus | Oculus headset connected to a PC |
| Android | OpenXR, Mock HMD | Standalone headset, such as Meta Quest 2 |

## Getting started

You will need Unity Hub and Unity 2021.3.16f1. Building for a headset also requires the **Android Build Support** module.

```bash
git clone https://github.com/MerlanOurBoss/VR_Application_For_School.git
```

1. Add the project folder to Unity Hub and open it in Unity 2021.3.16f1. The first import may take a while.
2. Open the scene you need from `Assets/Scenes`.
3. Connect your headset to the PC and press **Play**.

### Building for Android

1. Open **File → Build Settings** and switch the platform to **Android**.
2. In **Player Settings → Publishing Settings**, enter the passwords for `user.keystore` (alias `add`) or select your own keystore. The passwords are not stored in the repository.
3. Connect the headset in developer mode and select it under **Run Device**.
4. Click **Build And Run**.

> **Important:** there is no transition from `SampleScene` to `ComputerNetworks`. A build starts in `SampleScene`, so to try the networking practical, open its scene in the editor or move it to the first position in **Build Settings**.

## Project structure

```text
Assets/
├── Scenes/            # application scenes
├── Scripts/           # laboratory logic
│   ├── Liquid/        # liquids and reactions
│   ├── Pen/           # marker and whiteboard
│   └── Computer Networks/  # networking practical
├── Audio/             # voice-over for the assistant's steps
├── Resources/         # voice-over for responses to student actions
├── Model/             # 3D models and effects
├── Materials/         # materials and textures
├── Prefabs/           # prefabs
└── Custom asstest/    # XR settings and third-party assets
```

Key scripts in the networking practical:

| Script | Purpose |
|---|---|
| `AIHelper.cs` | Assistant steps, prompts, and voice-over |
| `buttonPushConnect.cs` | Connection type check and cable connection |
| `IPAddressGame.cs` | Target IP selection, timer, and computer counter |
| `IPv4Address.cs` | Computer IP address generation |
| `NavigationArrow.cs` | Arrow pointing to the target computer |
| `Vlan.cs` | VLAN number |
| `Ping.cs` | Simulated `ping` output |

## Author

[MerlanOurBoss](https://github.com/MerlanOurBoss)
