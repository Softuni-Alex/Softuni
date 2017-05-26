"use strict";

function productOf3Numbers(input) {
    let x = input[0]
    let y = input[1]
    let z = input[2]

    let result = x*y*z
    
    if(result >= 0){
    console.log("Positive")
    }
    
    if(result < 0){
        console.log("Negative")
    }
}

productOf3Numbers([-3,-4,-5])