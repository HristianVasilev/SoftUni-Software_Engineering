function countTheWords(input) {
    let array = String(input).split(' ');
    let count = array.length;

    if (count > 10) {
        return `The message is too long to be send! Has ${count} words.`;
    }

    return `The message was sent successfully!`;
}

let result = countTheWords(["1 2 3 4 5 6 7 8 9 10 11"]);
console.log(result);