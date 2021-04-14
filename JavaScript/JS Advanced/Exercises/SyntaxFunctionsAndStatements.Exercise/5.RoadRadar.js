function roadRadar(velocity, area) {
    let limit;
    switch (area) {
        case 'motorway':
            limit = 130;
            break;
        case 'interstate':
            limit = 90;
            break;
        case 'city':
            limit = 50;
            break;
        case 'residential':
            limit = 20;
            break;
    }

    let difference = limit - velocity;

    let message;    
    if (difference < 0) {
        difference = Math.abs(difference);
        let status;
        if (difference <= 20) {
            status = 'speeding';
        } else if (difference <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        message = `The speed is ${difference} km/h faster than the allowed speed of ${limit} - ${status}`;
    }else{
        message = `Driving ${velocity} km/h in a ${limit} zone`;
    }

    console.log(message);
}

roadRadar(40, 'city');
roadRadar(21, 'residential');
roadRadar(120, 'interstate');
roadRadar(200, 'motorway');