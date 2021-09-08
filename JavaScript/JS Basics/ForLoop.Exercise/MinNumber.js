function findMinNumber(input) {
    if (input.length < 2) {
        throw "There are no numbers in the input array!";
    }

    let minNumber = Number(input[1]);
    for (let i = 2; i < input.length; i++) {
        let currentNumber = Number(input[i]);

        if (currentNumber < minNumber) {
            minNumber = currentNumber;
        }
    }

    return minNumber;
}

let result = findMinNumber(["3",
"-10",
"20",
"-30"]);

findMinNumber(["2"]);

console.log(result);