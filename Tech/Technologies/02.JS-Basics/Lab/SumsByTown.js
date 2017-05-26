"use strict";

function sumsByTown(input) {
    let objects = input.map(JSON.parse)
    let sums = {}

    for (let obj of objects) {
        if (obj.town in sums) {
            sums[obj.town] += obj.income;
        }
        else {
            sums[obj.town] = obj.income
        }
    }
        let towns = Object.keys(sums).sort().forEach(x=>console.log(x + " -> "  + sums[x]));
}

sumsByTown([
        '{"town": "Sofia", "income": 200}',
        '{"town": "Varna", "income": 120}',
        '{"town": "Pleven", "income": 60}',
        '{"town": "Varna", "income": 70}'
    ])