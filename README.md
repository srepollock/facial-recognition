# COMP4932-Assignment3
COMP4932 Assignment 3 : Facial Recognition

# About
Face recognizer program. This is a program that uses your computers webcam to find a face, currently the best face inside the face space, to then find in the library of faces (prerequisite).

# Table of Contents
* [Controls](#controls)
* [Usage](#usage)
    * [Adding Faces](#adding-faces)
    * [Finding Faces](#finding-faces)
* [FAQ](#faq)
* [References](#references)
    * [Library](#library)
    * [Viola-Jones](#viola-jones)
    * [EigenFaces](#eigen-faces)
* [License](#license)

# Controls
1. Ctrl-C : Finds the best face in the image (the one that looks like the best face)
2. Ctrl-F : Finds the face that we captured in the face [library*](#library) and displays the recration of it.

# Usage

## Adding faces**
> You will need to complete this 3 times, having your face within the box.
> - Top of the head at the top of the box
> - Bottom of the chin at the bottom
> - Equal gaps on both sides of the head  

1. First capture the face with [Ctrl-C](#controls)
2. Add the face to the library with [Ctrl-F](#controls)
3. Name the file `tempXX.bmp` where `XX` is the next number in the series of images  

[FAQ](#faq)

> **Feature is not yet implemented into the program.

## Finding faces
1. Refresh the cameras in the list.
    - This will get all the webcams/cameras currently plugged in
2. Select a resolution from the dropdown below it
    - Fastest results is to use a lower resolution as it is faster at finding the faces
3. First capture the face with [Ctrl-C](#controls)
4. Then test if the found face is in the [library*](#library) using [Ctrl-F](#controls)
    - It will then display the found face & average face reconstructed.  

# FAQ
_Question_  
The program keeps crashing after adding faces. Why is it doing this?
> Most likely you have not added the correct amount of images. You must add *3* (no more, no less) images of your face for the program to work. Any more or any less and the program will throw an exception.  

# References

## Library
When talking about library, I am stating that the image library of the faces must be preset with your face to be 'recognized' by the software. The image must follow the [format](#format) of the faces to be searched for the program to work correctly.  
## Viola-Jones
When talking about Viola-Jones I am referencing the method of Viola-Jones.  
[Wiki](https://en.wikipedia.org/wiki/Viola%E2%80%93Jones_object_detection_framework)
[Slides-shortened](http://www.cs.ubc.ca/~lowe/425/slides/13-ViolaJones.pdf)
## Eigen Faces
The face finder method used is based on the paper found [here](https://en.wikipedia.org/wiki/Eigenface).  
[EigenFaces paper](http://www.face-rec.org/algorithms/PCA/jcn.pdf)

# License
MIT License
> *Note*: The Viola-Jones library used can be found [here](https://github.com/accord-net/framework) under [Accord-Vision](https://github.com/accord-net/framework/tree/development/Sources/Accord.Vision).
