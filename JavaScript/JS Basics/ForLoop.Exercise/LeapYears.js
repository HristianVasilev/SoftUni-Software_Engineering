function leapYears(input) {
    let a = Number(input[0]);
    let b = Number(input[1]);

    for (let i = a; i <= b; i += 4) {
        console.log(i);
    }
}

// leapYears(["1908", "1919"]);
leapYears(["2000", "2011"]);
// leapYears(["1584", "1597"]);
// leapYears(["2020", "2032"]);