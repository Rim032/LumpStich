## Lump Stich
### Description

In the Garry's Mod Workshop, maps are often given anti-decompile protection to prevent players from decompiling, studying and sometimes even playing those maps. This program aims to remove such lump protection and restore a map to it's original state!

### How is this done?

A protected .bsp file and it's acompanying .lmp file (a file containing a portion of entity information) are carefully stiched together to reform an unobstructed .bsp file. This ubobstrcuted .bsp can then easily be decompiled and played while the protected .bsp cannot be decompiled, lacks entities and may even crash your game!

### Reason

I want to allow people to decompile maps for reverse engineering and learning purposes. This allowed me to further explore the structure and overall inner-workings of a .bsp file. I've had a great time both learning about .lmp and .bsp files while constructing this program.

### Misc.

Note: If there are any bugs/issue please let me know.
Only GMOD and HL2 maps have been tested. A warning will be given if using a BSP version other than 20.
This program works best against i-am-scott's [BSPLumpManager](https://github.com/i-am-scott/BSPLumpManager).



### Images
![image](https://github.com/Rim032/lump_stich/assets/45215785/0bbeba9d-3337-45b8-abdf-81f4c4e0c07f)
#### Main GUI of Program; stiching an example gm_flatgrass .bsp

![image](https://github.com/Rim032/lump_stich/assets/45215785/a2196fb2-386c-49af-bd54-10cebf894afa)
#### Files before stich. An unuseable .bsp and seemingly redundant .lmp

![image](https://github.com/Rim032/lump_stich/assets/45215785/d07230b5-c635-4728-a554-e4d0da45d847)
#### Files after stich. A new unprotected and working .bsp is generated



### Build History
```
v1.00 - January 11th 2023 - Initial Release
v1.01 - January 17th 2023 - Small Bug Fixes
v1.05 - January 19th 2023 - Improvements & Bug Fixes
v2.00 - October 6th 2023 - Major Improvements & GUI Release
v2.01 - October 25th 2023 - Small Bug Fixes & Improvements
v2.02 - January 6th 2023 - Small Visual Changes
```
