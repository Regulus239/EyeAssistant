Introduction of  Eye Tracker program:
=

* Main frame of webcam: https://webgazer.cs.brown.edu with webgaze (established by Brown University)
* Demo of tobii eyetracker: https://tobiigaming.com/software/ghost/
* The usage Visualstudio C# Windows Presentation Foundation

## Downloads of webgazer.js

https://github.com/brownhci/WebGazer
```
# Ensure NodeJS is downloaded: https://nodejs.org/en/download/
# Install grunt-cli if not installed (this may require you to use `sudo` or run the console as Administrator)
npm install -g grunt-cli
git clone https://github.com/brownhci/WebGazer.git
npm install
# Run grunt to build the webgazer.js and webgazer.min.js file in the build directory
grunt
```

## Usage of webgazer.js:

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


## How to run the Example HTML files
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

Usage of webgazer applications
==
## Presetting
Download, install and try the cases of webgazer from https://webgazer.cs.brown.edu locally.
Put the /webtest/ folder from our library into /webgazer/www/

## Google Map Finder
Run googlemap_test.html in the folder web test on your browser. Chrome is preferred while safari and firefox cannot run webgazer online examples without a local server.

## Calibration
Try click on the web for 10 points at each corner while looking at the cursor.
Activate showing prediction points by clicking showprediction_toggle.
Activate tracing focusing point by clicking trace_toggle.
Activate zooming functions by clicking zoom_toggle.

