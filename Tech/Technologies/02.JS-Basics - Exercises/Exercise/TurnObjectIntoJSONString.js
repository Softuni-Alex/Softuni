"use strict";

function objectIntoJSON(input) {
    let object = {};

    for (let i=0; i<input.length; i++) {
        let s = input[i].split(" -> ");
        let k = s[0];
        let v = s[1];
        if (!isNaN(v))
            v = parseInt(v);
        object[k] = v;
    }
    let toString = JSON.stringify(object);
    console.log(toString);
}


objectIntoJSON([
    'name -> Angel',
    'surname -> Georgiev',
    'age -> 20',
    'grade -> 6.00',
    'date -> 23/05/1995',
    'town -> Sofia'
])