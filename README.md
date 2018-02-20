# Infinitton
Disables the keyboard when the computer is locked, and re-enabled the keyboard when the computer is unlocked.

This is a simple hacked together program that will help preserve the life of an Infinitton Smart Keyboard by disabling it when not in use. There are probably better ways to do this, but Infinitton is not releasing API or open source access. 


### Prerequisites
Probably need some sort of C# .NET redistributable. I am using .NET 4.5.2 so look for that redist if you have problems. Also, this is designed for windows and probably doesn't work on linux, even with Wine. This program also has to run as Admin to work.

First thing is to unzip the files and edit the "Infinitton Keyboard Controller.exe.config" file in any text editor. Open up the official Infinitton ISE and copy the Serial Number in Settings->Device->Serial Number to the SerialNo spot in "Infinitton Keyboard Controller.exe.config". Save and close that file and continue. See the image below for more clarification.
![SerialNoPic](https://github.com/ctreadw6/Infinitton/blob/master/Pics/pic1.PNG)

### Setup
This program needs to be always running in order to intercept the lock and unlock events. The easiest way to do this and to have it always run in Admin mode is to create a task in the task scheduler. First open up the task scheduler in Windows and create a new task. 

These things need to be set
```
General -> When running the task, use the following user account - Make sure this is an Admin account
General -> Run only when user is logged on
General -> Run with highest privileges
General -> Configure for Windows (Version)

Triggers -> At log on
Triggers -> Specific user: Same username as before

Actions -> Start a program ( Select the .exe file)

Settings -> Allow task to be run on demand
Settings -> If the task is already running, then (Do not start a new instance)
```

After you get the task set up, go ahead and right click it and run it to get it going for the first time and thats all you should have to do.

### Notes
I am NOT responsible for anything that could go wrong with your computer or your smart keyboard. You are using this at your own risk. This program does not interface with the hardware directly, only with windows device manager. I am hoping this will push Infinitton to release a software update with this implemented of give out an API.
