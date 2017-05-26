"use strict";

function removeElement(input) {
    let empty = []
    for (let i = 0; i < input.length; i++) {
        let tokens = input[i].split(' ');
        let command = tokens[0];
        let value = tokens[1];
        switch (command) {
            case 'add':
                empty.push(value)
            case 'remove':
                    empty.splice(value,1)
        }
    }

    for (let obj of empty) {
        console.log(obj)
    }
}

removeElement([
    'add 3',
    'add 5',
    'remove 2',
    'remove 0',
    'add 7'
])