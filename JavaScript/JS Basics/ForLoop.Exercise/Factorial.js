function factorial(input) {
    let n = Number(input[0]);

    if (n == 1 || n == 0) {
        return 1;
    }

    return n * factorial(Array.from(String(n - 1)));
}

let result = factorial(["8"]);
console.log(result);