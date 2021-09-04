function PasswordGuess(input) {
    const pass = "s3cr3t!P@ssw0rd";
    let password = input[0];

    let result;
    if (pass === password) {
        result = "Welcome";
    } else {
        result = "Wrong password!";
    }

    console.log(result);
}

PasswordGuess(["qwerty"]);