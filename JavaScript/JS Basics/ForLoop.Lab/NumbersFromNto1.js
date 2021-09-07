function numbersFromNto1Desc(input) {
    let n = Number(input.shift());

    for (let i = n; i >= 1; i--) {
        console.log(i);
    }
}

numbersFromNto1Desc(["5"]);