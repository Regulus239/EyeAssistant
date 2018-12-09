/* This module was designed to provide the ability to change the
label of the bottom right hand corner of the main Thunderbird window (where the total meessage count is displayed
to say "This is." However, it does not work, as it is not inheriting the win object*/

var EXPORTED_SYMBOLS = ["overlay"];

function overlay(win) {
	win.addEventListener("load", function(win) { 
	win.document.getElementById("totalMessageCount").setAttribute("label", "This is"); 
	}, false);

	win.setInterval(
	function(win) {
		win.document.getElementById("totalMessageCount").setAttribute("label", "This is"); 
	}, 60000); //update date every minute

}