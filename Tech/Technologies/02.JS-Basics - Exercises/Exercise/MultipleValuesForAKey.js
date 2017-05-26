"use strict";

function multiplyValues(input) {
    let result = []
    let lastKey = input[input.length-1];
    for (let i = 0; i < input.length-1; i++) {
        let tokens = input[i].split(' ')
        let keys = tokens[0]
        let values = tokens[1]
        let obj = {key: keys, value:values}

        result.push(obj)
    }
    let check = true
    for (let obj of result) {
            if(obj.key === lastKey){
                console.log(obj.value)
                check = false;
            }
    }
    if(check){
    console.log("None")
    }
}

multiplyValues(['key value',
                'key eulav',
                 'test tset',
                 'key',
])