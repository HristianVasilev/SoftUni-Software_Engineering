function divideWithoutRemainder(input) {
    // function responsible for the convertion of the array
    function convertToNumberArray(input) {
        let numberArray = Array(input.length);
    
        for (let i = 0; i < numberArray.length; i++) {
            numberArray[i] = Number(input[i]);
        }
    
        return numberArray;
    }

    let numbersArray = convertToNumberArray(input);

    let countOfNumbers = numbersArray[0];

    let p1 = 0;
    let p2 = 0;
    let p3 = 0;

    for (let i = 1; i < numbersArray.length; i++) {
        let currentNumber = numbersArray[i];

        if (currentNumber % 2 == 0) {
            p1++;
        }
        if (currentNumber % 3 == 0) {
            p2++;
        }
        if (currentNumber % 4 == 0) {
            p3++;
        }
    }

    let result =
        `${(p1/countOfNumbers*100).toFixed(2)}%${'\n'}` +
        `${(p2/countOfNumbers*100).toFixed(2)}%${'\n'}` +
        `${(p3/countOfNumbers*100).toFixed(2)}%`;

    return result;
}




let result = divideWithoutRemainder(["10",
    "680",
    "2",
    "600",
    "200",
    "800",
    "799",
    "199",
    "46",
    "128",
    "65"
]);

console.log(result);