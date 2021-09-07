function numbersFrom1ToNByStep3(input) {
    let n = Number(input.shift());

    for (let i = 1; i <= n; i += 3) {
        console.log(i);
    }
}

numbersFrom1ToNByStep3(["10"]);