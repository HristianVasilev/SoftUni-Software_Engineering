function sumOfVowels(input) {
    const vowelValues = [
        ['a', 1],
        ['e', 2],
        ['i', 3],
        ['o', 4],
        ['u', 5]
    ];

    let sum = 0;
    let arr = Array.from(String(input));

    for (let i = 0; i < arr.length; i++) {
        let letter = arr[i];

        for (let j = 0; j < vowelValues.length; j++) {
            let currentVowel = vowelValues[j][0];

            if (letter == currentVowel) {
                sum += vowelValues[j][1];
            }
        }
    }

    return sum;
}

let sum = sumOfVowels(["hi"]);
console.log(sum);