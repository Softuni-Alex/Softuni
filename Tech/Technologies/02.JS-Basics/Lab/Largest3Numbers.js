"use strict";

function Largest3(input) {
    let array = input.map(Number)
    let sorted = array.sort((x, y) => y - x)
    let count = Math.min(3)

    for (let i = 0; i < count; i++) {
        console.log(sorted[i])
    }
}

Largest3(['10', '30', '15', '20', '50', '5'])