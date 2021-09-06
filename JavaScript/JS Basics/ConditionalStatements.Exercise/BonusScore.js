function CalculateBonusScore(input) {
    let points = Number(input[0]);
    let bonus = 0;

    if (points <= 100) {
        bonus += 5;
    } else if (points > 100 && points <= 1000) {
        bonus += points * 0.20;
    } else {
        bonus += points * 0.10;
    }

    if (points % 2 == 0) {
        bonus += 1;
    }

    let numAsStr = String(input[0]);
    let lastDigit = numAsStr.split("")[numAsStr.length-1];
    ;
    if (lastDigit == 5) {
        bonus += 2;
    }

    console.log(bonus);
    console.log(points + bonus);
}

//CalculateBonus(["20"]);
//CalculateBonus(["175"]);
//CalculateBonus(["2703"]);
CalculateBonus(["15875"]);