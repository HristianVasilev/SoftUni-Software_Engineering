function Check(number) {
    number = parseInt(number);

    let sum = 0;
    let lastDigit = number % 10;
    let isEqual = true;

    while (number / 10 > 0) {
        let digit = number % 10;
        sum += digit;

        if (lastDigit != digit) {
            isEqual = false;
        }

        number = Math.floor(number/10);
    }

    console.log(isEqual);
    console.log(sum);
}

Check(2222222);
Check(1234);