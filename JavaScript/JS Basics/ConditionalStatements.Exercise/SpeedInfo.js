function GetSpeedInfo(input) {
    let speed = Number(input[0]);

    let outputResult;
    if (speed <= 10) {
        outputResult = "slow";
    } else if (speed > 10 && speed <= 50) {
        outputResult = "average";
    } else if (speed > 50 && speed <= 150) {
        outputResult = "fast";
    } else if (speed > 150 && speed <= 1000) {
        outputResult = "ultra fast";
    } else {
        outputResult = "extremely fast";
    }

    return outputResult;
}

let res = GetSpeedInfo(["8"]);
console.log(res);