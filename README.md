# YASIC - Yet Another Space Invader Clone
The game is initially based on Unity's Spaceshooter tutorial. To see what it originally looks like, check out the first 10 seconds of this video  https://www.youtube.com/watch?v=kX0hnOS1QQQ

Visit https://nramburrun.itch.io/spaceshooter?secret=GEqeBpplhY8Y0zpebydkpVRYXHE to check it out :)

## Gameplay Changes
I added the following gameplay mechanics and there will be a brief description of how each of the features work. 

###### Homing Missile (work in progress)
Two types of Homing Missiles are present:

*Guaranteed Hit* - This type of missile perfectly tracks the position of the player. When the missile is spawned, it gets the position of the player and updates it as the player moves around the scene. The velocities in the x and z direction are adjusted based on the weight (importance) of the old/new velocity. This helps smoothing into a velocity direction and magnitude to prevent a sudden jerk movement. Vector 3 Slerp can also be used for this.

*Almost-homing Missile* - This missile shoots the bolt at an approximate position based on where the player was at time of spawning. The missile gets the position of the player on creation, and a force is added to the missile according to the relative vector position of the player according to the missile. It doesn't track the position of the player.

###### Spawning Babies
Not unlike the common myth of Stork carrying 10 pounds of a lifetime of responsibilities to your doorstep, this feature enables the asteroid that you destroy to spawn smaller and more annoying versions of itself. They are spawned in a circular fashion with dynamic angle allocation. 

###### Watch Your Back
The term "Having eyes at the back of your head" works well in that case. Instead of falling off into the abyss, the asteroids decide to take revenge on you when you killed their babies, you monster. They bounce at a normal direction depending on their velocity and position of impact at the bottom of the screen, and float towards you.

###### PowerUps
This is fairly common across games and I'm a big fan of powerups. There's currently 3 different types of powerups available.

*Machine Gun (MG)* - When you fire a shot, there's a delay between the next shot that you can fire. When you pick up the Machine Gun, using the RMB will remove that delay for 2 seconds so that the bolts come out in a "machine-guney" way.

*Rocket Shot (RS)* - A special type of rocket that takes a while to deploy but destroys everything in it's path.

*Health Potion (HP)* - Band-Aid for your boo-boo.

They work in a similar way as spawning hazards/enemies. They are not that common and they don't have the same probability of spawning in the scene.

