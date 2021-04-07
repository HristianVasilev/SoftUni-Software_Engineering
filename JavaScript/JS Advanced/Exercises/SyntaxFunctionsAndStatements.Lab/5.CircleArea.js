function circleArea(argument) {
    let radius = Number(argument);

    if (typeof (argument) === 'number') {
        let area = Math.PI * Math.pow(radius, 2);
        console.log(area.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof (argument)}.`)
    }
};

circleArea('p');
circleArea(5);