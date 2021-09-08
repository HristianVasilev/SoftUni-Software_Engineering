function histogram(input) {
    let count = Number(input[0]);
    let length = input.length;

    let p1 = 0;
    let p2 = 0;
    let p3 = 0;
    let p4 = 0;
    let p5 = 0;

    for (let i = 1; i < length; i++) {
        let n = Number(input[i]);

        if (n < 200) {
            p1++
        } else if (n >= 200 && n < 400) {
            p2++;
        } else if (n >= 400 && n < 600) {
            p3++;
        } else if (n >= 600 && n < 800) {
            p4++;
        } else if (n >= 800) {
            p5++;
        }
    }

    console.log(`${(p1/count*100).toFixed(2)}%`);
    console.log(`${(p2/count*100).toFixed(2)}%`);
    console.log(`${(p3/count*100).toFixed(2)}%`);
    console.log(`${(p4/count*100).toFixed(2)}%`);
    console.log(`${(p5/count*100).toFixed(2)}%`);
}

histogram(["3", "1", "2", "999"]);