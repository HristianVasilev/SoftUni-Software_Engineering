function FindGreaterNumber(input) {
    let firstNumber = Number(input[0]);
    let secondNumber = Number(input[1]);

    let max = Math.max(firstNumber, secondNumber);
    console.log(max);
}

FindGreaterNumber(["5", "3"]);