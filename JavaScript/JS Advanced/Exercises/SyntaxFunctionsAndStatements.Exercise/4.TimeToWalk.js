function timer(steps, footPrint, speed) {
    steps = Number(steps);
    footPrint = Number(footPrint);
    speed = Number(speed);

    let distanceInMeters = steps * footPrint;
    let speedInMetersPerSec = speed * 1000 / 3600;

    let restInSecs = Math.floor(distanceInMeters / 500) * 60;
    let timeInSecs = distanceInMeters / speedInMetersPerSec + restInSecs;

    let hours = Math.floor(timeInSecs / 3600);
    let minutes = Math.floor(timeInSecs / 60);
    let seconds = Math.ceil(timeInSecs % 60);

    console.log(`${hours < 10 ? 0 : ""}${hours}:${minutes < 10 ? 0 : ""}${minutes}:${seconds < 10 ? 0 : ""}${seconds}`);
}

timer(2564, 0.70, 5.5);
timer(4000, 0.60, 5);