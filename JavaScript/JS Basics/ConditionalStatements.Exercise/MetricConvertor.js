function Convert(input) {
    let value = Number(input[0]);
    let inputMetric = input[1];
    let outputMetric = input[2];

    const options = [
        ["mm", "mm", 1],
        ["mm", "cm", 0.10],
        ["mm", "m", 0.001],
        ["cm", "mm", 10],
        ["cm", "cm", 1],
        ["cm", "m", 0.01],
        ["m", "mm", 1000],
        ["m", "cm", 100],
        ["m", "m", 1]
    ];

    let coef = -1;

    let i;
    for (i = 0; i < options.length; i++) {
        let arr = options[i];
        let inOpt = arr[0];
        let outOpt = arr[1];

        if (inputMetric == inOpt && outputMetric == outOpt) {
            coef = arr[2];
            break;
        }
    }

    if (coef == -1) {
        throw "Invalid dimensional units!";
    }

    return (value * coef).toFixed(3);
}


let res = Convert(["45","hm","mm"]);
console.log(res);