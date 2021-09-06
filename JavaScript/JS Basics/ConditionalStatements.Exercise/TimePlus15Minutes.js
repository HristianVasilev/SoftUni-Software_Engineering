function CalculateTime(input) {
    let hours = Number(input[0]);
    let minutes = Number(input[1]);

    let dateTime = new Date();
    dateTime.setHours(hours);
    dateTime.setMinutes(minutes + 15);
    dateTime.setSeconds(0);

    let r = dateTime.toLocaleTimeString([], {
        hour: "numeric",
        minute: '2-digit',
        hour12: false   
    });

    console.log(r);
}

CalculateTime(["1", "46"]);
