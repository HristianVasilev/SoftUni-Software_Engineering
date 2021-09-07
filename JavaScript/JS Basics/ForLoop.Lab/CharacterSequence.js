function charArray(input) {
    let arr = Array.from(String(input));

    for (let i = 0; i < arr.length; i++) {
        console.log(arr[i]);
    }
}

charArray(["softuni"]);