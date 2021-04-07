function dayOfWeek(day) {
    let num;

    if (day == 'Monday') {
        num = 1;
    } else if (day == 'Tuesday') {
        num = 2;
    }
    else if (day == 'Wednesday') {
        num = 3;
    }
    else if (day == 'Thursday') {
        num = 4;
    }
    else if (day == 'Friday') {
        num = 5;
    }
    else if (day == 'Saturday') {
        num = 6;
    }
    else if (day == 'Sunday') {
        num = 7;
    }

    if (num == undefined) {
        console.log('error');
    } else {
        console.log(num);
    }
}

//dayOfWeek('Monday');
//dayOfWeek('Friday');
dayOfWeek('Invalid');