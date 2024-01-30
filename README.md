# Tool to work with UI textures - new version 2016-08-17 v1.2.0.0


## Additional Information
* This is a fork from MTS. 
* Original description by [CmarNYC](https://modthesims.info/member.php?u=3216596) who retired on earth and is now supporting the TS4 development in heaven.

### Requirements:
* s4pe

## Description
Many of the UI images in UI.package are in a custom EA format - to get technical, they're in pairs of ATI2-compressed DDS files using YCoCg color space. This tool will take a pair of these images and convert them into one PNG image which any image editor can modify. Then the tool will take a PNG and convert it to the EA custom format, producing a pair of files which can be packaged and used in the game.

The UI image pairs have the same Instance ID, one has Group 0x00064DC9 and the other has Group 0x00064DCA. Be sure to load each in the right place in the tool or you'll get very strange-looking results.

Images must have dimensions that are a multiple of 4 to compress correctly: 32, 64, 128, 256, 512, 1024, 2048, etc. If you keep images the same dimensions as the game textures that should work fine.

The program is available as a single file (UITextureSquasher_1_1_0_0.zip). If for whatever reason that doesn't work on your system, please try the version with separate files in a folder (UITextureSquasher_1_1_0_0_folder.zip) and comment here.

Requires .NET 4.0 or above.
The latest version of s4pe will preview and extract the UI.package images: https://github.com/s4ptacle/Sims4Tools/releases

The pictures attached are the two Willow Creek map images from UI.package, the combined bitmap image, and a modified Willow Creek in-game.

#### TODO add images

Update 8/14/16: Changed conversion format from BMP to PNG, since bmp images seem to open in Photoshop and Paint.net with a black background in transparent areas. Added error check for opening the wrong type of DDS file.

Update 8/17/16: Fixed a compression bug that was causing degradation of the DDS files converted from PNG.

Additional Credits:
The EA forums and SimGuruModSquad: http://forums.thesims.com/en_US/dis...s-in-ui-package

Everyone who's contributed to s4pi/s4pe

Inge for testing 