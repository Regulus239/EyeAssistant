README designed by John Neal of the EyeAssistant group

This a README for a very basic Legacy Thunderbird extension that opens a window similar to the app's main window. As of the initial commit, it is missing some aspects of the main window, which later commits will try to resolve.

## Why was this extension created?

-- This extension was created as a result of spending many hours trying to create the extension from the tutorial:

https://developer.mozilla.org/en-US/docs/Mozilla/Thunderbird/Thunderbird_extensions/Building_a_Thunderbird_extension

-- I'm working with Thunderbird Daily 65.0a1 (64 bit)

-- The tutorial suggests "Note: This documention series is not yet updated for version 60." So, I researched how to build an extension for Thunderbird with a version greater than version 60.

-- This page suggests that WebExtensions are being used in Thunderbird versions greater than 60:

https://wiki.mozilla.org/Thunderbird/Add-ons_Guide_57

-- On the other hand, I built the WebExtension using this tutorial and I can't seem to get access to the document of the main window (chrome://messenger/content/messenger.xul) to implement an overlay.

-- At least with the legacy extension, I am able to access the document of main window and replicate it.

## For more info related to creating Thunderbird extensions, see:

-- Info on Thunderbird Extensions: https://developer.mozilla.org/en-US/docs/Mozilla/Thunderbird/Thunderbird_extensions

-- The few extensions I downloaded from Thunderbird were bootstrapped extensions (a type of legacy extension). See this url for more info:

https://developer.mozilla.org/en-US/docs/Archive/Add-ons/Bootstrapped_extensions

-- Because it seemed bootstrapped extensions have more capability than WebExtensions, I tried implementing the methods in this article and none of them worked:

https://developer.mozilla.org/en-US/docs/Archive/Add-ons/How_to_convert_an_overlay_extension_to_restartless

-- Going forward, I am really at a crossroads about whether to build a legacy extension or whether to keep working on finding a way to access the app through a WebExtension.


## Info about this extension:

-- This extension will open a copy of the main Thunderbird window which can be altered through the extension. I was not capable of altering the main Thunderbird itself through the extension, even though it is easy to do so through the console. And even using console.log() to try and turn the javascript file into console arguments (hoping that this would grant me the same abilities that simply entering arguments through the console provides) does not work. It seems the main Thunderbird window is not accessbile for security reasons possibly: https://developer.mozilla.org/en-US/docs/Mozilla/Gecko/Script_security

-- For more info on each of the modules, each has been siginificantly commented to provide insight on how the module works.