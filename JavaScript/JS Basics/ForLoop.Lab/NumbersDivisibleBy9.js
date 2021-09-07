function numbersDivisibeByNine(input) {
    let a = Number(input[0]);
    let b = Number(input[1]);

    const divider = 9;

    let resultArray = Array(2);
    let sum = 0;

    for (let i = a; i <= b; i++) {

        if (i % divider == 0) {
            resultArray.push(i);
            sum += i;
        }

    }

    let arrItems = resultArray.join('\n').trim();
    let result = String(`The sum: ${sum}${'\n'}${arrItems}`);
    return result;
}

let res = numbersDivisibeByNine(["100", "200"]);
console.log(res);