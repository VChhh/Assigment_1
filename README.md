# Assigment_1


***Texture and Sprite needed***
```
Monsters: spider(jump and walk), bat(fly), fort shooting bullet
Structure: Rock, dirt with grass covered on top, block, vine made ladder, spike trap, cloud
Items: wand with its bullet, 4 keys and gates with different color, door for hidden room
```

***Monster***
```
Monster goes toward the player when the distance between the player and itself is less than a certain value
Monster can be killed by the wand's bullet
Monster instantly kill the player by colliding
```

***Level1***
```
Intro for the game. Introduce basic control and machnique to the player
Start from little wizard's home, first to the jungle, then to the foot of the mountain, finally fully entering the cave
texture: dirt with grass covered, trees and branch, rock, vine made ladder(would be used through the whole game), slime like platform stuck on wall(the green one in demo)

map(outside to the inside of the mountain):

hidden <-- start point --> jungle --> mountain  |--> hidden
                                                |--> cave --> level2
                                             hidden <--|
```

***Level2***
```
Into the cave. Gain dashing and shooting skill.
At the begining of this level, there will be 2 minecart with boot/wand separatly. If you pick the wand, the minecart with boot will drive down the slope, vice versa.
If you pick the wand at first, u will be able to fight monster but cannot enter hidden requiring dashing. Otherwise if u pick the boot, u cannot fight the monster but only esacpe. Evetually u will get both of them at the bottom(the minecart drive down). A wind blowing up will make you leave the mountain and go into the sky(level3).

map(from inside to the sky):

start point --> either choose wand(shoot)/boots(dashing)
                the one not chosen will be gained at last
                                         |
 hidden(can only access with dashing) <--|
                                         |--> hidden(access with either of the ability)
                                         |
                                         get both skill --> level3
```


***Level3***
```
Fight in the air. Pure controlling and fighting challenge
map(up to sky and enter the house):

          hidden
            |-->level4
start point |
```

***Level4***
```
The Giant's Room. Puzzle level with a little bit fight
To complete the level, player need to find different keys to open related gate(inspired from your exercise 3)
There will be spiders above the ceiling and fort guarding one gate
After opening the last gate, u will get a portal gun that can shoot portal(at most two portal), and lose ur wand, then goes into level5

map(inside the room and drop from the little basement):
              |                 |
              |---ceiling-------|
              |                 |
start point-->|      house      |
              |                 |
              ----final gate-----
                      |
                    level 5
```

***Level5***
```
The Final Tower. Puzzle stage with the portal gun.
Will not have monster since the player lost the wand in level4
player needs to make full use of the portal gun's ability and dashing
the lower tower are not designed since we have no idea how further the portal gun can work

map(inside the room and drop from the little basement):
              |   start point   |
              |-----------------|
              |                 |
              |                 |
              |-----------------|
             |                   |
             |                   |
             |-------------------|
            |                     |
            |                     |
            |                     |
              --------end--------

```

     
