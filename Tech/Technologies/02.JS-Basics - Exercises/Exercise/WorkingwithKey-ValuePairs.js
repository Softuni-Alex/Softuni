"use strict";

function keyValuePairs(input) {
   let result = []
    for (let i = 0; i < input.length-1;i++) {
        let tokens = input[i].split(' ')
        result[tokens[0]] = tokens[1]
    }

    console.log(result[input[input.length-1]] || "None")
}

keyValuePairs(['key value',
    '3 bla',
    '3 alb',
    '2'
])