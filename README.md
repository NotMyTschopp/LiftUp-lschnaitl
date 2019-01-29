# LiftUp-lschnaitl
Simple Unity game. Try to get as high as can.

Dev-Platform: Win 10, Unity 2018.2.14f1, Visual Studio Community 15.9.3
Target-Platfrom: Standalone PC

Status: implementation

Controls: On X-Axis, with AD or Left and Right.

Concept:

NEW: The base mechanic stays the same but the new goal is to just stay alive. Platforms are rising from below with random speed values.
They have deadly spikes on the lower side of them, if touched by the player, its game over.
If platforms hit one another from below, the one coming from below, thus touching the spikes, breaks (disappears). 
This forces the player, when standing on the breaking platform to drop to another one underneath him.
The Player dies when:
 + touching the spikes of any platform
 + falling out of the cameras view
 + hitting the top of the cameras view


OLD:
<img src="Documents/concept-liftup.jpeg" width="250">