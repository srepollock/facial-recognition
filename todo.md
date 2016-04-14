# TODO
> Most of my TODO's for the project will be in the Visual Studio Task list.  This is just an overview of the projects to do

- [  ] Brute Force: **(20%)** 
    - See notes in notebook on how to implement
        - Comment the shit outta this part
    - Basically search each point and try to find a space
    - Ask Tyler & Dimitry for some help
- [ x ] Optimize face space: **(10%)**
    - thread?
    - searching?
- [ x ] Motion tracking & Head tracking: **(20%)**
    - Differences between two images
    - Find the face based on the "blob"
        - see headtracking.gif for example of the "face" blob
            - "face" is a small blob ontop of a "body" a larger blob
    - Ask Tyler for some help
- [  ] Background elimitation: **(10%)**
    - Haar?
    - I don't know what to do about this one. Just find the face and smooth out the edges?
        - I know I have to apply a filter
- [  ] Integration of code provided: **(20%)**
    - basically we have to use this. Just get it working and this is done

## Thoughs
> Basic ideas and just a notepad for thoughts on the project

1. Find the best face
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