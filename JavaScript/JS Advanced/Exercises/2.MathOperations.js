function solve(num1, num2, operator) {
    let result;
    if (operator == '+') {
        result = num1 + num2;
    } else if (operator == '-') {
        result = num1 - num2;
    } else if (operator == '*') {
        result = num1 * num2;
    } else if (operator == '/') {
        result = num1 / num2;
    } else if (operator == '%') {
        result = num1 % num2;
    } else if (operator == '**') {
        result = num1 ** num2;
    }

    console.log(result);
}

solve(5, 6, '+');
solve(10, 4, '-');
solve(3, 5.5, '*');
solve(9, 3, '/');
solve(10, 3, '%');
solve(5, 2, '**');