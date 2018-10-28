 /* For more info on bootstrapped extensions: https://developer.mozilla.org/en-US/docs/Archive/Add-ons/Bootstrapped_extensions
                 Code template borrowed from: https://developer.mozilla.org/en-US/docs/Archive/Add-ons/How_to_convert_an_overlay_extension_to_restartless
*/

// The rest was designed by John Neal, EyeAssistant group

 Components.utils.import("resource://gre/modules/Services.jsm"); // imports Serivces module which allows you to borrow components such as windows (in this case)


function startup(data,reason) {
    console.log("startup!");

    var ww = Components.classes["@mozilla.org/embedcomp/window-watcher;1"] 
                   .getService(Components.interfaces.nsIWindowWatcher);

    //Services.wm.addListener(WindowListener);

    var win = ww.openWindow(null, "chrome://messenger/content/messenger.xul",
                        "ChromeWindow", "chrome,centerscreen", null);


}

function shutdown(data,reason) {
    if (reason == APP_SHUTDOWN)
        return;
    console.log("shutdown"); //displays a message if the extension is shutdown
    //Services.wm.removeListener(WindowListener);
    //Components.utils.unload("chrome://myfirstext/content/overlay.js");  // Same URL as above

    // This part is from of the borrowed code.
    // HACK WARNING: The Addon Manager does not properly clear all addon related caches on update;
    //               in order to fully update images and locales, their caches need clearing here
    Services.obs.notifyObservers(null, "chrome-flush-caches", null);
}

function install(data,reason) {
    console.log("installed!");  // displays a message if the window is installed
 }

function uninstall(data,reason) {
    console.log("uninstalled");  //displays a message if the window is uninstalled
 }


var WindowListener =
{
    onOpenWindow: function()
    {   console.log("Window open!"); //displays a message if the window is open

        onWindowLoad();

        function onWindowLoad()
        {
            console.log("Window Loaded");  // displays a message if the window is loaded.
        }

    },
    onCloseWindow: function() { // displays a message if the window is closed.
        console.log("Window Closed");
    },
    onWindowTitleChange: function(newTitle) { } // here, useless
};

