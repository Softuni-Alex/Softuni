"use strict";

function printLines(input) {
    let i = 0
    while(input[i] != "Stop")    {
        let line = input[i]
        console.log(line)
        i++
    }
}

printLines(['3','6','5','4','Stop','10','12'])