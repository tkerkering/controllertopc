# controllertopc

Important:
- You need an xinput device for it to work (only tested on xbox 360 controller so far)
- You can't look around in flight (pokeone, i don't know why cause the program does the same as i do when using mouse/keyboard)

How does the program work? (user version)
- Left-Stick is for movement - Up=W Down=S Left=A Right=B
- Right-Stick is for cursor-movement - it detects how far you push the stick so you can be more precise 
- L3/Left-Thumb - Shift
- LeftShoulder  - Mouse 1 (hold to drag)
- RightShoulder - Mouse 2 (hold to drag)
- A             - Space
- B             - Mouse 1 (i don't really know why I added B as another option for mouse 1 but people might prefer it ofer LS)

How does the program work? (dev version)

We use 2 Nuget Packages:
- SlimDX (reads out the Controller Input for us and we make our own little class for the data)
- InputSimulator (gives us a way to make the converter shorter, by not having to simulate the input by ourselfes)

Classes:
- XboxController (The Class that is our "xinput" device with a simple update method)
- ConvertInput (the class that converts the xboxcontroller input to keyboard and mouse commands)
