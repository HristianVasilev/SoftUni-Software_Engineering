function ShopEarnings(input) {
    const puzzlePrice = Number(2.60);
    const dollPrice = Number(3.0);
    const teddyBearPrice = Number(4.10);
    const minionPrice = Number(8.20);
    const truckPrice = Number(2.0);

    let tripPrice = Number(input[0]);
    let puzzlesCount = Number(input[1]);
    let dollsCount = Number(input[2]);
    let bearsCount = Number(input[3]);
    let minionsCount = Number(input[4]);
    let trucksCount = Number(input[5]);

    let totalPrice = puzzlePrice * puzzlesCount +
        dollPrice * dollsCount +
        teddyBearPrice * bearsCount +
        minionPrice * minionsCount +
        truckPrice * trucksCount;

    let totalCount = puzzlesCount + dollsCount + bearsCount + minionsCount + trucksCount;

    if (totalCount >= 50) {
        totalPrice *= 0.75;
    }

    let earnings = totalPrice * 0.90;
    let bankAccount = earnings - tripPrice;
    let outputResult;

    if (bankAccount >= 0) {
        outputResult = `Yes! ${bankAccount.toFixed(2)} lv left.`;
    } else {
        outputResult = `Not enough money! ${-bankAccount.toFixed(2)} lv needed.`;
    }

    console.log(outputResult);
}

ShopEarnings(["40.8", "20", "25", "30", "50", "10"]);
ShopEarnings(["320", "8", "2", "5", "5", "1"]);