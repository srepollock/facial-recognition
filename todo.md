# TODO
> Most of my TODO's for the project will be in the Visual Studio Task list.  This is just an overview of the projects to do

- [] Brute Force: **(20%)** 
    - Search the entire image, 256x256 rectangle, then check to see if that is a face
- [x] Optimize face space: **(10%)**
    - Viola-Jones
- [x] Motion tracking & Head tracking: **(20%)**
    - Using Viola-Jones
    - Searches the image initially to find the face first,
    - Then remembers where the face is and searches locally around it to see if it is still in the image
- [] Background elimitation: **(10%)**
   - Use AForge's Gaussian blur on the found face to eliminate the background
   > Maybe other methods as weel.
- [x] Integration of code provided: **(20%)**
    - Get previous student code working with the face found

## Thoughs
> Basic ideas and just a notepad for thoughts on the project

1. [x] Find the best face
    - Instead of using just rekt[0], use rekt[i], looping through the faces and finding the best  
        
            for(int i = 0; i < rects.Lenght; i++){
                // Calc face distance here
                if(calcFaceDist < FACE_THRESH){
                    // We may have a face
                    if(calcFaceDist < min){
                        faceRectangle = rect[i];
                        min = calcFaceDist;
                    }
                }
            }  
            
    > What functions do I need to call here? What am I actually calculating?
2. 