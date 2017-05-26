"use strict";

function multiplyDevideANumber(input) {
    let n = input[0]
    let x = input[1]

    let result = 0
    if(x>=n){
        result = x*n
        console.log(result)
    }
    else {
        result = n/x;
        console.log(result)
    }
}

multiplyDevideANumber([144,12])