(input) => {
    const budget = Number(input.shift());
    const countOfExtra = Number(input.shift());
    const pricePerCloth = Number(input.shift());

    let decorPrice = budget * 0.1;
    let clothesPrice = countOfExtra * pricePerCloth;

    if (countOfExtra > 150) {
        clothesPrice *= 0.9;
    }

    let totalCosts = decorPrice + clothesPrice;

    let diff = budget - totalCosts;
    if (diff >= 0) {
        console.log("Action!");
        console.log(`Wingard starts filming with ${diff.toFixed(2)} leva left.`);
    } else {
        console.log("Not enough money!");
        console.log(`Wingard needs ${-diff.toFixed(2)} leva more.`);
    }
}

(["20000",
"120",
"55.5"])


