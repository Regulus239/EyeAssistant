Introduction of  Eye Tracker program:

Main frame of webcam: https://webgazer.cs.brown.edu with webgaze (established by Brown University)
Demo of tobii eyetracker: https://tobiigaming.com/software/ghost/
The usage of Thunderbird and Visualstudio C# Windows Presentation Foundation: About to finish

Saving Data Between Sessions

WebGazer.js can save and restore the training data between browser sessions by storing data to localstorage. This occurs
automatically when end() is called. If you want each user session to be independent make sure that you do not call the end() 
function.

webgazer.end()
Changing in Use Regression and Tracker Modules

At the heart of WebGazer.js are the tracker and regression modules. The tracker module controls how eyes are detected and the 
regression module determines how the regression model is learned and how predictions are made based on the eye patches 
extracted from the tracker module. These modules can be swapped in and out at any time. We hope that this will make it easy to 
extend and adapt WebGazer.js and welcome any developers that want to contribute.

WebGazer.js requires the bounding box that includes the pixels from the webcam video feed that correspond to the detected eyes 
of the user. Currently we include three external libraries that implement different Computer Vision algorithms to detect the 
face and eyes.

webgazer.setTracker("clmtrackr"); //set a tracker module
webgazer.addTrackerModule("newTracker", NewTrackerConstructor); //add a new tracker module
Here are all the external tracker modules that come by default with WebGazer.js. Let us know if you want to introduce your own 
facial feature detection library.

clmtrackr
js_objectdetect
tracking.js
webgazer.setRegression("ridge"); //set a regression module
webgazer.addRegressionModule("newReg", NewRegConstructor); //add a new regression module
Here are all the regression modules that come by default with WebGazer.js. Let us know if you would like introduce different 
modules - just keep in mind that they should be able to produce predictions very fast.

ridge - a simple ridge regression model mapping pixels from the detected eyes to locations on the screen.
weightedRidge - a weight ridge regression model with newest user interactions contribution more to the model.
threadedRidge - a faster implementation of ridge regression that uses threads.
linear - a basic simple linear regression that maps
Pause and Resume

It may be necessary to pause the data collection and predictions of WebGazer.js for performance reasons.


webgazer.pause(); //WebGazer.js is now paused, no data will be collected and the gaze callback will not be executed
webgazer.resume(); //data collection resumes, gaze callback will be called again

Util and Params

We provide some useful functions and objects in webgazer.util. The webgazer.params object also contains some useful parameters 
to tweak to control video fidelity (trades off speed and accuracy) and sample rate for mouse movements.


webgazer.util.bound(prediction);
prediction.x; //now always in the bounds of the viewport
prediction.y; //now always in the bounds of the viewport


download instructions:
# Ensure NodeJS is downloaded: https://nodejs.org/en/download/
npm install -g grunt-cli
git clone https://github.com/brownhci/WebGazer.git
cd WebGazer
npm install
# Run grunt to build the webgazer.js file in the build directory
grunt

more detail should be found on github: https://github.com/brownhci/WebGazer
