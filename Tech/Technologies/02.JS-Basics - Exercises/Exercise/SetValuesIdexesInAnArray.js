"use strict";

function setValuesIndexInArray(input) {
        let emptyArray = []

    for (let i = 0; i < input[0]; i++) {
        emptyArray[i] = 0
    }

    for (let i = 1; i < input.length; i++) {
       let pairs = input[i].split(' - ')
        let couple = pairs.map(Number)
        let index = couple[0]
        let value = couple[1]

        emptyArray[index] = value;
    }

    for (let obj of emptyArray) {
        console.log(obj)
    }   
}

setValuesIndexInArray(['5', '0 - 3', '3 - -1', '4 - 2'])