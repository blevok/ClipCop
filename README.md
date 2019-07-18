# ClipCop

ClipCop is a WPF desktop app written in C# that monitors the Windows clipboard and notifies you when the contents change, by flashing the taskbar icon, and playing a Windows notification sound. The taskbar will flash 25 times, and then remain lit up until you click the ClipCop taskbar icon or application window. It also displays the text that is currently in the clipboard, as well as the most recent change.

ClipCop notifies you of all changes, but if the content in the clipboard is not text, but instead is an image/file/etc, it will say "-- Non-text content --".

ClipCop was designed primarily to protect cryptocurrency wallet addresses from malicious software that replaces the address in the clipboard to make you send funds to the wrong address.
When you want to send a transaction, start ClipCop, then copy the cryptocurrency address. ClipCop will make a sound, and the icon will start flashing. Click it to stop the flashing, and check that the current clipboard contents match what you copied. Now you have the address in the clipboard, and you can paste it wherever you need to. As long as the icon doesn't light up again, the clipboard has not been changed.

You can check the ClipCop window at any time to see what's currently in the clipboard. If ClipCop detects a change, but you didn't copy anything, then you may have a virus, and you should take appropriate action to secure your PC and protect your crypto.

------------------------------

### Download :

You can download the pre-compiled program here:

https://github.com/blevok/ClipCop/releases/download/1.0.0.0/ClipCop.exe

------------------------------

### Screenshots : 

**Monitoring enabled:**

![Monitoring enabled](https://raw.githubusercontent.com/blevok/ClipCop/master/ClipCop/cc-on.png)

**Monitoring disabled:**

![Monitoring disabled](https://raw.githubusercontent.com/blevok/ClipCop/master/ClipCop/cc-off.png)

**Taskbar:**

![Taskbar](https://raw.githubusercontent.com/blevok/ClipCop/master/ClipCop/cc-taskbar.png)

------------------------------

### Disclaimer :

ClipCop and/or the developer is not responsible for any loss or damage of any kind, and is intended only as a helpful utility with no liability or guarantee.

------------------------------

### License :

Stream Helper is released under the GNU GPLv3.0 license.

------------------------------

### Donate :

If you find this program useful or it helped to actually protect your crypto from theft, consider making a small donation.

BTC: 1DQLbaxohsnXy575Y3uhabimkny2Vw3UrX

ETH: 0xb6aC512DeEAd27F607C80a6A249B7d5941A5a1eF

LTC: LYHLd1FzNZVy4kcNQdyGCGaVpgtMpho8yk

DOGE: DP69FaUzG8NBmnUNRoP7SU2mqsus3ELqgZ