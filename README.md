Introduction of Eye Tracker program:
===================================

Have you ever thought of freeing your hands from the keyboard and controlling your computer directly we your eyes? This project is started to build a system which could tell where your eyes are looking at on the screen and you can even choose function icons by staring at the same point or swiping your focusing point across the screen to select the target in order to execute some preset instructions.

After studying the current researches of the eye tracking, we found that using only the webcam to locate your focusing point is still a challenge these days because your eyes and your face could reflect the environment lights which may cause a huge noise while recognizing your eyes with the computer vision methods. 

In order to learning Eyetracking Technology quicker, we chose a product called Tobii Eye Tracker which use the inferred camera to track your pupils. It is much easier and more accurate to recognize pupils even when you are wearing glasses. We use Visual studio to build a primitive system with a menu bar based on c# which can open applications when you are staring at the icon for a second and we build a software checking your emails and give some functions like deleting or quick replying. 

This could help a lot when you are receiving hundred of emails a day and you may want to view all of them in a minute.

Another part of this project is aimed to improve the performance of the eye recognition with the webcam and design an html application which could be used on any device. We choose a library designed by Brown University called webgazer.js. The library is build on javascript and they used a bunch of computer vision methodssuch as convolutional filters, Haar Feature Selection and Adaboost Training. They also used several regression modules processing the pupils position data in order to predict where you are looking at on your screen with a calibration function. 

The current problem is that the system error is kind of unpromising because even when you are looking at the same point, the prediction point could be moving around in a circle with a radius of 180 pixels. So I designed a new way to selection the functions by swiping your eye and the prediction were made by calculating the vector of the swiping direction with linear regression module. The system error could be narrowed within 5 degrees which can be fully used on choosing between two close icons. 

An application is made to illustrate these functions which you can control google map by moving the center of the map to the 
place you are focusing on the screen and you are able to change the zooming status by swiping left right on the screen.


Since we only have one semester on this project and we are dealing with something totally new. we have very few user experience about our product.If you are interested in eye tracking feel free to try the brand new operating system and leave your opinion of our project.



Product 1 Tobii Eyetracker Application
=====
Need works



Product 2 Google Map Finder
=====

## Downloads of webgazer.js
Try download from this github repository
https://github.com/brownhci/WebGazer

Install options that you can refer to is here:
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

WebGazer.js can save and restore the training data between browser sessions by storing data to localstorage. 

At the heart of WebGazer.js are the tracker and regression modules. The tracker module controls how eyes are detected and the regression module determines how the regression model is learned and how predictions are made based on the eye patches extracted from the tracker module. These modules can be swapped in and out at any time. We hope that this will make it easy to extend and adapt WebGazer.js and welcome any developers that want to contribute.

WebGazer.js requires the bounding box that includes the pixels from the webcam video feed that correspond to the detected eyes 
of the user. Currently we include three external libraries that implement different Computer Vision algorithms to detect the 
face and eyes.

Here are some regression modules that come by default with WebGazer.js.:

* clmtrackr
* js_objectdetect
* tracking.js

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



## General Introduction
### 0.Presetting
Download, install and try the cases of webgazer from https://webgazer.cs.brown.edu locally.
Put the /webtest/ folder from our library into /webgazer/www/

### 1.Html Application interface
Run googlemap_test.html in the folder web test on your browser. Chrome is preferred while safari and firefox cannot run webgazer online examples without a local server.
![Interface Introduction](https://raw.githubusercontent.com/Regulus239/EyeAssistant/master/General%20resources/Functions%20Introduction%20of%20Webgazer.png)

### 2.Calibration
Try clicking on the web for 10 points at each corner while looking at the cursor. The data of the difference between the prediction points and cursor position will be saved and the regression module will immediately start learning your eye movement behaviour. You can review the learning process by comparing the prediction point to where you are looking. If it is not satisfying, try calibrating by click on the direction where the system does not respond well when you look at that direction.

### 3.Functions Introduction
#### 3.1.Activate showing prediction points by clicking showprediction_toggle.
After first clicking on this toggle, a red dot indicating the prediction point will be shown on the screen. If you find it annoying, you can turn it off by clicking it again. Normally it will help the calibrations process when you find your eye cannot concentrate on a small area. If the follow function does not work well, probably you may want to recalibrate with the prediction point activated.

#### 3.2.Activate tracing focusing point by clicking trace_toggle.
This toggle controls the ability of moving the center of the map to where you are focusing on. This part is to illustrate the function of using the focus point as input to execute functions. 

Asmoothening function is used to make the movement more gentle and it also shrunken the system error to some extent. According to the researching result of webgazer, the error of focusing point could be wandering around in a circle with a average ridius of about 200 pixels. The following implementation is about using linear regression module to predict the vector of the direction your eyes are moving through.

#### 3.3.Activate zooming functions by clicking zoom_toggle.
Activating this function allows you zooming in or out the map with swipe movement. A swipe movement is defined as that when you are looking from right to left or otherwise in a short time, directions of swiping will be be saved and taken as the input to execute functions (zooming in or out in this case). 

The advatage of this function is that it is much faster but more accurate to react with your eyes with less shaking. The resolution angle could be within 5 degrees, which totally satisfy the requirement about distinguishing two small function icons. 



Reference
====
Research of webagazer performance:
https://jeffhuang.com/Final_WebGazer_IJCAI16.pdf
