function printNumbers() {
    for (let i = 1; i <= 1000; i++) {
        let arr = Array.from(String(i));
        let lastDigit = arr[arr.length - 1];

        if (Number(lastDigit) == 7) {
            console.log(i);
        }
    }
}

printNumbers();