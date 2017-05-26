"use strict";

function store(input) {
    for (let i = 0; i < input.length; i++) {
        let tokens = input[i].split(' -> ')
        let name = tokens[0]
        let age = tokens[1]
        let grade = tokens[2]
        
        console.log("Name: " + name)
        console.log("Age: " + age)
        console.log("Grade: " + grade)
    }
}

store(['Pesho -> 13 -> 6.00',
        'Ivan -> 12 -> 5.57',
        'Toni -> 13 -> 4.90'
])