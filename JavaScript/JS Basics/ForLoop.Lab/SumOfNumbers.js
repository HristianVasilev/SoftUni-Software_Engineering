function sumNumbers(input) {
    let arrayOfNumbers = Array.from(String(input));
    let sum = 0;

    for (let i = 0; i < arrayOfNumbers.length; i++) {
        sum += Number(arrayOfNumbers[i]);
    }

    return `The sum of the digits is:${sum}`;
}

console.log(sumNumbers(["1234"]));