function calculateSuccess(input) {
    let recordInSeconds = Number(input.shift());
    let distanceInMeters = Number(input.shift());
    let timePerMeterInSeconds = Number(input.shift());

    let timeByWaterResistance = Math.floor(distanceInMeters / 15) * 12.5;
    let totalTime = distanceInMeters * timePerMeterInSeconds + timeByWaterResistance;

    if (totalTime < recordInSeconds) {
        console.log(`Yes, he succeeded! The new world record is ${totalTime.toFixed(2)} seconds.`);
    } else {
        console.log(`No, he failed! He was ${(totalTime-recordInSeconds).toFixed(2)} seconds slower.`);
    }
}

//calculateSuccess(["10464", "1500", "20"]);
calculateSuccess(["55555.67", "3017", "5.03"]);