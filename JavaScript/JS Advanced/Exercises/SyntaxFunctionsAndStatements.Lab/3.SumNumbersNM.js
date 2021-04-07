function sumNumbers(a, b) {
    let num1 = Number(a);
    let num2 = Number(b);

    let result = 0;
    for (i = num1; i <= num2; i++) {
        result += i;
    }

    console.log(result);
};

sumNumbers('1', '5');
sumNumbers('-8', '20');