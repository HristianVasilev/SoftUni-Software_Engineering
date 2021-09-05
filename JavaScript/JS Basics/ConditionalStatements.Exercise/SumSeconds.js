function SumSeconds(input) {
    let first = Number(input[0]);
    let second = Number(input[1]);
    let third = Number(input[2]);

    let totalSeconds = first + second + third;
    let time = new Date();

    let minutes = (Math.floor(totalSeconds / 60)).toFixed(0);
    let seconds = ("0" + totalSeconds % 60).slice(-2);
    // time.setSeconds(totalSeconds);

    console.log(`${minutes}:${seconds}`);
}

SumSeconds(["35", "45", "44"]);
SumSeconds(["22", "7", "34"]);
SumSeconds(["50","50","49"]);
SumSeconds(["14", "12","10"]);