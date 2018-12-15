Introduction of  Eye Tracker program:
=

* Part 1: A user interface for Google Maps based on WebGazer.js: https://webgazer.cs.brown.edu (established by Brown University).
* Part 2: A user interface created using the Tobii Core SDK to create a WPF application to be used with the Tobii EyeTracker 4c.

## Usage of webgazer:

WebGazer.js can save and restore the training data between browser sessions by storing data to localstorage. At the heart of WebGazer.js are the tracker and regression modules. The tracker module controls how eyes are detected and the 
regression module determines how the regression model is learned and how predictions are made based on the eye patches 
extracted from the tracker module. These modules can be swapped in and out at any time. We hope that this will make it easy to 
extend and adapt WebGazer.js and welcome any developers that want to contribute.

WebGazer.js requires the bounding box that includes the pixels from the webcam video feed that correspond to the detected eyes 
of the user. Currently we include three external libraries that implement different Computer Vision algorithms to detect the 
face and eyes.

* clmtrackr
* js_objectdetect
* tracking.js
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

## Util and Params

We provide some useful functions and objects in webgazer.util. The webgazer.params object also contains some useful parameters 
to tweak to control video fidelity (trades off speed and accuracy) and sample rate for mouse movements.


webgazer.util.bound(prediction);
prediction.x; //now always in the bounds of the viewport
prediction.y; //now always in the bounds of the viewport


download instructions:
#Ensure NodeJS is downloaded: https://nodejs.org/en/download/

npm install -g grunt-cli
git clone https://github.com/brownhci/WebGazer.git
cd WebGazer
npm install

#Run grunt to build the webgazer.js file in the build directory
grunt

more detail should be found on github: https://github.com/brownhci/WebGazer

How to run the Example HTML files
==

Within the /www directory there are two example HTML files:

calibration.html: This example includes additional user feedback, such as a 9-point calibration sequence, accuracy measurements and an informative help module.
collision.html: This example contains a game where the user can move an orange ball with their eyes, which in turn collides with blue balls.
To run the example files as a server:
```
# Clone the repository and download NodeJS using the steps listed above
# Move into the www directory and download the additional dependencies
cd www
npm install
# Run the webpage index.html as a server
browser-sync start --server --files "*"
```

## Usage of Tobii EyeTracker 4C and Core SDK

The Tobii Core SDK can be found here: https://developer.tobii.com/consumer-eye-trackers/core-sdk/

Since the Tobii Eyetracker 4C only runs on Windows currently, you are out of luck (unfortunately) if you try our WPF application on another OS.

We used Microsoft Visual Studio Community 2017 with tghe Tobii Interaction Nuget package (the Tobii Core SDK) to buld a WPF application which prototypes a user interface to work with the Tobii EyeTracker 4c. This UI also integrates the Gmail C# API to show how one's inbox can be scanned using hte EyeTracker.

To run the software, we recommend you download Visual Studio Microsoft 2017. It's free an helpful.

You will need to download the Tobii EyeChip driver and the Tobii Eyetracker software from Tobii's website: https://help.tobii.com/hc/en-us/articles/115003827934-Get-started

To use the Gmail API, read up on how to allow the application access to a Gmail account: https://developers.google.com/gmail/api/quickstart/dotnet 

We recommend not using your personal email for this! Set up a test account, forward it emails that are not information sensitive, and then use these to test our software.

Several lines of code depend on where certain files are stored on your computer. If you see any filepaths in our code, make sure to double check that they match the filepath on your computer. Chances are, they probably don't and you will have to change them.

The icons for our application were borrowed from: https://thenounproject.com/apps/


