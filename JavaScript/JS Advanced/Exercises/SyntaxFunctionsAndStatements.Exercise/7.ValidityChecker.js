function validate(params) {
    let x1 = Number(arguments[0]);
    let y1 = Number(arguments[1]);

    let x2 = Number(arguments[2]);
    let y2 = Number(arguments[3]);

    let distance1 = Math.sqrt(Math.pow((x1 - 0), 2) + Math.pow((y1 - 0), 2));

    if (Number.isInteger(distance1)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    let distance2 = Math.sqrt(Math.pow((x2 - 0), 2) + Math.pow((y2 - 0), 2));

    if (Number.isInteger(distance2)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    let distance3 = Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2));

    if (Number.isInteger(distance3)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

validate(3, 0, 0, 4);
validate(2, 1, 1, 1);