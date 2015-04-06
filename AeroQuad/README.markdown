AeroQuad Flight Software Source Code v3.2
========================================
[http://www.AeroQuad.com](http://www.AeroQuad.com)
Modified for use by the Harris Drone Team @ University of Michigan

Build [Linux]
-----------------------------------------
Preparation:

1. If you have a modern Linux distro (like Ubuntu 12.04 or greater), Network Manager may use a service called modem-manager to capture USB ACM devices to probe them as modems (POTS, 3G, etc). As of Ver 3.2, this causes the AQ32 trouble as it makes changes to its configuration. You will know if you have this issue as when you plug in the device and try to access /dev/ttyACM# and you get an error that the device is busy for about 30 seconds. To fix this, blacklist the AQ32 usb device from being accessed by modem-manager as follows:

    Add the following lines to this file: /lib/udev/rules.d/77-mm-usb-device-blacklist.rules
    Code:
    ```
    # STM32 (AeroQuad32)
    ATTRS{idVendor}=="0483", ATTRS{idProduct}=="5740", ENV{ID_MM_DEVICE_IGNORE}="1"
    ```

2. Download version 2011.09-69 of CodeSourcery ARM EABI Lite and install it (Download link). Newer versions of the toolchain seem to cause problems at the moment.
3. Make sure you have make (and preferably git) installed. Also make sure you have dfu-util installed. Most distributions provide a package, but if not you can obtain is here: http://dfu-util.gnumonks.org/
4. Add the codesourcery "bin" directory to your path "export PATH=$PATH:/path/to/sourcery/bin/" (you may want to make this permanent by editing .profile or whatever).


Compiling and uploading:

1. Copy (or clone using git) the AeroQuad software from GitHub.
You can use "git" to do this simply by using the following git command: "git clone http://github.com/AeroQuad/AeroQuad.git -b development".
2. Customize the software to fit your own needs. Make sure to edit "AeroQuad/UserConfiguration.h" and uncomment "#define AeroQuadSTM32" and comment out all other platform defines (like AeroQuad_v2 etc.).
3. Navigate then to the directory which includes the AeroQuad software ("AeroQuad,AeroQuad32,BuildAQ32,Libmaple,...").
4. Make Libmaple with "make -C Libmaple/libmaple library".
5. Make AQ with "make -C BuildAQ32".
6. Note that the needed binary is in "BuildAQ32/objSTM32/AeroQuad32/[AeroQuadMain.bin](BuildAQ32/objSTM32/AeroQuad32/AeroQuadMain.bin?raw=true)"
7. Reset the board to DFU mode by "echo 1EAF > /dev/ttyACM0"
8. Download the binary by "dfu-util -d 0483:df11 -a 0 -s 0x8010000 -D 9. BuildAQ32/objSTM32/AeroQuad32/AeroQuadMain.bin". You will probably need to run it with sudo or as the root user.
9. Hit the reset button on the AeroQuad32 board. (If you have the patched dfu-util "dfu-util -d 0483:df11 -a 0 -L" will reset the board out of DFU.)
