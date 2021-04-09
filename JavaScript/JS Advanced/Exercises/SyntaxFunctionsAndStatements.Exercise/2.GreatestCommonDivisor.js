function divisor(firstNum, secondNum) {
    firstNum = Number(firstNum);
    secondNum = Number(secondNum);

    let biggest = Math.max(firstNum, secondNum);
    let smallest = Math.min(firstNum, secondNum);

    for (let i = smallest; i > 0; i--) {
        if (biggest % i == 0 && smallest % i == 0) {
            console.log(i);
            break;
        }
    }
}

divisor('15', '5');
divisor('2154', '458');